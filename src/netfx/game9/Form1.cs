using ExcelDataReader;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            try
            {
                DateTime now = DateTime.Now;
                var legends = new string[] { 
                "Total Run","Total Passed","TotalFailed","TotalError"};
                int iLegend = 0;
                foreach(var legend in legends)
                {
                    var s1 = new System.Windows.Forms.DataVisualization.Charting.Series()
                    {
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                        LegendText = legend,
                        IsValueShownAsLabel =true
                    };
                    
                    var random = new Random();
                    int iMin = iLegend * 100, iMax = (iLegend +1)* 100;
                    for (int i = 0; i < 60; i++)
                    {
                        int iRandom = random.Next(iMin, iMax);
                        s1.Points.AddXY($"{now.Date.AddDays(i):MM-dd-yyyy}", iRandom);
                    }
                    
                    chart1.Series.Add(s1);
                    iLegend++;
                }
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
                chart1.Titles.Add("chart advance analytic");
                chart1.ChartAreas[0].AxisX.Title = "Date";
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
                chart1.ChartAreas[0].AxisY.Title = "#Test Case";
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -75;
                
                
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (var ms = new MemoryStream())
                {
                    chart1.SaveImage(ms, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
                    pictureBox1.Image = Image.FromStream(ms);
                    ms.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
