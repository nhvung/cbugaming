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
            ts_menu_txt_filepath.Text = @"c:\code\temp\cbu\Sample-3.xlsx";
#endif

            dgv_summary.CellContentClick += Dgv_summary_CellContentClick;
            FormClosed += DataBindingF_FormClosed;
#if DEBUG
            ts_menu_view_Click(null, null);
#endif
            dgv_raw.CellMouseClick += Dgv_raw_CellMouseClick;
            dgv_config_linechart.CellMouseClick += Dgv_config_linechart_CellMouseClick;

            _lineChartConfigFile = new FileInfo($"{Application.StartupPath}/lineChartConfig.json");
            _LoadRawConfig();

            dgv_raw_summary.CellContentClick += Dgv_raw_summary_CellContentClick;
        }

        void _LoadRawConfig()
        {
            try
            {
                if (_lineChartConfigFile.Exists)
                {
                    string json = File.ReadAllText(_lineChartConfigFile.FullName, Encoding.UTF8);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        _lineChartConfig = JsonConvert.DeserializeObject<LineChartConfig>(json);
                    }
                }
            }
            catch
            {
            }
            
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
                        if (_groupRawDataObjs?.ContainsKey(moduleName)??false)
                        {

                            var rawObjs = _groupRawDataObjs[moduleName];

                            ViewChartF viewChartF = new ViewChartF(rawObjs, _lineChartConfig,  $"chart {moduleName}");
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
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                }
                else
                {
                    _dlg.Execute(dgv_config_linechart, delegate {
                        if (dgv_config_linechart.Columns[e.ColumnIndex].Name.Equals("dgv_config_linechart_col_remove", StringComparison.InvariantCultureIgnoreCase))
                        {
                            dgv_config_linechart.Rows.RemoveAt(e.RowIndex);
                        }
                        else if (dgv_config_linechart.Columns[e.ColumnIndex].Name.Equals("dgv_config_linechart_col_color", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (e.RowIndex > -1)
                            {
                                ColorDialog colorDialog = new ColorDialog();
                                bool hasChanged = false;
                                string header = dgv_config_linechart["dgv_config_linechart_col_header", e.RowIndex].Value.ToString();
                                if (colorDialog.ShowDialog() == DialogResult.OK)
                                {
                                    var hexColor = $"#{colorDialog.Color.R:X2}{colorDialog.Color.G:X2}{colorDialog.Color.B:X2}";
                                    var colorCell = new DataGridViewStatusCell.StatusCell(hexColor, colorDialog.Color, Color.White);
                                    if (_lineChartConfig?.ValueColumns?.Count > 0)
                                    {
                                        foreach (var col in _lineChartConfig.ValueColumns)
                                        {
                                            if (col.Column.Equals(header, StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                col.HexColor = hexColor;
                                                hasChanged = true;
                                                break;
                                            }
                                        }
                                    }

                                    try
                                    {
                                        _dlg.SetDataGridViewValue(dgv_config_linechart, e.RowIndex, "dgv_config_linechart_col_color", colorCell);
                                    }
                                    catch
                                    {

                                    }
                                }
                                if (hasChanged)
                                {
                                    _SaveLineChartConfig();
                                }
                            }

                        }
                    });

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        RawDataInfo _rawDataObj;
        void _ViewDataRaw(string filePath)
        {
            try
            {
                _dlg.ClearDataGridViewRows(dgv_config_linechart);
                _dlg.ClearDataGridViewRows(dgv_raw);
                _dlg.Execute(ts_raw, () => {
                    ts_raw_com_filtercolumn.Items.Clear();
                    ts_raw_com_filtercolumn.Items.Add(_lineChartConfig?.FilterColumn??"ModuleName");
                    ts_raw_com_filtercolumn.SelectedIndex = 0;

                    ts_raw_com_groupcolumn.Items.Clear();
                    ts_raw_com_groupcolumn.Items.Add(_lineChartConfig?.GroupColumn ?? "DateStart");                    
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
                    }
                    foreach(var row in _rawDataObj.Rows)
                    {
                        List<object> objs = new List<object>();
                       for(int i =0;i<row.Count;i++)
                        {
                            objs.Add(row[i]);
                        }
                        _dlg.AddDataGridViewRow(dgv_raw, objs.ToArray());
                    }
                }

                if(_lineChartConfig?.ValueColumns?.Count > 0)
                {
                    foreach(var valCol in _lineChartConfig.ValueColumns)
                    {
                        string colorValue = string.IsNullOrWhiteSpace(valCol.HexColor) ? "Set" : valCol.HexColor;
                        Color color = ColorTranslator.FromHtml(colorValue);

                        var colorCell = new DataGridViewStatusCell.StatusCell(colorValue, color, Color.White);

                        var rowIdx = _dlg.AddDataGridViewRow(dgv_config_linechart, valCol.Column, valCol.NewColumn, valCol.DrawLine, valCol.DrawPie, colorCell, "Remove");
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void cms_rawdata_addtolinechart_Click(object sender, EventArgs e)
        {
            if(_dgv_raw_column_index>=0)
            {
                var header = dgv_raw.Columns[_dgv_raw_column_index].HeaderText;
                var colorCell = new DataGridViewStatusCell.StatusCell("Not Set", Color.White, Color.Black);
                _dlg.AddDataGridViewRow(dgv_config_linechart, header, "", true, true, colorCell, "Remove");
            }
        }

        LineChartConfig _lineChartConfig;
        Dictionary<string, List<dynamic>> _groupRawDataObjs;
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
                        string sHexColor = rowObj.Cells["dgv_config_linechart_col_color"].Value?.ToString();
                        bool bDrawLine = Convert.ToBoolean(rowObj.Cells["dgv_config_linechart_col_drawline"].Value);
                        bool bDrawPie = Convert.ToBoolean(rowObj.Cells["dgv_config_linechart_col_drawpiechart"].Value);
                        DetailChartConfig detailObj = new DetailChartConfig { 
                            Column=sColumn,
                            NewColumn=sNewColumn,
                            DrawLine = bDrawLine,
                            DrawPie=bDrawPie,
                            HexColor= sHexColor
                        };
                        valueColumns.Add(detailObj);
                    }

                    _lineChartConfig = new LineChartConfig { 
                    FilterColumn=filterColumn,
                    GroupColumn=groupColumn,
                    ValueColumns= valueColumns
                    };

                    _SaveLineChartConfig();

                    if (_rawDataObj?.IsValid() ?? false)
                    {
                        var dynamicObjs = _rawDataObj.ToDynamicObjects();
                        _groupRawDataObjs = dynamicObjs.GroupBy(ite => $"{ite[filterColumn]}",StringComparer.InvariantCultureIgnoreCase)
                            .ToDictionary(ite=>ite.Key, ite=>ite.ToList(),StringComparer.InvariantCultureIgnoreCase);
                        int rowIdx = 0;
                        foreach(var groupObj in _groupRawDataObjs.OrderBy(ite=>ite.Key))
                        {
                            _dlg.AddDataGridViewRow(dgv_raw_summary, ++rowIdx, groupObj.Key, groupObj.Value.Count, "View");                            
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
                MessageBox.Show(ex.Message);
            }
        }

        void _SaveLineChartConfig()
        {
            try
            {
                if(_lineChartConfig!=null)
                {
                    var jsonConfig = JsonConvert.SerializeObject(_lineChartConfig, Formatting.Indented);
                    File.WriteAllText(_lineChartConfigFile.FullName, jsonConfig, Encoding.UTF8);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
