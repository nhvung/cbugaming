using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game8
{
    public partial class AccountListF : Form
    {
        FileInfo _accountFile;
        Dictionary<long,AccountInfo> _accounts;
        string _password;
        DelegateProcess _dlg;
        byte[] _keyBytes;
        CheckBox _chkall;
        List<string> _urls;
        
        public AccountListF()
        {
            InitializeComponent();
            _dlg = new DelegateProcess();
            _chkall = _dlg.AddDataGridViewCheckBoxAll(dgv_account, "dgv_account_col_chk");
            _accountFile = new FileInfo($"{Application.StartupPath}/accounts.json");
            _urls = new List<string>();
            var colPassword = dgv_account.Columns["dgv_account_col_password"] as DataGridViewTextBoxColumn;
            
            this.Load += AccountListF_Load;
            dgv_account.CellContentClick += Dgv_account_CellContentClick;
            _selectedRowIndex = 0;
        }

        int _selectedRowIndex;
        private void Dgv_account_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedRowIndex = e.RowIndex;
        }

        private void AccountListF_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                _loadPasswordAsync(true,()=>_RefreshList(null));
            });
        }

        #region encrypt / decrypt
        string sha256(string value, long tick)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            if (tick > 0)
            {
                byte[] fileTimeBytes = BitConverter.GetBytes(tick);
                valueBytes = valueBytes.Union(fileTimeBytes).ToArray();
            }
            _keyBytes = SHA256.Create().ComputeHash(valueBytes);

            return BitConverter.ToString(_keyBytes).Replace("-", "");
        }
        byte[] EncryptBinary(byte[] binInput)
        {
            byte[] result = new byte[0];
            try
            {
                byte[] binKey = _keyBytes, binIV = Guid.NewGuid().ToByteArray();
                using (var eAlg = Aes.Create())
                {
                    eAlg.Key = binKey;
                    eAlg.IV = binIV;

                    using (var msEncrypt = new MemoryStream())
                    {
                        msEncrypt.Write(binIV, 0, 8);
                        using (var encryptor = eAlg.CreateEncryptor())
                        {
                            var binEncrypt = encryptor.TransformFinalBlock(binInput, 0, binInput.Length);
                            encryptor.Dispose();
                            msEncrypt.Write(binEncrypt, 0, binEncrypt.Length);
                        }
                        msEncrypt.Write(binIV, 8, 8);
                        msEncrypt.Close();
                        msEncrypt.Dispose();

                        result = msEncrypt.ToArray();
                    }
                    eAlg.Dispose();
                }
            }
            catch //(Exception ex)
            {
            }
            return result;
        }
        byte[] DecryptBinary(byte[] binInput)
        {
            byte[] result = new byte[0];
            try
            {
                byte[] binKey = _keyBytes, binIV = new byte[16], binEncrypt = new byte[binInput.Length - 16];
                using (var msEncrypt = new MemoryStream(binInput))
                {
                    msEncrypt.Read(binIV, 0, 8);
                    msEncrypt.Seek(-8, SeekOrigin.End);
                    msEncrypt.Read(binIV, 8, 8);

                    msEncrypt.Seek(8, SeekOrigin.Begin);

                    msEncrypt.Read(binEncrypt, 0, binEncrypt.Length);

                    msEncrypt.Close();
                    msEncrypt.Dispose();
                }

                using (var eAlg = Aes.Create())
                {
                    eAlg.Key = binKey;
                    eAlg.IV = binIV;

                    using (var descryptor = eAlg.CreateDecryptor())
                    {
                        try
                        {
                            result = descryptor.TransformFinalBlock(binEncrypt, 0, binEncrypt.Length);
                        }
                        catch
                        {
                            result = Encoding.UTF8.GetBytes($"<encrypted>");
                        }
                        descryptor.Dispose();
                    }
                    eAlg.Dispose();
                }
            }
            catch //(Exception ex)
            {

            }
            return result;
        }

        byte[] Hex2Bytes(string input)
        {
            byte[] result = new byte[0];
            try
            {
                result = new byte[input.Length / 2];
                for (int i = 0; i < input.Length; i += 2)
                {
                    string hexChar = input[i] + "" + input[i + 1];
                    result[i / 2] = Convert.ToByte(hexChar, 16);
                }
            }
            catch { }
            return result;
        }
        string EncryptToHexString(string clearTextInput)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(clearTextInput))
                {
                    return clearTextInput;
                }
                byte[] binInput = Encoding.UTF8.GetBytes(clearTextInput);
                var binOutput = EncryptBinary(binInput);
                result = BitConverter.ToString(binOutput).Replace("-", "");
            }
            catch
            {
            }
            return result;
        }
        string DecryptFromHexString(string hexInput)
        {
            string result = default;
            try
            {
                if (string.IsNullOrEmpty(hexInput))
                {
                    return default;
                }
                byte[] binInput = Hex2Bytes(hexInput);
                var binOutput = DecryptBinary(binInput);
                result = Encoding.UTF8.GetString(binOutput);
            }
            catch { }
            return result;
        }
        #endregion


        Task _loadPasswordAsync(bool closeApp=false, Action additionalAction=default)
        {
            
            PasswordF passwordF = new PasswordF();
            if (passwordF.ShowDialog() == DialogResult.OK)
            {
                _password = passwordF.Password;
                string hashPassword = sha256(_password,_accountFile?.LastWriteTimeUtc.Ticks??0);
                _dlg.Execute(ts_status, () => ts_status_lab_password.Text = $"{hashPassword}");

                additionalAction?.Invoke();
            }
            else
            {
                if (closeApp)
                {
                    _dlg.Execute(this, Close);
                }
               
            }
            return Task.CompletedTask;
        }

        List<AccountInfo> _GetAccounts()
        {
            _accounts = new Dictionary<long, AccountInfo>();
            _dlg.Execute(ts_menu, () => ts_menu_com_url.Items.Clear());
            try
            {
                _urls = new List<string>();
                List<string> urls = new List<string>() {"-- All --"};
                if (_accountFile.Exists)
                {
                    string json = File.ReadAllText(_accountFile.FullName, Encoding.UTF8);
                    if(!string.IsNullOrWhiteSpace(json))
                    {
                        var accountObjs = JsonConvert.DeserializeObject<List<AccountInfo>>(json);
                        if(accountObjs?.Count > 0)
                        {
                            
                            foreach (var accountObj in accountObjs)
                            {
                                if (!urls.Contains(accountObj.Url, StringComparer.InvariantCultureIgnoreCase))
                                {
                                    urls.Add(accountObj.Url);
                                    _urls.Add(accountObj.Url);
                                }
                                string username = DecryptFromHexString(accountObj.Username);
                                if (username?.Equals("<encrypted>", StringComparison.InvariantCultureIgnoreCase) ?? false)
                                {
                                    accountObj.CanModify = false;
                                }
                                else
                                {
                                    accountObj.CanModify = true;
                                    accountObj.Username = username;
                                    accountObj.Password = DecryptFromHexString(accountObj.Password);
                                    accountObj.Name = DecryptFromHexString(accountObj.Name);
                                    accountObj.Description = DecryptFromHexString(accountObj.Description);
                                    
                                }


                                _accounts[accountObj.ID] = accountObj;
                            }
                            
                        }
                    }
                   
                }
                if (urls.Count > 0)
                {
                    foreach (var url in urls.OrderBy(ite => ite, StringComparer.InvariantCultureIgnoreCase))
                    {
                        
                        _dlg.Execute(ts_menu, () => ts_menu_com_url.Items.Add(url));
                    }
                    _dlg.Execute(ts_menu, () => ts_menu_com_url.SelectedIndex = 0);
                }
            }
            catch (Exception ex)
            {

            }
            return _accounts.Values.ToList();
        }
        void _RefreshList(string url="")
        {
            _dlg.Execute(_chkall, delegate { _chkall.Checked = false; });
            _dlg.ClearDataGridViewRows(dgv_account);
            var accountObjs = _GetAccounts();
            if(!string.IsNullOrWhiteSpace(url) && !url.Equals("-- All --"))
            {
                accountObjs = accountObjs?.Where(ite => url.Equals(ite.Url, StringComparison.InvariantCultureIgnoreCase))?.ToList();
            }
           
            if (accountObjs?.Count > 0)
            {
                int idx = 1;
                foreach(var accountObj in accountObjs.OrderBy(ite=>ite.Url,StringComparer.InvariantCultureIgnoreCase)
                    .ThenBy(ite=>ite.Name,StringComparer.InvariantCultureIgnoreCase)
                    .ThenBy(ite=>ite.Username,StringComparer.InvariantCultureIgnoreCase)
                    )
                {
                    if(accountObj.CanModify)
                    {
                        _dlg.AddDataGridViewRow(dgv_account, false, idx
                            ,accountObj.ID
                            , accountObj.Url
                            , _isShown? accountObj.Name:string.Join("", accountObj.Name.Select(c => "*"))
                            , accountObj.Name
                            , _isShown? accountObj.Username : string.Join("", accountObj.Username.Select(c => "*"))
                            , accountObj.Username
                            , _isShown? accountObj.Password : string.Join("", accountObj.Password.Select(c=>"*"))
                            , accountObj.Password
                            , _isShown? accountObj.Description:string.Join("", accountObj.Description.Select(c => "*"))
                            , accountObj.Description
                            );
                    }
                    else
                    {
                        _dlg.AddDataGridViewRow(dgv_account, false, idx, accountObj.ID, accountObj.Url, "<encrypted>", accountObj.Name, "<encrypted>", accountObj.Username, "<encrypted>", accountObj.Password, "<encrypted>", accountObj.Description);
                    }
                    
                    idx++;
                }

            }
        }
       async private void ts_menu_but_add_Click(object sender, EventArgs e)
        {
            try
            {
                AddF addF = new AddF(_urls);
                if(addF.ShowDialog()== DialogResult.OK)
                {
                    if(addF.AccountInfo!=null)
                    {
                        _accounts[addF.AccountInfo.ID] = addF.AccountInfo;
                        await _SaveAccountAsync();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        Task _SaveAccountAsync()
        {
            try
            {
                DateTime utcNow = DateTime.UtcNow;
                string newHashPassword = sha256(_password, utcNow.Ticks);
                _dlg.Execute(ts_status, () => ts_status_lab_password.Text = $"{newHashPassword}");
                if (_accounts?.Count > 0)
                {
                    foreach(var accountObj in _accounts)
                    {
                        if(accountObj.Value.CanModify)
                        {
                            accountObj.Value.Username = EncryptToHexString(accountObj.Value.Username);
                            accountObj.Value.Password = EncryptToHexString(accountObj.Value.Password);
                            accountObj.Value.Name = EncryptToHexString(accountObj.Value.Name);
                            accountObj.Value.Description = EncryptToHexString(accountObj.Value.Description);
                        }
                    }
                    
                }
                string json = JsonConvert.SerializeObject(_accounts.Values, Formatting.Indented);
                File.WriteAllText(_accountFile.FullName, json, Encoding.UTF8);
                File.SetLastWriteTimeUtc(_accountFile.FullName, utcNow);

                _accountFile = new FileInfo(_accountFile.FullName);
                _RefreshList();
            }
            catch// (Exception)
            {

            }
            return Task.CompletedTask;
        }

        private void ts_menu_but_view_Click(object sender, EventArgs e)
        {
            string url = ts_menu_com_url.Text;
            Task.Run(()=> _RefreshList(url));
        }

        private void ts_menu_but_retypepassword_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                _loadPasswordAsync(false,() => _RefreshList(null));
            });
        }

        private void ts_menu_but_edit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = null;
                var rows = _dlg.GetDataGridViewRows(dgv_account);
                if (rows?.Count > 0)
                {
                    selectedRow = rows.FirstOrDefault(ite => ite.Index == _selectedRowIndex);
                    
                }
                if (selectedRow == null)
                {
                    rows = _dlg.GetDataGridViewCheckedRows(dgv_account, "dgv_account_col_chk");
                    selectedRow = rows?.FirstOrDefault();
                }
                if(selectedRow!=null)
                {
                    long id = Convert.ToInt64(selectedRow.Cells["dgv_account_col_id"].Value);
                    AccountInfo accountInfo;
                    _accounts.TryGetValue(id, out accountInfo);
                    if(accountInfo?.CanModify??false)
                    {
                        AddF addF = new AddF(accountInfo, _urls);
                        if(addF.ShowDialog()== DialogResult.OK)
                        {
                            _accounts[addF.AccountInfo.ID] = addF.AccountInfo;
                            Task.Run(_SaveAccountAsync);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You cannot edit this account");
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        bool _isShown;
        private void ts_menu_but_showhide_Click(object sender, EventArgs e)
        {
            try
            {
                _isShown = false;
                if (ts_menu_but_showhide.Text=="Show")
                {
                    ts_menu_but_showhide.Text = "Hide";
                    _isShown = true;
                }
                else
                {
                    ts_menu_but_showhide.Text = "Show";
                }
                var rows = _dlg.GetDataGridViewRows(dgv_account);
                if (rows?.Count > 0)
                {
                    Task.Run(() => _showHideContentAsync(rows, _isShown));
                    
                }

            }
            catch (Exception ex)
            {

            }
            
        }
        Task _showHideContentAsync(List<DataGridViewRow> rows, bool isShown)
        {
            try
            {
                foreach (var row in rows)
                {
                    long id = Convert.ToInt64(row.Cells["dgv_account_col_id"].Value);
                    AccountInfo accountInfo;
                    _accounts.TryGetValue(id, out accountInfo);
                    if (accountInfo?.CanModify ?? false)
                    {
                        if (isShown)
                        {
                            row.Cells["dgv_account_col_username"].Value = row.Cells["dgv_account_col_username_hidden"].Value;
                            row.Cells["dgv_account_col_name"].Value = row.Cells["dgv_account_col_name_hidden"].Value;
                            row.Cells["dgv_account_col_password"].Value = row.Cells["dgv_account_col_password_hidden"].Value;
                            row.Cells["dgv_account_col_description"].Value = row.Cells["dgv_account_col_description_hidden"].Value;
                        }
                        else
                        {
                            row.Cells["dgv_account_col_username"].Value = string.Join("", row.Cells["dgv_account_col_username_hidden"].Value.ToString().Select(c => "*"));
                            row.Cells["dgv_account_col_name"].Value = string.Join("", row.Cells["dgv_account_col_name_hidden"].Value.ToString().Select(c => "*"));
                            row.Cells["dgv_account_col_password"].Value = string.Join("", row.Cells["dgv_account_col_password_hidden"].Value.ToString().Select(c => "*"));
                            row.Cells["dgv_account_col_description"].Value = string.Join("", row.Cells["dgv_account_col_description_hidden"].Value.ToString().Select(c => "*"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Task.CompletedTask;
        }

        private void ts_menu_but_delete_Click(object sender, EventArgs e)
        {
            var rows = _dlg.GetDataGridViewCheckedRows(dgv_account, "dgv_account_col_chk");
            if(rows?.Count > 0)
            {
                if(MessageBox.Show("Do you want to do this?","Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
                {
                    foreach (var row in rows)
                    {
                        long id = Convert.ToInt64(row.Cells["dgv_account_col_id"].Value);
                        if(_accounts.ContainsKey(id))
                        {
                            _accounts.Remove(id);
                        }
                    }
                    Task.Run(_SaveAccountAsync);
                }
            }
        }
    }
}
