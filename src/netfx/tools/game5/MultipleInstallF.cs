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
    public partial class MultipleInstallF : Form
    {
        bool _hasChange;
        DelegateProcess _dlg;
        public MultipleInstallF()
        {
            InitializeComponent();
            _hasChange = false;
            _dlg = new DelegateProcess();
        }

        private void but_srcfolderpathbrowse_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                txt_srcfolderpath.Text = cofd.FileName;
                try
                {
                    DirectoryInfo folder = new DirectoryInfo(cofd.FileName);
                    var exeFiles = folder.GetFiles("*.exe");
                    if (exeFiles?.Length > 0)
                    {
                        var exeFile = exeFiles.FirstOrDefault();
                        txt_exepath.Text = exeFile.Name;
                    }
                }
                catch { }

            }
        }

        private void but_rootservicesfolderpathbrowse_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                txt_rootservicesfolderpath.Text = cofd.FileName;
            }
        }

        private void but_install_Click(object sender, EventArgs e)
        {
            var lines = rtxt_servicenames.Lines;
            var srcFolderPath = txt_srcfolderpath.Text;
            var exePath = txt_exepath.Text;
            var rootServicesFolderPath = txt_rootservicesfolderpath.Text;
            Task.Run(delegate { _installService(srcFolderPath, exePath, rootServicesFolderPath, lines); });
        }

        private void but_exepathbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "EXE file|*.exe";
            ofd.InitialDirectory = txt_srcfolderpath.Text;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_exepath.Text = ofd.FileName;
            }
        }

        void _installService(string exeFilePath, string serviceName)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(exeFilePath) && !string.IsNullOrWhiteSpace(serviceName))
                {
                    FileInfo exeFile = new FileInfo(exeFilePath);
                    if (exeFile.Exists)
                    {
                        string args = $"create {serviceName} binPath= \"{exeFile.FullName}\" type= own start= auto";
                        CLIExtension.Execute("sc.exe", new List<string>() { args }, false);
                        _hasChange = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void _installService(string srcFolderPath, string exeFileName, string rootServicesFolderPath, string[] lines)
        {
            _hasChange = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(srcFolderPath) && !string.IsNullOrWhiteSpace(rootServicesFolderPath))
                {
                    var names = lines.Where(ite => !string.IsNullOrWhiteSpace(ite.Trim(' '))).ToList();
                    if (names?.Count > 0)
                    {
                        VSSystem.IO.ExcludeCondition excludeCondition = VSSystem.IO.ExcludeCondition.ServiceExcludeCondition();
                        DirectoryInfo srcFolder = new DirectoryInfo(srcFolderPath);
                        DirectoryInfo rootServicesFolder = new DirectoryInfo(rootServicesFolderPath);
                        ServiceProcess sp = new ServiceProcess();
                        if (srcFolder.Exists && rootServicesFolder.Exists)
                        {
                            foreach (var name in names)
                            {
                                try
                                {
                                    sp.ActionService(name, VSSystem.Management.Models.EAction.Stop);


                                    DirectoryInfo serviceFolder = new DirectoryInfo($"{rootServicesFolder.FullName}/{name}");

                                    _dlg.Execute(rtxt_logs, delegate { rtxt_logs.AppendText($"Clone service {name}{Environment.NewLine}"); });
                                    VSSystem.IO.Extensions.DirectoryInfoExtension.CopyTo(srcFolder, serviceFolder, excludeCondition);


                                    _dlg.Execute(rtxt_logs, delegate { rtxt_logs.AppendText($"Install service {name}{Environment.NewLine}"); });

                                    string exePath = $"{serviceFolder.FullName}/{exeFileName}";
                                    _installService(exePath, name);

                                    _dlg.Execute(rtxt_logs, delegate
                                    {
                                        rtxt_logs.AppendText($"Install service {name} done.{Environment.NewLine}{Environment.NewLine}");
                                        rtxt_logs.SelectionStart = rtxt_logs.Text.Length;
                                        rtxt_logs.ScrollToCaret();
                                    });
                                }
                                catch
                                {
                                }

                            }
                        }
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
