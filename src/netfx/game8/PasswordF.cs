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
    public partial class PasswordF : Form
    {
        string _password;
        public string Password { get { return _password; } }

        public PasswordF()
        {
            InitializeComponent();
        }

        private void chk_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = !chk_showpassword.Checked;
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            _password = txt_password.Text;
            if(string.IsNullOrWhiteSpace(_password))
            {
                MessageBox.Show("Password can not be empty.");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
            
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
