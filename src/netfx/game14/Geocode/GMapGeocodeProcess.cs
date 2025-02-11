using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace VSSystem.ThirdParty.Google.Maps.Geocode
{
    public class GMapGeocodeProcess
    {
        public static GMapInfoResult GetGeocodeMapInfo(string address, string key = "")
        {
            try
            {
                if (string.IsNullOrEmpty(address)) return null;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var en = System.Web.HttpUtility.UrlEncode(address);
                byte[] bData = new WebClient().DownloadData(new Uri(string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}", en, key == "" ? "AIzaSyDarm8iEY4j3hjw2GkGGMZlfkZKtl7mU5M" : key)));
                string resData = Encoding.UTF8.GetString(bData);
                GMapInfoResult gREs = JsonConvert.DeserializeObject<GMapInfoResult>(resData);
                return gREs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static GMapInfoResult GetGeocodeMapInfo(string address, string stateName, string key = "")
        {
            try
            {
                //https://maps.googleapis.com/maps/api/geocode/json?address={0}&components=administrative_area:{2}&key={1}
                if (string.IsNullOrEmpty(address)) return null;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var en = System.Web.HttpUtility.UrlEncode(address);
                var stateNameEncode = System.Web.HttpUtility.UrlEncode(stateName);
                byte[] bData = new WebClient().DownloadData(new Uri(string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}&components=administrative_area:{2}", en, key == "" ? "AIzaSyDarm8iEY4j3hjw2GkGGMZlfkZKtl7mU5M" : key, stateNameEncode)));
                string resData = Encoding.UTF8.GetString(bData);
                GMapInfoResult gREs = JsonConvert.DeserializeObject<GMapInfoResult>(resData);
                return gREs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static GMapGeocode GetGeocodeInfo(string address, string key = "")
        {
            GMapGeocode gMapResult = null;
            try
            {
                if (string.IsNullOrEmpty(address)) return null;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var en = System.Web.HttpUtility.UrlEncode(address);
                byte[] bData = new WebClient().DownloadData(new Uri(string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}", en, key == "" ? "AIzaSyDarm8iEY4j3hjw2GkGGMZlfkZKtl7mU5M" : key)));
                string resData = Encoding.UTF8.GetString(bData);
                GMapInfoResult gRes = JsonConvert.DeserializeObject<GMapInfoResult>(resData);
                if (gRes?.Results?.Length > 0)
                {
                    int maxMatchCount = 0;
                    foreach (var geocodeResult in gRes.Results)
                    {
                        int matchCount = geocodeResult.formatted_address.ToLower().Intersect(address.ToLower()).Count();
                        if (matchCount > maxMatchCount)
                        {
                            gMapResult = geocodeResult;
                            maxMatchCount = matchCount;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gMapResult;
        }
        public static GMapGeocode GetGeocodeInfo(string address, string stateName, string key = "")
        {
            GMapGeocode gMapResult = null;
            try
            {
#if DEBUG
                key = "AIzaSyBYOgqZ4JqRxMjxl6erXprF_JgBgaMvnU0";
#endif
                if (string.IsNullOrEmpty(address)) return null;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var en = System.Web.HttpUtility.UrlEncode(address);
                var stateNameEncode = System.Web.HttpUtility.UrlEncode(stateName);
                string requestUrl = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}&components=administrative_area:{2}", en, key == "" ? "AIzaSyDarm8iEY4j3hjw2GkGGMZlfkZKtl7mU5M" : key, stateNameEncode);
                byte[] bData = new WebClient().DownloadData(new Uri(requestUrl));
                string resData = Encoding.UTF8.GetString(bData);
                GMapInfoResult gRes = JsonConvert.DeserializeObject<GMapInfoResult>(resData);

                if (gRes?.Results?.Length > 0)
                {
                    int maxMatchCount = 0;
                    foreach (var geocodeResult in gRes.Results)
                    {
                        int matchCount = geocodeResult.formatted_address.ToLower().Intersect(address.ToLower()).Count();
                        if (matchCount > maxMatchCount)
                        {
                            gMapResult = geocodeResult;
                            maxMatchCount = matchCount;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gMapResult;
        }
    }
}
