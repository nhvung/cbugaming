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

namespace game11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

#if DEBUG
            txt_filepath.Text = @"c:\code\cbugaming\temp\addresses.csv";
#endif
        }

        private void but_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { 
            Filter = "CSV File | *.csv"
            };
            if(ofd.ShowDialog()== DialogResult.OK)
            {
                txt_filepath.Text = ofd.FileName;
            }
        }

        private void but_count_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = txt_filepath.Text;
                string words = rtxt_words.Text;
                string[] pWords = words?.Split(new char[] { ',', ';',' ','\n','\r' }, StringSplitOptions.RemoveEmptyEntries)?.Distinct(StringComparer.InvariantCultureIgnoreCase)?.ToArray();
                bool ignoreCase = chk_ignorecase.Checked;
                if(!string.IsNullOrWhiteSpace(filePath) && pWords?.Length>0)
                {
                    FileInfo file = new FileInfo(filePath);
                    if(file.Exists)
                    {
                        List<CountInfo> countObjs = new List<CountInfo>();
                        using (var sr = new StreamReader(file.FullName, Encoding.UTF8))
                        {
                            string line = null;
                            int lineIdx = 1;
                            
                            while((line=sr.ReadLine())!=null)
                            {
                                List<string> wordCount = new List<string>();
                                foreach(var word in pWords)
                                {
                                    int count = _countWord(line, word, ignoreCase);
                                    CountInfo countObj = new CountInfo(lineIdx, word, count);
                                    countObjs.Add(countObj);
                                }
                                
                                lineIdx++;
                            }
                            sr.Close();
                        }

                        var groupWordCountObjs = countObjs.GroupBy(ite => new { ite.Word, ite.WordCount });
                        List<string> resultLines = new List<string>();
                        foreach(var grpObj in groupWordCountObjs)
                        {
                            int lineCount = grpObj.Count();
                            if(lineCount>0 && grpObj.Key.WordCount>0)
                            {
                                resultLines.Add($"Number of  using {grpObj.Key.WordCount} {grpObj.Key.Word} : {lineCount}");
                            }
                            
                        }

                        rtxt_result.Text = string.Join(Environment.NewLine, resultLines);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int _countWord(string line, string word, bool ignoreCase)
        {
            int result = 0;
            try
            {
                StringComparison stringComparison = ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                int wIdx = 0, idx = 0;
                int wordLen = word.Length;
                while((idx = line.IndexOf(word, wIdx, stringComparison))>=0)
                {
                    wIdx = idx+wordLen;
                    result++;
                }
            }
            catch
            {

            }
            return result;
        }
    }
}
