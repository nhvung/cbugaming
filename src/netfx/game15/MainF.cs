using CefSharp;
using CefSharp.WinForms;
using game15.Models;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game15
{
    public partial class MainF : Form
    {
        readonly DelegateProcess _dlg = new DelegateProcess();
        FileInfo _configFile;
        ConfigInfo _configObj;
        Process _pJira;
        public MainF()
        {
            InitializeComponent();
            Cef.Initialize(new CefSettings()
            { 
                
            });

           
            _configFile = new FileInfo($"{Application.StartupPath}/configs.json");
            _loadConfig();
            Task.Run(_loadJiraWeb);
            FormClosed += MainF_FormClosed;
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
                if (_configObj != null)
                {
                    _dlg.SetText(this, _configObj.Title ?? "");                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MainF_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_pJira != null)
            {
                try
                {
                    _pJira.Kill();
                }
                catch 
                {

                }
            }
            Environment.Exit(0);
        }

        void _loadJiraWeb()
        {
            try
            {
                DirectoryInfo jiraFolder = new DirectoryInfo($"{Application.StartupPath}/Jira");
                if(jiraFolder.Exists)
                {
                    ProcessStartInfo psi = new ProcessStartInfo($"{jiraFolder.FullName}/jiraservice.exe");
                    psi.Arguments = string.Join(" ", "--tlog=1",$"-d \"{jiraFolder.FullName.Replace("\\","/")}\"");
                    psi.WorkingDirectory = jiraFolder.FullName;
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    _pJira = Process.Start(psi);
                }
                
                _dlg.Execute(wb_main, delegate {
                    //Thread.Sleep(3000);
                    wb_main.LoadUrl("http://localhost:4131/jira/story");
                    
                });
            }
            catch (Exception)
            {

            }
        }

    }
}
