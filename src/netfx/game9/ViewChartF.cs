using game9.Models;
using Newtonsoft.Json;
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

namespace game9
{
    public partial class ViewChartF : Form
    {
        FileInfo _configFile;
        ChartConfig _chartConfig;
        List<DataInfo> _dataObjs;
        DelegateProcess _dlg;
        string _title;
        public ViewChartF()
        {
            InitializeComponent();
            _dlg = new DelegateProcess();
            _configFile = new FileInfo($"{Application.StartupPath}/chart_config.json");
            LoadConfig();
            InitChart();
        }
        public ViewChartF(List<DataInfo> dataObjs, string title = "")
        {
            InitializeComponent();
            _dlg = new DelegateProcess();
            _dataObjs = dataObjs;
            _title = title;
            _configFile = new FileInfo($"{Application.StartupPath}/chart_config.json");
            LoadConfig();
            InitChart();
            but_apply_Click(null,null);
        }

        void LoadConfig()
        {
            try
            {
                if(_configFile.Exists)
                {
                    string json = File.ReadAllText(_configFile.FullName, Encoding.UTF8);
                    _chartConfig = JsonConvert.DeserializeObject<ChartConfig>(json);
                    
                }

                if (_chartConfig == null)
                {
                    _chartConfig = ChartConfig.Default;
                }

                if (_chartConfig.Titles?.Count > 0)
                {
                    foreach (string value in _chartConfig.Titles.OrderBy(ite => ite, StringComparer.InvariantCultureIgnoreCase))
                    {
                        com_charttitle.Items.Add(value);
                    }
                    com_charttitle.SelectedIndex = 0;
                }
                if (_chartConfig.XAxisLabels?.Count > 0)
                {
                    foreach (string value in _chartConfig.XAxisLabels.OrderBy(ite => ite, StringComparer.InvariantCultureIgnoreCase))
                    {
                        com_xaxislabel.Items.Add(value);
                    }
                    com_xaxislabel.SelectedIndex = 0;
                }
                if (_chartConfig.XAxisLableAngles?.Count > 0)
                {
                    foreach (string value in _chartConfig.XAxisLableAngles.OrderBy(ite => ite, StringComparer.InvariantCultureIgnoreCase))
                    {
                        com_xaxislabelangle.Items.Add(value);
                    }
                    com_xaxislabelangle.Text = "-75";
                }
                if (_chartConfig.YAxisLabels?.Count > 0)
                {
                    foreach (string value in _chartConfig.YAxisLabels.OrderBy(ite => ite, StringComparer.InvariantCultureIgnoreCase))
                    {
                        com_yaxislabel.Items.Add(value);
                    }
                    com_yaxislabel.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void InitChart()
        {           
            try
            {
               
                main_chart.ChartAreas[0].AxisX.Interval = 1;               
                //main_chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
                //main_chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                
                //main_chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DimGray;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void but_apply_Click(object sender, EventArgs e)
        {
            try
            {
                string title = _title ?? com_charttitle.Text;
                string xAxisLabel = com_xaxislabel.Text;
                string xAxisLabelAngle = com_xaxislabelangle.Text;
                string yAxisLabel = com_yaxislabel.Text;

                main_chart.Titles.Clear();
                main_chart.Titles.Add(title.ToUpper());
                main_chart.Titles[0].ForeColor = Color.White;
                main_chart.Titles[0].Font = new Font("arial", 13, FontStyle.Bold);
                main_chart.BackColor = main_chart.ChartAreas[0].BackColor= Color.DimGray;

                main_chart.ChartAreas[0].AxisX.Title = xAxisLabel;
                main_chart.ChartAreas[0].AxisX.TitleForeColor = Color.White;
                main_chart.ChartAreas[0].AxisX.LineColor = Color.White;
                main_chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.WhiteSmoke;
                main_chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

                main_chart.ChartAreas[0].AxisY.Title = yAxisLabel;
                main_chart.ChartAreas[0].AxisY.TitleForeColor = Color.White;
                main_chart.ChartAreas[0].AxisY.LineColor = Color.White;
                main_chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                main_chart.ChartAreas[0].AxisY.LineWidth = 0;
                main_chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
                

                int iXAxisLabelAngle;
                int.TryParse(xAxisLabelAngle, out iXAxisLabelAngle);                
                main_chart.ChartAreas[0].AxisX.LabelStyle.Angle = iXAxisLabelAngle;

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        void LoadData()
        {
            try
            {
                if(_dataObjs?.Count > 0)
                {
                    try
                    {
                        _dlg.ClearDataGridViewRows(dgv_detail);
                        _dlg.ClearDataGridViewColumns(dgv_detail);

                        int iCol = 0;
                        _dlg.AddDataGridViewColumn(dgv_detail, $"dgv_detail_col_date", $"Date");
                        Dictionary<string, List<object>> rowObjs = new Dictionary<string, List<object>>()
                        {
                            { "TotalPassed", new List<object>(){ "TotalPassed" } },
                            { "TotalFailed", new List<object>(){ "TotalFailed" } },
                            { "TotalError", new List<object>(){ "TotalError" } },
                            { "TotalRun", new List<object>(){ "TotalRun" } },
                        };
                        foreach (var dataObj in _dataObjs)
                        {
                            _dlg.AddDataGridViewColumn(dgv_detail, $"dgv_detail_col_{++iCol}", $"{dataObj.DateEnd}");
                            rowObjs["TotalPassed"].Add(dataObj.TotalPassed);
                            rowObjs["TotalFailed"].Add(dataObj.TotalFailed);
                            rowObjs["TotalError"].Add(dataObj.TotalError);
                            rowObjs["TotalRun"].Add(dataObj.TotalRun);
                        }
                        foreach(var rowObj in rowObjs)
                        {
                            _dlg.AddDataGridViewRow(dgv_detail, rowObj.Value.ToArray());
                        }

                        _dlg.Execute(main_chart, () => {
                            main_chart.Series.Clear();

                            System.Windows.Forms.DataVisualization.Charting.Series totalRunSeriesObj = main_chart.Series.Add("TotalRun");
                            totalRunSeriesObj.LegendText = totalRunSeriesObj.Name;
                            totalRunSeriesObj.Color = Color.Blue;

                            System.Windows.Forms.DataVisualization.Charting.Series totalPassedSeriesObj = main_chart.Series.Add("TotalPassed");
                            totalPassedSeriesObj.LegendText = totalPassedSeriesObj.Name;
                            totalPassedSeriesObj.Color = Color.Orange;

                            System.Windows.Forms.DataVisualization.Charting.Series totalFailedSeriesObj = main_chart.Series.Add("TotalFailed");
                            totalFailedSeriesObj.LegendText = totalFailedSeriesObj.Name;
                            totalFailedSeriesObj.Color = Color.WhiteSmoke;

                            System.Windows.Forms.DataVisualization.Charting.Series totalErrorSeriesObj = main_chart.Series.Add("TotalError");
                            totalErrorSeriesObj.LegendText = totalErrorSeriesObj.Name;
                            totalErrorSeriesObj.Color = Color.Yellow;

                            foreach (var dataObj in _dataObjs)
                            {
                                totalRunSeriesObj.Points.AddXY(dataObj.DateEnd, dataObj.TotalRun);
                                totalPassedSeriesObj.Points.AddXY(dataObj.DateEnd, dataObj.TotalPassed);
                                totalFailedSeriesObj.Points.AddXY(dataObj.DateEnd, dataObj.TotalFailed);
                                totalErrorSeriesObj.Points.AddXY(dataObj.DateEnd, dataObj.TotalError);

                            }

                            totalRunSeriesObj.ChartType = totalPassedSeriesObj.ChartType = totalFailedSeriesObj.ChartType = totalErrorSeriesObj.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                            totalRunSeriesObj.IsValueShownAsLabel = totalPassedSeriesObj.IsValueShownAsLabel = totalFailedSeriesObj.IsValueShownAsLabel = totalErrorSeriesObj.IsValueShownAsLabel = true;
                            totalRunSeriesObj.BorderWidth = totalPassedSeriesObj.BorderWidth= totalFailedSeriesObj.BorderWidth= totalErrorSeriesObj.BorderWidth= 2;
                            totalRunSeriesObj.LabelForeColor= totalPassedSeriesObj.LabelForeColor= totalFailedSeriesObj.LabelForeColor= totalErrorSeriesObj.LabelForeColor = Color.White;

                            main_chart.Series.Add(totalRunSeriesObj);
                            main_chart.Series.Add(totalPassedSeriesObj);
                            main_chart.Series.Add(totalFailedSeriesObj);
                            main_chart.Series.Add(totalErrorSeriesObj);
                        });                        
                    }
                    catch (Exception ex)
                    {

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
            this.Close();
        }

        private void but_exporttoimage_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            try
            {
                string outputImagePath = $"{Application.StartupPath}/export/images/{now:MM-dd-yyyy}/{_title}.jpeg";
                FileInfo outputImageFile = new FileInfo(outputImagePath);
                if(!outputImageFile.Directory.Exists)
                {
                    outputImageFile.Directory.Create();
                }
                _dlg.Execute(panel_overview, () =>
                {
                    using (var img = new Bitmap(panel_overview.Width, panel_overview.Height))
                    {
                        panel_overview.DrawToBitmap(img, new Rectangle(0, 0, panel_overview.Width, panel_overview.Height));
                        img.Save(outputImageFile.FullName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        img.Dispose();
                    }
                    // main_chart.SaveImage(outputImageFile.FullName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
                });
                MessageBox.Show($"Export chart {_title} done.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_setbackgroundcolor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog()== DialogResult.OK)
            {
                main_chart.BackColor = colorDialog.Color;
                main_chart.ChartAreas[0].BackColor= colorDialog.Color;
            }
        }
    }
}
