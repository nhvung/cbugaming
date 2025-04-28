using System;
using System.Collections.Generic;
using VSSystem.ThirdParty.Selenium.Actions;

namespace game8.actions
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public class AddHotPlatesAction : AAction
    {
        AddVehicleInfoAction _AddVehicleAction;
        public AddVehicleInfoAction AddVehicleAction { get { return _AddVehicleAction; } set { _AddVehicleAction = value; } }
        public override List<WebAction> ToWebActions(string baseUrl, string sessionFormat, double timezoneOffset = 0)
        {
            DateTime now = DateTime.UtcNow;
            List<WebAction> result = new List<WebAction>();
            try
            {
                result.Add(new WebAction
                {
                    Props = new ElementProps
                    {
                        TagItem = new TagProps("msi-sidebar-item")
                        {
                            Attributes = new List<AttributeProps>{
                                new AttributeProps("description","New")
                             }
                        },

                    },
                    Click = true
                });
            }
            catch { }
            return result;
        }
    }
}