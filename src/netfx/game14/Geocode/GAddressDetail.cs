using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSSystem.ThirdParty.Google.Maps.Geocode
{
    public class GAddressDetail
    {
        string _country, _streetName, _streetNumber;
        string _fullAddress;
        public string Country { get { return _country; } set { _country = value; } }
        public string FullAddress { get { return _fullAddress; } set { _fullAddress = value; } }
        public string StreetName { get { return _streetName; } set { _streetName = value; } }
        public string StreetNumber { get { return _streetNumber; } set { _streetNumber = value; } }
        string _PostalCode;
        public string PostalCode { get { return _PostalCode; } set { _PostalCode = value; } }
        string _CityOrTown;
        public string CityOrTown { get { return _CityOrTown; } set { _CityOrTown = value; } }
        string _AdministrativeLevel1;
        public string AdministrativeLevel1 { get { return _AdministrativeLevel1; } set { _AdministrativeLevel1 = value; } }
        string _AdministrativeLevel2;
        public string AdministrativeLevel2 { get { return _AdministrativeLevel2; } set { _AdministrativeLevel2 = value; } }
        public GAddressDetail()
        {
            _country = string.Empty;
            _streetNumber = string.Empty;
            _streetName = string.Empty;
            _PostalCode = string.Empty;
            _CityOrTown = string.Empty;
            _AdministrativeLevel1 = string.Empty;
            _AdministrativeLevel2 = string.Empty;
        }
        public override string ToString()
        {
            return _fullAddress;
        }

        public bool IsSouthCalifornia()
        {
            try
            {
                string[] southCACounties = new string[] { "Imperial", "Kern", "Los Angeles", "Orange", "Riverside", "San Bernardino", "San Diego", "San Luis Obispo", "Santa Cruz", "Ventura" };
                foreach (string county in southCACounties)
                {
                    if (_AdministrativeLevel2.IndexOf(county, StringComparison.InvariantCultureIgnoreCase) >= 0) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
