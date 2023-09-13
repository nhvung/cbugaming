using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game5
{
    public partial class InstallF : Form
    {
        DelegateProcess _dlg;
        bool _hasChange;
        public InstallF()
        {
            InitializeComponent();
            _dlg = new DelegateProcess();
        }

        private void but_exepathbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "EXE file|*.exe";
            if(ofd.ShowDialog()== DialogResult.OK)
            {
                txt_exepath.Text = ofd.FileName;
            }
        }

        private void but_install_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFilePath = txt_exepath.Text;
                string serviceName = txt_name.Text;
                Task.Run(() => _installService(exeFilePath, serviceName));
            }
            catch
            {

            }
        }
        void _installService(string exeFilePath, string serviceName)
        {
            try
            {
                _hasChange = false;
                if (!string.IsNullOrWhiteSpace(exeFilePath) && !string.IsNullOrWhiteSpace(serviceName))
                {
                    FileInfo exeFile = new FileInfo(exeFilePath);
                    if (exeFile.Exists)
                    {
                        _dlg.Execute(lab_status, () => lab_status.Text = $"Installing service {serviceName}");
                        string args = $"create {serviceName} binPath= \"{exeFile.FullName}\" type= own start= auto";
                        CLIExtension.Execute("sc.exe", new List<string>() { args }, false);
                        _dlg.Execute(lab_status, () => lab_status.Text = $"Done");
                        _hasChange = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            if (_hasChange)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
