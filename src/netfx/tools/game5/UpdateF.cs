using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSSystem.Management.Windows;

namespace game5
{
    public partial class UpdateF : Form
    {
        bool _hasUpdate;
        List<KeyValuePair<string,string>> _serviceObjs;
        DelegateProcess _dlg;
        public UpdateF(List<KeyValuePair<string, string>> serviceObjs)
        {
            InitializeComponent();
            _hasUpdate = false;
            _serviceObjs = serviceObjs;
            _dlg = new DelegateProcess();
            Task.Run(_load);
        }

        void _load()
        {            
            try
            {
                _dlg.ClearDataGridViewRows(dgv_service);
                if (_serviceObjs?.Count > 0)
                {
                    int idx = 1;
                    foreach(var serviceObj in _serviceObjs)
                    {
                        _dlg.AddDataGridViewRow(dgv_service, idx++, serviceObj.Key, serviceObj.Value, "-");
                        
                    }
                }
            }
            catch
            {
            }
           
        }

        private void but_srcfolderpathbrowse_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                txt_srcfolderpath.Text = cofd.FileName;

            }
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            if(_hasUpdate)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void but_update_Click(object sender, EventArgs e)
        {
            var rowObjs = _dlg.GetDataGridViewRows(dgv_service);
            string srcFolderPath = txt_srcfolderpath.Text;
            if (rowObjs?.Count > 0 && !string.IsNullOrWhiteSpace(srcFolderPath))
            {
                DirectoryInfo srcFolder = new DirectoryInfo(srcFolderPath);
                if(srcFolder.Exists)
                {
                    Task.Run(delegate { _update(srcFolder, rowObjs); });
                }
                
            }
        }
        void _update(DirectoryInfo srcFolder, List<DataGridViewRow> rowObjs)
        {
            try
            {
                ServiceProcess sp = new ServiceProcess();
                var exclude = VSSystem.IO.ExcludeCondition.ServiceExcludeCondition();
                foreach(var rowObj in rowObjs)
                {
                    var serviceName = rowObj.Cells["dgv_service_col_name"].Value.ToString();
                    var serviceFolderPath = rowObj.Cells["dgv_service_col_folder_path"].Value.ToString();
                    if(!string.IsNullOrWhiteSpace(serviceFolderPath) && Directory.Exists(serviceFolderPath))
                    {
                        DirectoryInfo serviceFolder = new DirectoryInfo(serviceFolderPath);

                        var status = sp.GetServiceStatus(serviceName);

                        

                        if(status == VSSystem.Management.Models.EStatus.Running)
                        {
                            rowObj.Cells["dgv_service_col_status"].Value = "Stopping...";
                            sp.ActionService(serviceName, VSSystem.Management.Models.EAction.Stop);

                            rowObj.Cells["dgv_service_col_status"].Value = "Updating...";
                            VSSystem.IO.Extensions.DirectoryInfoExtension.SynchronizeFolder(srcFolder, serviceFolder, false, exclude);

                            rowObj.Cells["dgv_service_col_status"].Value = "Restarting...";
                            sp.ActionService(serviceName, VSSystem.Management.Models.EAction.Start);
                        }
                        else
                        {
                            rowObj.Cells["dgv_service_col_status"].Value = "Updating...";
                            VSSystem.IO.Extensions.DirectoryInfoExtension.SynchronizeFolder(srcFolder, serviceFolder, false, exclude);
                        }

                        rowObj.Cells["dgv_service_col_status"].Value = "Done";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
