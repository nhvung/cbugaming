using System;
using System.Collections.Generic;
using VSSystem.ThirdParty.Selenium.Actions;

namespace game7.actions
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public class AddVehicleInfoAction : AAction
    {
        string _Make;
        public string Make { get { return _Make; } set { _Make = value; } }
        string _Model;
        public string Model { get { return _Model; } set { _Model = value; } }

        public override List<WebAction> ToWebActions(string baseUrl, string sessionFormat, double timezoneOffset = 0)
        {
            DateTime now = DateTime.UtcNow;
            List<WebAction> result = new List<WebAction>();
            try
            {

            }
            catch { }
            return result;
        }
    }
}