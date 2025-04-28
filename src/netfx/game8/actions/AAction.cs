using System;
using System.Collections.Generic;
using VSSystem.ThirdParty.Selenium.Actions;

namespace game8.actions
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public abstract class AAction : IAction
    {
        protected string _TakeScreenshot;
        public string TakeScreenshot { get { return _TakeScreenshot; } set { _TakeScreenshot = value; } }
        protected bool _pTakeScreenShot
        {
            get
            {
                bool takeScreenshot = (_TakeScreenshot?.Equals("t", StringComparison.InvariantCultureIgnoreCase) ?? false)
                                        || (_TakeScreenshot?.Equals("true", StringComparison.InvariantCultureIgnoreCase) ?? false)
                                        || (_TakeScreenshot?.Equals("1") ?? false);
                return takeScreenshot;
            }
        }
        [Newtonsoft.Json.JsonIgnore]
        public bool pTakeScreenShot { get { return _pTakeScreenShot; } }
        protected string _ScreenShotFileName;
        public string ScreenShotFileName { get { return _ScreenShotFileName; } set { _ScreenShotFileName = value; } }
        abstract public List<WebAction> ToWebActions(string baseUrl, string sessionFormat, double timezoneOffset = 0);
        public AAction() { }
    }
}