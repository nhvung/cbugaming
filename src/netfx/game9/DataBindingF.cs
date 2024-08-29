using game9.Extensions;
using game9.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game9
{
    public partial class DataBindingF : Form
    {
        DelegateProcess _dlg;
        FileInfo _lineChartConfigFile;
        public DataBindingF()
        {
            InitializeComponent();
            _dlg = new DelegateProcess();

            if (!SystemInformation.TerminalServerSession)
            {
                Type dgvType = typeof(DataGridView);
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgv_config_linechart, true, null);
                pi.SetValue(dgv_raw, true, null);
            }

#if DEBUG
            ts_menu_txt_filepath.Text = @"c:\code\temp\cbu\Sample-2.xlsx";
#endif

            dgv_summary.CellContentClick += Dgv_summary_CellContentClick;
            FormClosed += DataBindingF_FormClosed;
#if DEBUG
            ts_menu_view_Click(null, null);
#endif
            dgv_raw.CellMouseClick += Dgv_raw_CellMouseClick;
            dgv_config_linechart.CellMouseClick += Dgv_config_linechart_CellMouseClick;

            _lineChartConfigFile = new FileInfo($"{Application.StartupPath}/lineChartConfig.json");

            dgv_raw_summary.CellContentClick += Dgv_raw_summary_CellContentClick;
        }

        private void Dgv_raw_summary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 3)
                    {
                        string moduleName =dgv_raw_summary["dgv_raw_summary_col_modulename", e.RowIndex].Value.ToString();
                        if (_rawDataObj?.IsValid() ?? false)
                        {
                            ViewChartF viewChartF = new ViewChartF(_rawDataObj, _lineChartConfig,  $"chart {moduleName}");
                            viewChartF.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int _dgv_raw_column_index;
        private void Dgv_raw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if(e.RowIndex == -1)
                {  
                    cms_rawdata.Show(Cursor.Position);
                    _dgv_raw_column_index = e.ColumnIndex;
                }
                
            }
        }

        private void Dgv_config_linechart_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            }
            else
            {
                if (e.ColumnIndex == 4)
                {
                    dgv_config_linechart.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void DataBindingF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Dgv_summary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 3)
                    {
                        string moduleName = dgv_summary["dgv_summary_col_modulename", e.RowIndex].Value.ToString();
                        if (_groupDataObjs?.ContainsKey(moduleName) ?? false)
                        {
                            var dataObjs = _groupDataObjs[moduleName];
                            if (dataObjs?.Count > 0)
                            {
                                ViewChartF viewChartF = new ViewChartF(dataObjs, $"chart {moduleName}");
                                viewChartF.Show();
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

        private void ts_menu_but_browsefilepath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog { };
                if(ofd.ShowDialog()== DialogResult.OK)
                {
                    ts_menu_txt_filepath.Text = ofd.FileName;
                }

                ts_menu_view_Click(sender, e);
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
                    Task.Run(()=> _ViewData(filePath));
                    Task.Run(()=> _ViewDataRaw(filePath));
                }
            }
            catch (Exception ex)
            {

            }
        }

        Dictionary<string, List<DataInfo>> _groupDataObjs;
        void _ViewData(string filePath)
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

        RawDataInfo _rawDataObj;
        void _ViewDataRaw(string filePath)
        {
            try
            {
                _dlg.ClearDataGridViewRows(dgv_raw);
                _dlg.Execute(ts_raw, () => {
                    ts_raw_com_filtercolumn.Items.Clear();
                    ts_raw_com_filtercolumn.Items.Add("ModuleName");
                    ts_raw_com_filtercolumn.SelectedIndex = 0;

                    ts_raw_com_groupcolumn.Items.Clear();
                    ts_raw_com_groupcolumn.Items.Add("DateStart");
                    ts_raw_com_groupcolumn.Items.Add("DateEnd");
                    ts_raw_com_groupcolumn.SelectedIndex = 0;
                });
                _rawDataObj = ExcelExtension.LoadDataRaw(filePath);
                if (_rawDataObj?.IsValid()??false)
                {
                    List<int> timeColIdxes = new List<int>();
                   foreach(var header in _rawDataObj.Headers)
                    {
                        _dlg.AddDataGridViewColumn(dgv_raw, $"dgv_raw_col_{header.Value}", header.Key);
                        if(header.Key.IndexOf("timestart",StringComparison.InvariantCultureIgnoreCase)>=0)
                        {
                            timeColIdxes.Add(header.Value);
                            _dlg.AddDataGridViewColumn(dgv_raw, $"dgv_raw_col_{header.Value}_date", $"Date{header.Key.Substring(4)}");
                        }
                        else if (header.Key.IndexOf("timeend", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            timeColIdxes.Add(header.Value);
                            _dlg.AddDataGridViewColumn(dgv_raw, $"dgv_raw_col_{header.Value}_date", $"Date{header.Key.Substring(4)}");
                        }
                    }
                    foreach(var row in _rawDataObj.Rows)
                    {
                        List<object> objs = new List<object>();
                       for(int i =0;i<row.Count;i++)
                        {
                            objs.Add(row[i]);
                            if(timeColIdxes.Contains(i))
                            {
                                objs.Add(row[i].Substring(0, 10).Trim());
                            }
                        }
                        _dlg.AddDataGridViewRow(dgv_raw, objs.ToArray());
                    }


                   
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ts_menu_viewallcharts_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(var grp in _groupDataObjs)
                {
                    ViewChartF viewChartF = new ViewChartF(grp.Value, $"chart {grp.Key}");
                    viewChartF.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cms_rawdata_addtolinechart_Click(object sender, EventArgs e)
        {
            if(_dgv_raw_column_index>=0)
            {
                var header = dgv_raw.Columns[_dgv_raw_column_index].HeaderText;
                _dlg.AddDataGridViewRow(dgv_config_linechart, header, "", true, true, "Remove");
            }
        }

        LineChartConfig _lineChartConfig;
        private void but_saveconfig_Click(object sender, EventArgs e)
        {
            try
            {
                _dlg.ClearDataGridViewRows(dgv_raw_summary);
                var rowObjs = _dlg.GetDataGridViewRows(dgv_config_linechart);
                if(rowObjs?.Count > 0)
                {
                    string filterColumn = ts_raw_com_filtercolumn.Text;
                    string groupColumn = ts_raw_com_groupcolumn.Text;
                    List<DetailChartConfig> valueColumns = new List<DetailChartConfig>();
                    foreach(var rowObj in rowObjs)
                    {
                        string sColumn = rowObj.Cells["dgv_config_linechart_col_header"].Value.ToString();
                        string sNewColumn = rowObj.Cells["dgv_config_linechart_col_newheader"].Value.ToString();
                        bool bDrawLine = Convert.ToBoolean(rowObj.Cells["dgv_config_linechart_col_drawline"].Value);
                        bool bDrawPie = Convert.ToBoolean(rowObj.Cells["dgv_config_linechart_col_drawpiechart"].Value);
                        DetailChartConfig detailObj = new DetailChartConfig { 
                            Column=sColumn,
                            NewColumn=sNewColumn,
                            DrawLine = bDrawLine,
                            DrawPie=bDrawPie
                        };
                        valueColumns.Add(detailObj);
                    }

                    _lineChartConfig = new LineChartConfig { 
                    FilterColumn=filterColumn,
                    GroupColumn=groupColumn,
                    ValueColumns= valueColumns
                    };

                    var jsonConfig = JsonConvert.SerializeObject(_lineChartConfig, Formatting.Indented);
                    File.WriteAllText(_lineChartConfigFile.FullName, jsonConfig, Encoding.UTF8);

                    if (_rawDataObj?.IsValid() ?? false)
                    {
                        var dynamicObjs = _rawDataObj.ToDynamicObjects();
                        var groupObjs = dynamicObjs.GroupBy(ite => ite[filterColumn].ToString());
                        int rowIdx = 0;
                        foreach(var groupObj in groupObjs.OrderBy(ite=>ite.Key))
                        {
                            _dlg.AddDataGridViewRow(dgv_raw_summary, ++rowIdx, groupObj.Key, groupObj.Count(), "View");                            
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please add at least 01 value column.");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cms_rawdata_assignetofilter_Click(object sender, EventArgs e)
        {
            if (_dgv_raw_column_index >= 0)
            {
                var header = dgv_raw.Columns[_dgv_raw_column_index].HeaderText;
                _dlg.Execute(ts_raw, delegate
                {
                    ts_raw_com_filtercolumn.Text = header;
                });
            }
            
        }

        private void cms_rawdata_assigntogroup_Click(object sender, EventArgs e)
        {
            if (_dgv_raw_column_index >= 0)
            {
                var header = dgv_raw.Columns[_dgv_raw_column_index].HeaderText;
                _dlg.Execute(ts_raw, delegate
                {
                    ts_raw_com_groupcolumn.Text = header;
                });
            }
        }
    }
}
