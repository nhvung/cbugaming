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
                main_chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
                main_chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
               
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

                main_chart.ChartAreas[0].AxisX.Title = xAxisLabel;
                main_chart.ChartAreas[0].AxisY.Title = yAxisLabel;

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
                        _dlg.Execute(main_chart, () => {
                            main_chart.Series.Clear();

                            System.Windows.Forms.DataVisualization.Charting.Series totalRunSeriesObj = main_chart.Series.Add("TotalRun");
                            totalRunSeriesObj.LegendText = totalRunSeriesObj.Name;
                            System.Windows.Forms.DataVisualization.Charting.Series totalPassedSeriesObj = main_chart.Series.Add("TotalPassed");
                            totalPassedSeriesObj.LegendText = totalPassedSeriesObj.Name;
                            System.Windows.Forms.DataVisualization.Charting.Series totalFailedSeriesObj = main_chart.Series.Add("TotalFailed");
                            totalFailedSeriesObj.LegendText = totalFailedSeriesObj.Name;
                            System.Windows.Forms.DataVisualization.Charting.Series totalErrorSeriesObj = main_chart.Series.Add("TotalError");
                            totalErrorSeriesObj.LegendText = totalErrorSeriesObj.Name;

                            foreach (var dataObj in _dataObjs)
                            {
                                totalRunSeriesObj.Points.AddXY(dataObj.DateEnd, dataObj.TotalRun);
                                totalPassedSeriesObj.Points.AddXY(dataObj.DateEnd, dataObj.TotalPassed);
                                totalFailedSeriesObj.Points.AddXY(dataObj.DateEnd, dataObj.TotalFailed);
                                totalErrorSeriesObj.Points.AddXY(dataObj.DateEnd, dataObj.TotalError);
                            }

                            totalRunSeriesObj.ChartType = totalPassedSeriesObj.ChartType = totalFailedSeriesObj.ChartType = totalErrorSeriesObj.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                            totalRunSeriesObj.IsValueShownAsLabel = totalPassedSeriesObj.IsValueShownAsLabel = totalFailedSeriesObj.IsValueShownAsLabel = totalErrorSeriesObj.IsValueShownAsLabel = true;

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
    }
}
