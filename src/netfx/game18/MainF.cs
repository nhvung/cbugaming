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
using VSSystem;
using VSSystem.IO;

namespace game18
{
    public partial class MainF : Form
    {

        public MainF()
        {
            InitializeComponent();

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
                    headers = new string[] { "VerhicleType", "Plate", "RegState", "Make", "Model", "Color" };

                }

                var comparer = CsvDataInfo.Comparer;
                var sampleData = CsvFile.ReadData<CsvDataInfo>(sampleFilePath, headers,1);
                var resultData = CsvFile.ReadData<CsvDataInfo>(resultFilePath, headers,1);

                var innerData = resultData.Join(sampleData, ite => ite, ite => ite, (ite1, ite2) => ite1, comparer)?.ToList()??new List<CsvDataInfo>();

                List<CsvDataInfo> diffData = new List<CsvDataInfo>();
                diffData.AddRange(sampleData.Where(ite => !innerData.Contains(ite, comparer)));
                diffData.AddRange(resultData.Where(ite => !innerData.Contains(ite, comparer)));

                if(diffData.Count > 0)
                {
                    string outputFilePath = $"{resultFile.Directory.FullName}/output.csv";
                    CsvFile.WriteData<CsvDataInfo>(outputFilePath, headers, diffData, true);
                    MessageBox.Show("Finish.");
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
