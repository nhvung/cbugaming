using game16.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game16
{
    public partial class MainF : Form
    {
        FileInfo _configFile;
        ConfigInfo _configObj;
        DelegateProcess _dlg;
        Dictionary<string, Process> _mProcess;
        readonly object _lockObj = new object();
        public MainF()
        {
            InitializeComponent();
            _mProcess = new Dictionary<string, Process>(StringComparer.InvariantCultureIgnoreCase);

            FormClosed += MainF_FormClosed;
            FormClosing += MainF_FormClosing;
            _configFile = new FileInfo($"{Application.StartupPath}/configs.json");
            _dlg = new DelegateProcess();
            _loadConfig();
            _loadUI();

            dgv_clone.CellContentClick += Dgv_clone_CellContentClick;
           
        }

        

        private void Dgv_clone_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string cValue = dgv_clone["dgv_clone_run", e.RowIndex].Value.ToString();
                string cGuid = dgv_clone["dgv_clone_guid", e.RowIndex].Value.ToString();
                if (cValue?.Equals("Run", StringComparison.InvariantCultureIgnoreCase) ?? false)
                {
                    string folderPath = dgv_clone["dgv_clone_path", e.RowIndex].Value.ToString();
                    string exeFileName = dgv_clone["dgv_clone_executefile", e.RowIndex].Value.ToString();
                    FileInfo exeFile = new FileInfo($"{folderPath}/{exeFileName}");

                    if (exeFile.Exists)
                    {
                        Task.Run(delegate
                        {
                            lock (_lockObj)
                            {
                                
                                _mProcess[cGuid] = _createProcess(exeFile);
                            }
                            _dlg.SetDataGridViewValue(dgv_clone, e.RowIndex, "dgv_clone_run", "Kill");
                        });

                    }
                    else
                    {
                        MessageBox.Show($"{exeFile.FullName} cannot found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cValue?.Equals("Kill", StringComparison.InvariantCultureIgnoreCase) ?? false)
                {
                    Process p;
                    _mProcess.TryGetValue(cGuid, out p);
                    if (p != null)
                    {
                        try { p.Kill(); } catch { }
                        _dlg.SetDataGridViewValue(dgv_clone, e.RowIndex, "dgv_clone_run", "Run");
                        lock (_lockObj)
                        {
                            _mProcess.Remove(cGuid);
                        }
                    }
                }
            }
        }

        Process _createProcess(FileInfo file)
        {
            return Process.Start(file.FullName);
        }
        private void MainF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mProcess.Count > 0)
            {
                foreach (var p in _mProcess)
                {
                    try
                    {
                        p.Value.Kill();
                    }
                    catch { }
                }
            }
        }
        private void MainF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);           
        }
        void _loadConfig()
        {
            try
            {
                if (!_configFile.Exists)
                {
                    File.WriteAllText(_configFile.FullName, "");
                }
                if (_configFile.Exists)
                {
                    string jsonConfig = File.ReadAllText(_configFile.FullName, Encoding.UTF8);
                    if (!string.IsNullOrWhiteSpace(jsonConfig))
                    {
                        _configObj = JsonConvert.DeserializeObject<ConfigInfo>(jsonConfig);
                    }
                }
                if (_configObj == null)
                {
                    _configObj = new ConfigInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void _loadUI()
        {
            try
            {
                _dlg.ClearDataGridViewRows(dgv_clone);
                if (_configObj != null)
                {
                    _dlg.SetText(this, _configObj.Title ?? "");
                    _dlg.SetText(txt_srcfolderpath, _configObj.SourceFolderPath ?? "");
                    _dlg.SetText(txt_clonefolderpath, _configObj.CloneFolderPath ?? "");
                    _dlg.SetText(txt_clonenameformat, _configObj.CloneNameFormat ?? "");
                    _dlg.SetText(txt_numberofclone, _configObj.NumberOfClones.ToString() ?? "");
                    _dlg.SetText(txt_defaultexefilename, _configObj.DefaultExecuteFileName ?? "");

                    if(_configObj.CloneItems?.Count > 0)
                    {
                        int rIdx = 1;
                        foreach(var cloneItem in _configObj.CloneItems.OrderBy(ite=>ite.Path,StringComparer.InvariantCultureIgnoreCase))
                        {
                            DirectoryInfo folder = new DirectoryInfo(cloneItem.Path);
                            if(folder.Exists)
                            {
                                string guid = cloneItem.Guid;
                                if(string.IsNullOrWhiteSpace(guid))
                                {
                                    guid = cloneItem.Guid = Guid.NewGuid().ToString().ToLower();
                                }
                                string buttonText = "Run";
                                if(_mProcess.ContainsKey(guid))
                                {
                                    buttonText = "Kill";
                                }
                                _dlg.AddDataGridViewRow(dgv_clone, rIdx++, guid, folder.Name, folder.FullName.Replace("\\", "/"), cloneItem.ExecuteFile, buttonText);
                               
                            }
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        void _loadCloneFolder(string cloneFolderPath, string defaultExeFileName)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cloneFolderPath))
                {
                    DirectoryInfo rootFolder = new DirectoryInfo(cloneFolderPath);
                    if (rootFolder.Exists && _configObj != null)
                    {
                        bool hasChanged = false;
                        if (_configObj.CloneItems == null)
                        {
                            _configObj.CloneItems = new List<ClonePathInfo>();
                        }
                        var subFolders = rootFolder.GetDirectories();
                        foreach (var subFolder in subFolders)
                        {
                            string folderPath = subFolder.FullName.Replace("\\", "/");
                            FileInfo exeFile = new FileInfo($"{subFolder.FullName}/{defaultExeFileName}");
                            if (exeFile.Exists)
                            {
                                ClonePathInfo pathObj = _configObj.CloneItems.FirstOrDefault(ite => ite.Path.Equals(folderPath, StringComparison.InvariantCultureIgnoreCase));
                                if (pathObj == null)
                                {
                                    pathObj = new ClonePathInfo(Guid.NewGuid().ToString().ToLower(), folderPath, defaultExeFileName);
                                    _configObj.CloneItems.Add(pathObj);
                                    hasChanged = true;
                                }
                            }
                        }
                        if(hasChanged)
                        {
                            _configObj.DefaultExecuteFileName = defaultExeFileName;
                            _updateConfig();
                            _loadUI();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ts_menu_but_reloadconfig_Click(object sender, EventArgs e)
        {
            _loadConfig();
            _loadUI();
        }
        void _updateConfig()
        {
            try
            {
                string jsonConfigs = JsonConvert.SerializeObject(_configObj, Formatting.Indented);
                File.WriteAllText(_configFile.FullName, jsonConfigs, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void but_srcfolderpathbrowse_Click(object sender, EventArgs e)
        {

            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                string path = cofd.FileName.Replace("\\", "/");
                _configObj.SourceFolderPath = txt_srcfolderpath.Text = path;
                _updateConfig();
            }
        
        }

        private void but_clonefolderpathbrowse_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                string path = cofd.FileName.Replace("\\", "/");
                _configObj.CloneFolderPath = txt_clonefolderpath.Text = path;
                _updateConfig();
            }
        }

        private void but_clone_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to do this?", "CLONE CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string srcFolderPath = txt_srcfolderpath.Text;
                    DirectoryInfo srcFolder = new DirectoryInfo(srcFolderPath);
                    string cloneFolderPath = txt_clonefolderpath.Text;
                    DirectoryInfo cloneFolder = new DirectoryInfo(cloneFolderPath);
                    int nClones;
                    int.TryParse(txt_numberofclone.Text, out nClones);
                    if (nClones <= 0)
                    {
                        nClones = 1;
                    }
                    string cloneNameFormat = txt_clonenameformat.Text;
                    if (string.IsNullOrWhiteSpace(cloneNameFormat))
                    {
                        cloneNameFormat = "{0}_Staging{1:00}";
                    }
                    string defaultExeFileName = txt_defaultexefilename.Text;
                    if (string.IsNullOrWhiteSpace(defaultExeFileName))
                    {
                        defaultExeFileName = "FunctionCheck.exe";
                    }
                    Task.Run(delegate { _clone(srcFolder, cloneFolder, nClones, cloneNameFormat, defaultExeFileName); });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void _clone(DirectoryInfo srcFolder, DirectoryInfo cloneFolder, int nClones, string cloneNameFormat, string defaultExeFileName)
        {
            try
            {
                if (srcFolder.Exists)
                {
                    try
                    {
                        _configObj.NumberOfClones = nClones;
                        _configObj.CloneNameFormat = cloneNameFormat;
                        _configObj.DefaultExecuteFileName = defaultExeFileName;
                        _updateConfig();
                    }
                    catch
                    {
                    }
                    _dlg.AppendText(rtxt_logs, $"Cloning folder {srcFolder.Name} to...");
                    List<ClonePathInfo> cloneInfoObjs = new List<ClonePathInfo>();
                    for (int i = 0; i < nClones; i++)
                    {
                        string destinationFolderPath = cloneFolder.FullName.Replace("\\", "/") + "/" + string.Format(cloneNameFormat, srcFolder.Name, i + 1);
                        DirectoryInfo destFolder = new DirectoryInfo(destinationFolderPath);
                        try
                        {
                            _dlg.AppendText(rtxt_logs, $"{destFolder.Name}...");
                            VSSystem.IO.Extensions.DirectoryInfoExtension.CopyTo(srcFolder, destFolder,null,log=>_dlg.AppendText(rtxt_logs, log));
                            ClonePathInfo cloneInfoObj = new ClonePathInfo
                            {
                                Path = destFolder.FullName.Replace("\\", "/"),
                                ExecuteFile = defaultExeFileName,
                                Guid = Guid.NewGuid().ToString().ToLower()
                            };
                            _dlg.AppendText(rtxt_logs, $"{destFolder.Name} done.");
                            cloneInfoObjs.Add(cloneInfoObj);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (cloneInfoObjs.Count > 0)
                    {
                        _configObj.CloneItems = cloneInfoObjs;
                        _updateConfig();
                        _loadUI();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void but_runall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to do this?", "RUN ALL CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    List<string> errLogs = new List<string>();
                    var rowObjs = _dlg.GetDataGridViewRows(dgv_clone);
                    foreach (var rowObj in rowObjs)
                    {
                        string cValue = rowObj.Cells["dgv_clone_run"].Value.ToString();
                        string cGuid = rowObj.Cells["dgv_clone_guid"].Value.ToString();
                        if (cValue?.Equals("Run", StringComparison.InvariantCultureIgnoreCase) ?? false)
                        {
                            string folderPath = rowObj.Cells["dgv_clone_path"].Value.ToString();
                            string exeFileName = rowObj.Cells["dgv_clone_executefile"].Value.ToString();
                            FileInfo exeFile = new FileInfo($"{folderPath}/{exeFileName}");
                            if (exeFile.Exists)
                            {
                                Task.Run(delegate {
                                    lock (_lockObj)
                                    {
                                        _mProcess[cGuid] = _createProcess(exeFile);
                                    }
                                    _dlg.SetDataGridViewValue(dgv_clone, rowObj.Index, "dgv_clone_run", "Kill");
                                });
                            }
                            else
                            {
                                errLogs.Add($"{exeFile.FullName} cannot found.");
                            }
                        }
                    }
                    if(errLogs?.Count > 0)
                    {
                        MessageBox.Show(string.Join(Environment.NewLine+ Environment.NewLine, errLogs),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void but_killall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to do this?", "KILL ALL CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var rowObjs = _dlg.GetDataGridViewRows(dgv_clone);
                    foreach (var rowObj in rowObjs)
                    {
                        string cValue = rowObj.Cells["dgv_clone_run"].Value.ToString();
                        string cGuid = rowObj.Cells["dgv_clone_guid"].Value.ToString();
                        if (cValue?.Equals("Kill", StringComparison.InvariantCultureIgnoreCase) ?? false)
                        {
                            Process p;
                            _mProcess.TryGetValue(cGuid, out p);
                            if (p != null)
                            {
                                try { p.Kill(); } catch { }
                                lock (_lockObj)
                                {
                                    _mProcess.Remove(cGuid);
                                }
                                _dlg.SetDataGridViewValue(dgv_clone, rowObj.Index, "dgv_clone_run", "Run");
                            }                        
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
        }

        private void but_removeallclones_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to do this?", "REMOVE ALL CLONES CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var rowObjs = _dlg.GetDataGridViewRows(dgv_clone);
                    foreach (var rowObj in rowObjs)
                    {
                        string folderPath = rowObj.Cells["dgv_clone_path"].Value.ToString();
                        DirectoryInfo folder = new DirectoryInfo(folderPath);
                        
                        if (folder.Exists)
                        {
                            Task.Run(delegate {
                                try { VSSystem.IO.Extensions.DirectoryInfoExtension.Empty(folder, true); } catch { }
                            });
                        }
                    }
                    _configObj.CloneItems = new List<ClonePathInfo>();
                    _updateConfig();
                    _loadUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void but_clearlog_Click(object sender, EventArgs e)
        {
            _dlg.SetText(rtxt_logs, "");
        }

        private void but_reloadclonefolder_Click(object sender, EventArgs e)
        {
            string cloneFolderPath = txt_clonefolderpath.Text;
            string defaultExeFileName = txt_defaultexefilename.Text;
            if (string.IsNullOrWhiteSpace(defaultExeFileName))
            {
                defaultExeFileName = _configObj?.DefaultExecuteFileName;
            }
            if (string.IsNullOrWhiteSpace(defaultExeFileName))
            {
                defaultExeFileName = "FunctionCheck.exe";
            }
            if (!string.IsNullOrWhiteSpace(cloneFolderPath) && !string.IsNullOrWhiteSpace(defaultExeFileName))
            {
                if(MessageBox.Show("By action, the configuration of clone folder can be changed. Do you want to do this?", "RELOAD WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
                {
                    Task.Run(delegate { _loadCloneFolder(cloneFolderPath, defaultExeFileName); });
                }
            }
           
        }
    }
}
