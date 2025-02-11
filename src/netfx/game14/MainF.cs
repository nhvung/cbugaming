using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSSystem.ThirdParty.Google.Maps.Geocode;

namespace game14
{
    public partial class MainF : Form
    {
        public MainF()
        {
            InitializeComponent();
#if DEBUG
            txt_apikey.Text = "AIzaSyDarm8iEY4j3hjw2GkGGMZlfkZKtl7mU5M";
#endif
            try
            {
                txt_apikey.Text = System.Configuration.ConfigurationManager.AppSettings["api-key"];
            }
            catch
            {
            }
            
        }

        private void but_calc_Click(object sender, EventArgs e)
        {
            try
            {
                string apiKey = txt_apikey.Text;
                double lat1=0, lng1=0, lat2=0, lng2=0;

                if(address_1_rad_latlong.Checked)
                {
                    string[] temp1 = address_1_txt_latlong.Text?.Split(',');
                    double.TryParse(temp1.FirstOrDefault(), out lat1);
                    double.TryParse(temp1.LastOrDefault(), out lng1);
                }
                else
                {
                    try
                    {
                        var mapObj = GMapGeocodeProcess.GetGeocodeInfo(address_1_txt_address.Text, apiKey);
                        if(mapObj?.geometry?.location!=null)
                        {
                            lat1 = mapObj.geometry.location.lat;
                            lng1 = mapObj.geometry.location.lng;
                            address_1_txt_latlong.Text = $"{lat1},{lng1}";
                        }
                        else
                        {
                            address_1_txt_latlong.Text = $"Cannot found position";
                        }
                    }
                    catch (Exception ex)
                    {

                        rtxt_result.Text = "Error: " + ex.Message;
                    }
                }

                if (address_2_rad_latlong.Checked)
                {
                    string[] temp2 = address_2_txt_latlong.Text?.Split(',');
                    double.TryParse(temp2.FirstOrDefault(), out lat2);
                    double.TryParse(temp2.LastOrDefault(), out lng2);
                }
                else
                {
                    try
                    {
                        var mapObj = GMapGeocodeProcess.GetGeocodeInfo(address_2_txt_address.Text, apiKey);
                        if (mapObj?.geometry?.location != null)
                        {
                            lat2 = mapObj.geometry.location.lat;
                            lng2 = mapObj.geometry.location.lng;
                            address_2_txt_latlong.Text = $"{lat2},{lng2}";
                        }
                        else
                        {
                            address_2_txt_latlong.Text = $"Cannot found position";
                        }
                    }
                    catch (Exception ex)
                    {

                        rtxt_result.Text = "Error: " + ex.Message;
                    }
                }


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

        private void address_1_but_preview_Click(object sender, EventArgs e)
        {
            string apiKey = txt_apikey.Text;
            try
            {
                double lat1 = 0, lng1 = 0;

                if (address_1_rad_latlong.Checked)
                {
                    string[] temp1 = address_1_txt_latlong.Text?.Split(',');
                    double.TryParse(temp1.FirstOrDefault(), out lat1);
                    double.TryParse(temp1.LastOrDefault(), out lng1);
                }
                else
                {
                    try
                    {
                        var mapObj = GMapGeocodeProcess.GetGeocodeInfo(address_1_txt_address.Text, apiKey);
                        if (mapObj?.geometry?.location != null)
                        {
                            lat1 = mapObj.geometry.location.lat;
                            lng1 = mapObj.geometry.location.lng;
                            address_1_txt_latlong.Text = $"{lat1},{lng1}";
                        }
                        else
                        {
                            address_1_txt_latlong.Text = $"Cannot found position";
                        }
                    }
                    catch (Exception ex)
                    {

                        rtxt_result.Text = "Error: " + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                rtxt_result.Text = "Error: " + ex.Message;
            }
        }

        private void address_2_but_preview_Click(object sender, EventArgs e)
        {
            string apiKey = txt_apikey.Text;
            try
            {
                double lat1 = 0, lng1 = 0;

                if (address_2_rad_latlong.Checked)
                {
                    string[] temp1 = address_2_txt_latlong.Text?.Split(',');
                    double.TryParse(temp1.FirstOrDefault(), out lat1);
                    double.TryParse(temp1.LastOrDefault(), out lng1);
                }
                else
                {
                    try
                    {
                        var mapObj = GMapGeocodeProcess.GetGeocodeInfo(address_2_txt_address.Text, apiKey);
                        if (mapObj?.geometry?.location != null)
                        {
                            lat1 = mapObj.geometry.location.lat;
                            lng1 = mapObj.geometry.location.lng;
                            address_2_txt_latlong.Text = $"{lat1},{lng1}";
                        }
                        else
                        {
                            address_2_txt_latlong.Text = $"Cannot found position";
                        }
                    }
                    catch (Exception ex)
                    {

                        rtxt_result.Text = "Error: " + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                rtxt_result.Text = "Error: " + ex.Message;
            }
        }
    }
}
