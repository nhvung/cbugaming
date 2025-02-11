using System;

namespace game14
{
    public class CoordinatesExtension
    {
        const double iRad = Math.PI / 180;
        const double D_ZOOM_1 = 3958.8 * Math.PI * 2;
        const int MAX_ZOOM = 16;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius">Default in miles. radius = 6371 if in kilometers</param>
        /// <returns></returns>
        public static double CalculateDistance(double latitude1, double longitude1, double latitude2, double longitude2, double radius = 3958.8)
        {
            try
            {
                if (latitude1 == latitude2 && longitude1 == longitude2)
                {
                    return 0;
                }
                var phy1 = latitude1 * iRad;
                var phy2 = latitude2 * iRad;
                var dLatitude = (latitude2 - latitude1) * iRad;
                var dLongitude = (longitude2 - longitude1) * iRad;

                var sqrDLatitude = Math.Sin(dLatitude / 2) * Math.Sin(dLatitude / 2);
                var sqrDLongitude = Math.Sin(dLongitude / 2) * Math.Sin(dLongitude / 2);

                var A = sqrDLatitude + sqrDLongitude * Math.Cos(phy1) * Math.Cos(phy2);
                var C = 2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A));
                double result = Math.Round(radius * C, 3);
                return result;
            }
            catch { }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude1"></param>
        /// <param name="longitude1"></param>
        /// <param name="latitude2"></param>
        /// <param name="longitude2"></param>
        /// <param name="delta">Default by 1% of 01 degree</param>
        /// <returns></returns>
        public static bool IsNearTo(double latitude1, double longitude1, double latitude2, double longitude2, double delta = 0.01)
        {
            var dLatitude = Math.Abs(latitude2 - latitude1);
            var dLongitude = Math.Abs(longitude2 - longitude1);
            var result = dLatitude <= delta && dLongitude <= delta;
            return result;
        }

        public static double CalculateDistance(double? latitude1, double? longitude1, double? latitude2, double? longitude2, double radius = 3958.8)
        {
            return CalculateDistance(latitude1 ?? 0, longitude1 ?? 0, latitude2 ?? 0, longitude2 ?? 0, radius);
        }

        public static int GetZoom(double distance)
        {
            int result = 1;
            try
            {
                double baseDistance = D_ZOOM_1;
                while (baseDistance > distance && result < MAX_ZOOM)
                {
                    baseDistance /= 2;
                    result++;
                }
            }
            catch { }
            return result;
        }
    }
}