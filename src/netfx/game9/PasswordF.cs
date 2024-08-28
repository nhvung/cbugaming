using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game9
{
    public partial class PasswordF : Form
    {
        string _defaultPassword;
        bool _accepted;
        public bool Accepted { get { return _accepted; } }
        public PasswordF()
        {
            InitializeComponent();
            _accepted = false;
            _defaultPassword = $"{DateTime.Now.Date:MMddyyyy}7777";

#if DEBUG
            _defaultPassword = "777";
#endif
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            string password = txt_password.Text;
            if(password.Equals(_defaultPassword,StringComparison.InvariantCultureIgnoreCase))
            {
                _accepted = true;
                
                new DataBindingF().Show();
                this.Close();
            } 
            else
            {
                MessageBox.Show("Incorrect password....");
            }
        }
    }
}
