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
using VSSystem;

namespace game19
{
    public partial class MainF : Form
    {
        FileInfo _toolConfigFile = null;
        ToolConfig _toolConfig;
        public MainF()
        {
            InitializeComponent();

#if DEBUG
            try
            {
                FileInfo inputFile = new FileInfo(@"c:\custom-data\code\cbugaming\temp\game19\iFolder\input.txt");
                DirectoryInfo inputFolder = new DirectoryInfo($"{inputFile.DirectoryName}/input-folder");
                if(!inputFolder.Exists)
                {
                    inputFolder.Create();
                }
                string[] lines = File.ReadAllLines(inputFile.FullName, Encoding.UTF8);
                if(lines?.Length > 0)
                {
                    foreach(var line in lines)
                    {
                        File.WriteAllBytes($"{inputFolder.FullName}/{line}", new byte[0]);
                    }
                }
            }
            catch
            {

            }
#endif

            try
            {
                _toolConfigFile = new FileInfo($"{Application.StartupPath}/config.json");
                if (!_toolConfigFile.Exists)
                {
                    _toolConfig = new ToolConfig();
                    string jsonConfig = JsonConvert.SerializeObject(_toolConfig, Formatting.Indented);
                    File.WriteAllText(_toolConfigFile.FullName, jsonConfig, Encoding.UTF8);
                }
                else
                {
                    string jsonConfig = File.ReadAllText(_toolConfigFile.FullName, Encoding.UTF8);
                    _toolConfig = JsonConvert.DeserializeObject<ToolConfig>(jsonConfig);
                }

                if (_toolConfig != null)
                {
                    this.Text = _toolConfig.Title;
                    this.txt_inputfolderpath.Text = _toolConfig.InputFolderPath;
                    this.txt_outputfolderpath.Text = _toolConfig.OutputFolderPath;
                    this.txt_aliaspath.Text = _toolConfig.AliasOutputFolderPath;
                }
            }
            catch
            {

            }
        }

        private void but_inputfolderpathbrowse_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                txt_inputfolderpath.Text = cofd.FileName;
            }
        }

        private void but_outputfolderpathbrowse_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                txt_outputfolderpath.Text = cofd.FileName;
            }
        }

        private void but_execute_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFolderPath = txt_inputfolderpath.Text;
                string outputFolderPath = txt_outputfolderpath.Text;
                string aliasPath = txt_aliaspath.Text;

                if (string.IsNullOrEmpty(inputFolderPath))
                {
                    MessageBox.Show("Input folder not valid. Please check again...");
                    return;
                }
                DirectoryInfo inputFolder = new DirectoryInfo(inputFolderPath);
                if (!inputFolder.Exists)
                {
                    MessageBox.Show("Input folder not valid. Please check again...");
                    return;
                }
                if (string.IsNullOrEmpty(outputFolderPath))
                {
                    MessageBox.Show("Please locate the output folder...");
                    return;
                }

                DirectoryInfo outputFolder = new DirectoryInfo(outputFolderPath);
                if (!outputFolder.Exists)
                {
                    outputFolder.Create();
                }

                _toolConfig.InputFolderPath = inputFolderPath;
                _toolConfig.OutputFolderPath = outputFolderPath;
                _toolConfig.AliasOutputFolderPath = aliasPath;
                _toolConfig.Save(_toolConfigFile.FullName);

                FileInfo[] files = inputFolder.GetFiles();
                if (files.Length > 0)
                {
                    List<ItemInfo> itemObjs = new List<ItemInfo>();
                    foreach (var file in files)
                    {
                        try
                        {
                            if(file.Extension.Equals(".txt",StringComparison.InvariantCultureIgnoreCase))
                            {
                                continue;
                            }
                            ItemInfo itemObj = new ItemInfo(file.Name);
                            itemObjs.Add(itemObj);
                        }
                        catch { }
                    }

                    if (itemObjs.Count > 0)
                    {
                        var grpItemObjs = itemObjs.GroupBy(ite => $"{ite.Plate}_{ite.Ticks}", StringComparer.InvariantCultureIgnoreCase).ToList();
                        foreach(var grpItemObj in grpItemObjs)
                        {
                            FileInfo outputFile = new FileInfo($"{outputFolder.FullName}/{grpItemObj.Key}.txt");
                            string[] lines = grpItemObj.Select(ite => $"{aliasPath}/{Path.GetFileName(ite.Path)}").ToArray();
                            File.WriteAllLines(outputFile.FullName, lines, Encoding.UTF8);
                        }
                        if(MessageBox.Show("Finish. Do you want to open the result folder?", "Execution Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if(!string.IsNullOrWhiteSpace(_toolConfig.TotalCmdExePath))
                            {
                                Process.Start(_toolConfig.TotalCmdExePath, $"/o /r \"{outputFolder.FullName}\"" );
                            }
                            else
                            {
                                Process.Start(outputFolder.FullName);
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
    }
}
