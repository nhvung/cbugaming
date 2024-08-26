using game9.Extensions;
using game9.Models;
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
    public partial class DataBindingF : Form
    {
        DelegateProcess _dlg;
        public DataBindingF()
        {
            InitializeComponent();
            _dlg = new DelegateProcess();

#if DEBUG
            ts_menu_txt_filepath.Text = @"c:\code\temp\cbu\Sample.xlsx";
#endif

            dgv_summary.CellContentClick += Dgv_summary_CellContentClick;
        }

        private void Dgv_summary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==3)
            {
                string moduleName = dgv_summary["dgv_summary_col_modulename", e.RowIndex].Value.ToString();
                if(_groupDataObjs?.ContainsKey(moduleName)??false)
                {
                    var dataObjs = _groupDataObjs[moduleName];
                    if(dataObjs?.Count > 0)
                    {
                        ViewChartF viewChartF = new ViewChartF(dataObjs,$"chart {moduleName}");
                        viewChartF.Show();
                    }
                }
            }
        }

        private void ts_menu_but_browsefilepath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog { };
                if(ofd.ShowDialog()== DialogResult.OK)
                {
                    ts_menu_txt_filepath.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_menu_view_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = ts_menu_txt_filepath.Text;
                if(!string.IsNullOrWhiteSpace(filePath))
                {
                    Task.Run(()=> _ViewDataAsync(filePath));
                }
            }
            catch (Exception ex)
            {

            }
        }

        Dictionary<string, List<DataInfo>> _groupDataObjs;
        async Task _ViewDataAsync(string filePath)
        {
            try
            {
                _dlg.ClearDataGridViewRows(dgv_summary);
                var dataObjs = ExcelExtension.LoadData<DataInfo>(filePath);
                if(dataObjs?.Count > 0)
                {
                    _groupDataObjs = dataObjs.GroupBy(ite => ite.ModuleName, StringComparer.InvariantCultureIgnoreCase).ToDictionary(ite => ite.Key, ite => ite.ToList(), StringComparer.InvariantCultureIgnoreCase);

                    int rowIdx = 0;
                    foreach(var grp in _groupDataObjs.OrderBy(ite=>ite.Key,StringComparer.InvariantCultureIgnoreCase))
                    {
                        _dlg.AddDataGridViewRow(dgv_summary, rowIdx + 1, grp.Key, grp.Value.Count, "View");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
