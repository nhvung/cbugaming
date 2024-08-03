using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
        string _selectedUrl;
        FileInfo _configFile;
        long _fileTicks;

        System.Timers.Timer _tmrCheckFileChange;
        
        public AccountListF()
        {
            InitializeComponent();
            _dlg = new DelegateProcess();
            _chkall = _dlg.AddDataGridViewCheckBoxAll(dgv_account, "dgv_account_col_chk");
            _accountFile = new FileInfo($"{Application.StartupPath}/accounts.json");
            _fileTicks = 0;
            _configFile = new FileInfo($"{Application.StartupPath}/config.json");
            _urls = new List<string>();
            var colPassword = dgv_account.Columns["dgv_account_col_password"] as DataGridViewTextBoxColumn;
            
            this.Load += AccountListF_Load;
            dgv_account.CellClick += Dgv_account_CellClick;
            _selectedRowIndex = 0;

            if (!SystemInformation.TerminalServerSession)
            {
                Type dgvType = dgv_account.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgv_account, true, null);
            }
            _tmrCheckFileChange = new System.Timers.Timer(1000);
            _tmrCheckFileChange.Enabled = true;
            _tmrCheckFileChange.Elapsed += _tmrCheckFileChange_Elapsed;
        }

        private void _tmrCheckFileChange_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _tmrCheckFileChange.Stop();
            try
            {
                _accountFile = new FileInfo(_accountFile.FullName);
                if(_accountFile.LastWriteTimeUtc.Ticks > _fileTicks)
                {
                    _fileTicks = _accountFile.LastWriteTimeUtc.Ticks;
                    txt_qs_TextChanged(null, null);
                   
                }
            }
            catch
            {

            }
            _tmrCheckFileChange.Start();
        }

        private void Dgv_account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedRowIndex = e.RowIndex;
            ts_status_lab_row.Text = $"{e.RowIndex + 1}";
            ts_status_lab_column.Text = $"{e.ColumnIndex + 1}";
        }

        int _selectedRowIndex;

        ToolConfigs _toolConfigs;
        private void AccountListF_Load(object sender, EventArgs e)
        {
            if(_configFile.Exists)
            {
                string jsonConfigs = File.ReadAllText(_configFile.FullName, Encoding.UTF8);
                if(!string.IsNullOrWhiteSpace(jsonConfigs))
                {
                    _toolConfigs = JsonConvert.DeserializeObject<ToolConfigs>(jsonConfigs);
                }
            }
            if(_toolConfigs==null)
            {
                _toolConfigs = new ToolConfigs();
            }
            if(_toolConfigs!=null)
            {
                if (string.IsNullOrWhiteSpace(_toolConfigs.SharedAccountFilePath))
                {
                    OpenFileDialog ofd = new OpenFileDialog
                    {
                        Title = "Open shared accounts file",
                        Filter = "Json File|*.json",
                        CheckFileExists = false
                    };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        _toolConfigs.SharedAccountFilePath = ofd.FileName;
                        _accountFile = new FileInfo(ofd.FileName);
                        
                        _SaveConfigs();
                    }
                }
                else
                {
                    _accountFile = new FileInfo(_toolConfigs.SharedAccountFilePath);
                    if(!_accountFile.Exists)
                    {
                        OpenFileDialog ofd = new OpenFileDialog
                        {
                            Title = "Open shared accounts file",
                            Filter = "Json File|*.json",
                            CheckFileExists = false
                        };
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            _toolConfigs.SharedAccountFilePath = ofd.FileName;
                            _accountFile = new FileInfo(ofd.FileName);
                            _dlg.Execute(ts_status, delegate { ts_status_lab_filepath.Text = ofd.FileName; });
                            _SaveConfigs();
                        }
                    }
                }
                _fileTicks = _accountFile.LastWriteTimeUtc.Ticks;
                _dlg.Execute(ts_status, delegate { ts_status_lab_filepath.Text = _accountFile.FullName; });
            }

            Task.Run(delegate { _loadPasswordAsync(true, delegate {
                txt_qs_TextChanged(null, null);
                _tmrCheckFileChange.Start();
            }); });
        }

        void _SaveConfigs()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_toolConfigs);
                File.WriteAllText(_configFile.FullName, json, Encoding.UTF8);
            }
            catch //(Exception)
            {

            }
        }


        Task _loadPasswordAsync(bool closeApp=false, Action additionalAction=default)
        {
            
            PasswordF passwordF = new PasswordF();
            if (passwordF.ShowDialog() == DialogResult.OK)
            {
                _password = passwordF.Password;
                _keyBytes= Modules.Sha256(_password);
                string hashPassword = BitConverter.ToString(_keyBytes).Replace("-", "");
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
                                string password = Modules.DecryptFromHexString(accountObj.Password, _keyBytes);
                                if (password?.Equals("<encrypted>", StringComparison.InvariantCultureIgnoreCase) ?? false)
                                {
                                    accountObj.CanModify = false;
                                }
                                else
                                {
                                    accountObj.CanModify = true;
                                    accountObj.Password = password;
                                    accountObj.Username = Modules.DecryptFromHexString(accountObj.Username, _keyBytes);
                                    accountObj.Name = Modules.DecryptFromHexString(accountObj.Name, _keyBytes);
                                    accountObj.Description = Modules.DecryptFromHexString(accountObj.Description, _keyBytes);

                                }


                                _accounts[accountObj.ID] = accountObj;
                            }
                            
                        }
                    }
                   
                }
                if (urls.Count > 0)
                {
                    int idx = 0, selectedUrlIdx=0;
                    foreach (var url in urls.OrderBy(ite => ite, StringComparer.InvariantCultureIgnoreCase))
                    {
                        
                        _dlg.Execute(ts_menu, () => ts_menu_com_url.Items.Add(url));
                        if(url==_selectedUrl)
                        {
                            _selectedUrl = url;
                            selectedUrlIdx = idx;
                        }
                        idx++;
                    }
                    _dlg.Execute(ts_menu, () => ts_menu_com_url.SelectedIndex = selectedUrlIdx);
                }
            }
            catch (Exception ex)
            {

            }
            return _accounts.Values.ToList();
        }
        object _lockObj = new object();
        void _RefreshList(string url, string nameLike, string userNameLike)
        {
            lock (_lockObj)
            {
                _selectedUrl = url;
                _isShown = false;
                _dlg.Execute(ts_menu, delegate { ts_menu_but_showhide.Text = "Show"; });
                _dlg.Execute(_chkall, delegate { _chkall.Checked = false; });
                _dlg.Execute(dgv_account, delegate {
                    dgv_account.Columns["dgv_account_col_password"].DefaultCellStyle.Font= new Font("Wingdings", 8);
                });
                _dlg.ClearDataGridViewRows(dgv_account);
                var accountObjs = _GetAccounts();
                if (!string.IsNullOrWhiteSpace(url) && !url.Equals("-- All --"))
                {
                    accountObjs = accountObjs?.Where(ite => url.Equals(ite.Url, StringComparison.InvariantCultureIgnoreCase))?.ToList();
                }
                if (!string.IsNullOrWhiteSpace(nameLike))
                {
                    accountObjs = accountObjs?.Where(ite => ite.Name.IndexOf(nameLike, StringComparison.InvariantCultureIgnoreCase) >= 0)?.ToList();
                }
                if (!string.IsNullOrWhiteSpace(userNameLike))
                {
                    accountObjs = accountObjs?.Where(ite => ite.Username.IndexOf(userNameLike, StringComparison.InvariantCultureIgnoreCase) >= 0)?.ToList();
                }

                if (accountObjs?.Count > 0)
                {
                    int idx = 1;
                    foreach (var accountObj in accountObjs.OrderBy(ite => ite.Url, StringComparer.InvariantCultureIgnoreCase)
                        .ThenBy(ite => ite.Name, StringComparer.InvariantCultureIgnoreCase)
                        .ThenBy(ite => ite.Username, StringComparer.InvariantCultureIgnoreCase)
                        )
                    {
                        if (accountObj.CanModify)
                        {
                          int rIdx=  _dlg.AddDataGridViewRow(dgv_account, false, idx
                                , accountObj.ID
                                , accountObj.Url
                                , accountObj.Name
                                , accountObj.Name
                                , accountObj.Username
                                , accountObj.Username
                                , _isShown ? accountObj.Password : Modules.Hidden(accountObj.Password)
                                , accountObj.Password
                                , accountObj.Description
                                , accountObj.Description
                                );
                            _dlg.Execute(dgv_account, delegate {
                                if(_isShown)
                                {
                                    dgv_account["dgv_account_col_password", rIdx].Style.Font = new Font("Arail", 9);
                                }
                                else
                                {
                                    dgv_account["dgv_account_col_password", rIdx].Style.Font = new Font("Wingdings", 8);
                                }
                                
                            });
                        }
                        //else
                        //{
                        //    _dlg.AddDataGridViewRow(dgv_account, false, idx, accountObj.ID, accountObj.Url, accountObj.Name, accountObj.Name, accountObj.Username, accountObj.Username, "<encrypted>", accountObj.Password, accountObj.Description, accountObj.Description);
                        //}

                        idx++;
                    }

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
                if (_accounts?.Count > 0)
                {
                    foreach(var accountObj in _accounts)
                    {
                        if(accountObj.Value.CanModify)
                        {
                            accountObj.Value.Username = Modules.EncryptToHexString(accountObj.Value.Username, _keyBytes);
                            accountObj.Value.Name = Modules.EncryptToHexString(accountObj.Value.Name, _keyBytes);
                            accountObj.Value.Description = Modules.EncryptToHexString(accountObj.Value.Description, _keyBytes);
                            accountObj.Value.Password = Modules.EncryptToHexString(accountObj.Value.Password, _keyBytes);
                        }
                    }
                    
                }
                string json = JsonConvert.SerializeObject(_accounts.Values, Formatting.Indented);
                File.WriteAllText(_accountFile.FullName, json, Encoding.UTF8);
            }
            catch// (Exception)
            {

            }
            return Task.CompletedTask;
        }

        private void ts_menu_but_view_Click(object sender, EventArgs e)
        {
            string url = ts_menu_com_url.Text;
            Task.Run(()=> _RefreshList(url,null,null));
        }

        private void ts_menu_but_retypepassword_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                _loadPasswordAsync(false,() => _RefreshList(null,null,null));
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
                        AddF addF = new AddF(accountInfo, _urls, false);
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
                if(!_isShown)
                {
                    PasswordF passwordF = new PasswordF();
                    if (passwordF.ShowDialog() == DialogResult.OK)
                    {
                        if (passwordF.Password != _password)
                        {
                            MessageBox.Show("Password is incorrect.");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                
                _isShown = false;

                if (ts_menu_but_showhide.Text == "Show")
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
                            row.Cells["dgv_account_col_password"].Style.Font = new Font("Arial", 9);
                            row.Cells["dgv_account_col_password"].Value = row.Cells["dgv_account_col_password_hidden"].Value;
                        }
                        else
                        {
                            row.Cells["dgv_account_col_password"].Style.Font = new Font("Wingdings", 8);
                            row.Cells["dgv_account_col_password"].Value = Modules.Hidden(row.Cells["dgv_account_col_password"].Value.ToString());
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

        private void ts_menu_but_clone_Click(object sender, EventArgs e)
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
                if (selectedRow != null)
                {
                    long id = Convert.ToInt64(selectedRow.Cells["dgv_account_col_id"].Value);
                    AccountInfo accountInfo;
                    _accounts.TryGetValue(id, out accountInfo);
                    if (accountInfo != null)
                    {
                        AddF addF = new AddF(accountInfo, _urls, true);
                        if (addF.ShowDialog() == DialogResult.OK)
                        {
                            _accounts[addF.AccountInfo.ID] = addF.AccountInfo;
                            Task.Run(_SaveAccountAsync);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ts_menu_but_updatepassword_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Do you want to change the password?","Change password", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    PasswordF passwordF = new PasswordF();
                    if (passwordF.ShowDialog() == DialogResult.OK)
                    {
                        string newPassword = passwordF.Password;
                        var accounts = _GetAccounts();
                        _keyBytes = Modules.Sha256(newPassword);
                        _password = newPassword;
                        string hashPassword = BitConverter.ToString(_keyBytes).Replace("-", "");
                        _dlg.Execute(ts_status, () => ts_status_lab_password.Text = $"{hashPassword}");
                        Task.Run(_SaveAccountAsync);
                    }
                }
                
            }
            catch (Exception)
            {

            }
        }

        private void txt_qs_TextChanged(object sender, EventArgs e)
        {

            _dlg.Execute(this, delegate {
                string nameLike = txt_qs_name.Text;
                string userNameLike = txt_qs_username.Text;
                string url = ts_menu_com_url.Text;
                _RefreshList(url, nameLike, userNameLike);
            });
        }

        private void but_qs_clear_Click(object sender, EventArgs e)
        {
            txt_qs_name.Text = txt_qs_username.Text = "";
            txt_qs_TextChanged(sender, e);
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open shared accounts file",
                Filter = "Json File|*.json",
                CheckFileExists = false
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _toolConfigs.SharedAccountFilePath = ofd.FileName;
                _accountFile = new FileInfo(ofd.FileName);
                _dlg.Execute(ts_status, delegate { ts_status_lab_filepath.Text = ofd.FileName; });
                _SaveConfigs();
            }
        }
    }
}
