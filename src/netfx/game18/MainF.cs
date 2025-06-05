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
using VSSystem.IO;

namespace game18
{
    public partial class MainF : Form
    {
        ToolConfig _toolConfig;

        public MainF()
        {
            InitializeComponent();

            try
            {
                FileInfo toolConfigFile = new FileInfo($"{Application.StartupPath}/config.json");
                if (!toolConfigFile.Exists)
                {
                    _toolConfig = new ToolConfig();
                    string jsonConfig = JsonConvert.SerializeObject(_toolConfig, Formatting.Indented);
                    File.WriteAllText(toolConfigFile.FullName, jsonConfig, Encoding.UTF8);
                }
                else
                {
                    string jsonConfig = File.ReadAllText(toolConfigFile.FullName, Encoding.UTF8);
                    _toolConfig = JsonConvert.DeserializeObject<ToolConfig>(jsonConfig);
                }

                if(_toolConfig!=null)
                {
                    this.Text = _toolConfig.Title;
                }
            }
            catch
            {

            }

#if DEBUG
            txt_samplefilepath.Text = @"c:\code\temp\cbu\game18\sample.csv";
            txt_resultfilepath.Text = @"c:\code\temp\cbu\game18\result.csv";
#endif
        }

        private void but_samplefilepathbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { 
            Filter = "CSV File (*.csv) | *.csv"
            };
            if(ofd.ShowDialog()== DialogResult.OK)
            {
                txt_samplefilepath.Text = ofd.FileName;
            }
        }

        private void but_resultfilepathbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV File (*.csv) | *.csv"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_resultfilepath.Text = ofd.FileName;
            }
        }

        private void but_execute_Click(object sender, EventArgs e)
        {
            try
            {
                string sampleFilePath = txt_samplefilepath.Text;
                string resultFilePath = txt_resultfilepath.Text;
                
               
                if (string.IsNullOrWhiteSpace(sampleFilePath))
                {
                    MessageBox.Show("Sample file not valid.");
                    return;
                }
                FileInfo sampleFile = new FileInfo(sampleFilePath);
                if (!sampleFile.Exists)
                {
                    MessageBox.Show("Sample file not valid.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(resultFilePath))
                {
                    MessageBox.Show("Result file not valid.");
                    return;
                }
                FileInfo resultFile = new FileInfo(resultFilePath);
                if (!resultFile.Exists)
                {
                    MessageBox.Show("Result file not valid.");
                    return;
                }

                

               
                

                string[] headers = VSSystem.IO.CsvFile.ReadHeader(sampleFilePath);
                if (headers == null||headers.Length == 0)
                {
                    headers = new string[] { "Plate", "Make", "Model", "Color", "VerhicleType", "RegState"};

                }

                var sampleObjs = CsvFile.ReadData<CsvDataInfo>(sampleFilePath, headers,1);
                var samplePlates = sampleObjs.Select(ite => ite.Plate).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
                var resultObjs = CsvFile.ReadData<CsvDataInfo>(resultFilePath, headers,1);

                var diffObjs = new List<CsvDataInfo>();

                foreach (var resultObj in resultObjs)
                {
                    if (samplePlates.Contains(resultObj.Plate, StringComparer.InvariantCultureIgnoreCase))
                    {
                        var sampleObj = sampleObjs.FirstOrDefault(ite => ite.Plate.Equals(resultObj.Plate, StringComparison.InvariantCultureIgnoreCase));
                        var diffObj = resultObj.GetDiff(sampleObj);
                        if(diffObj!=null)
                        {
                            diffObjs.Add(diffObj);
                        }
                    }
                    else
                    {
                        diffObjs.Add(resultObj);
                    }
                }

                

                if(diffObjs.Count > 0)
                {
                    string outputFilePath = $"{resultFile.Directory.FullName}/output.csv";
                    CsvFile.WriteData(outputFilePath, headers, diffObjs, true);
                    MessageBox.Show("Finish.");

                    if (MessageBox.Show("Do you want to view the output?", "Open Output", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        Process.Start(outputFilePath);
                    }
                }
                else
                {
                    MessageBox.Show("2 files are same.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
