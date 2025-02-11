using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game14
{
    public partial class MainF : Form
    {
        public MainF()
        {
            InitializeComponent();
        }

        private void but_calc_Click(object sender, EventArgs e)
        {
            try
            {
                double lat1, lng1, lat2, lng2;
                
                double.TryParse(txt_lat1.Text, out lat1);
                double.TryParse(txt_lng1.Text, out lng1);

                double.TryParse(txt_lat2.Text, out lat2);
                double.TryParse(txt_lng2.Text, out lng2);

                double distanceInMiles = CoordinatesExtension.CalculateDistance(lat1, lng1, lat2, lng2);
                double distanceInMeters = CoordinatesExtension.CalculateDistance(lat1, lng1, lat2, lng2,6371000);
                double distanceInKilometers = CoordinatesExtension.CalculateDistance(lat1, lng1, lat2, lng2,6371);

                string[] rLines = new string[] { 
                    $"Distance",
                    $"",
                    $"in Miles: {distanceInMiles:0.00}",
                    $"in Kilometers: {distanceInKilometers:0.00}",
                    $"in Meters: {distanceInMeters:0.00}",
                };

                rtxt_result.Lines = rLines;
            }
            catch (Exception ex)
            {
                rtxt_result.Text = "Error: " + ex.Message;
            }
        }
    }
}
