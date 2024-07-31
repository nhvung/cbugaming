using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game8
{
    public partial class AddF : Form
    {
        AccountInfo _accountInfo;
        public AccountInfo AccountInfo { get { return _accountInfo; } }
        long _account_ID;
        public AddF(List<string> urls)
        {
            InitializeComponent();
            _accountInfo = new AccountInfo();
#if DEBUG
            _accountInfo = new AccountInfo(true);
#endif
            if (_accountInfo != null)
            {
                com_url.Text = _accountInfo.Url;
                txt_username.Text = _accountInfo.Username;
                txt_password.Text = _accountInfo.Password;
                txt_name.Text = _accountInfo.Name;
                rtxt_description.Text = _accountInfo.Description;
            }
            but_ok.Text = lab_title.Text = Text = "Add";
            
            if (urls?.Count > 0)
            {
                foreach (var url in urls)
                {
                    com_url.Items.Add(url);
                }
            }
        }
        public AddF(AccountInfo accountInfo, List<string> urls)
        {
            InitializeComponent();
            _accountInfo = accountInfo;
            if(_accountInfo != null)
            {
                _account_ID = accountInfo.ID;
                com_url.Text = _accountInfo.Url;
                txt_username.Text = _accountInfo.Username;
                txt_password.Text = _accountInfo.Password;
                txt_name.Text = _accountInfo.Name;
                rtxt_description.Text = _accountInfo.Description;
            }
            but_ok.Text = lab_title.Text = Text = "Update";
            if(urls?.Count > 0)
            {
                foreach(var url in urls)
                {
                    com_url.Items.Add(url);
                }
            }
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            string url = com_url.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;
            string name = txt_name.Text;
            string description = rtxt_description.Text;

            _accountInfo = new AccountInfo { 
                ID = _account_ID,
                Url =url,
                Username=username,
                Password=password,
                Name=name,
                Description=description,
                CanModify=true
            };
            if(_accountInfo.ID <= 0)
            {
                _accountInfo.ID = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }

            DialogResult = DialogResult.OK;
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void chk_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = !chk_showpassword.Checked;
        }
    }
}
