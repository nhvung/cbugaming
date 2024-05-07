using System;
using System.Collections.Generic;
using System.IO;
using VSSystem.ThirdParty.Selenium.Actions;

namespace game7.actions
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public class LoginAction : AAction
    {
        string _Username;
        public string Username { get { return _Username; } set { _Username = value; } }
        string _Password;
        public string Password { get { return _Password; } set { _Password = value; } }
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_Username) && !string.IsNullOrWhiteSpace(_Password);
        }
        public override List<WebAction> ToWebActions(string baseUrl, string sessionFormat, double timezoneOffset = 0)
        {
            DateTime now = DateTime.UtcNow;
            string sessionGuid = Guid.NewGuid().ToString().ToLower();
            if (timezoneOffset != 0)
            {
                now = now.AddMinutes(-timezoneOffset);
            }
            var result = new List<VSSystem.ThirdParty.Selenium.Actions.WebAction>();
            try
            {
                string fileName = string.Format(_ScreenShotFileName, now, sessionGuid);
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    fileName = string.Format(sessionFormat, now, sessionGuid);
                }
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    fileName = _ScreenShotFileName = "login";
                }
                result.Add(new WebAction { Url = $"{baseUrl}" });
                result.Add(new WebAction
                {
                    Props = new ElementProps("txtusername")
                    {
                        Value = _Username
                    }
                });
                result.Add(new WebAction
                {
                    Props = new ElementProps("txtpassword")
                    {
                        Value = _Password
                    }
                });
                result.Add(new WebAction
                {
                    Props = new ElementProps("btnSubmit"),
                    Click = true
                });

                if (_pTakeScreenShot)
                {
                    result.Add(new WebAction(VSSystem.ThirdParty.Selenium.Define.EActionType.ScreenShot)
                    {
                        DelaySeconds = 1,
                        FileName = fileName,
                    });
                }
            }
            catch { }
            return result;
        }
    }
}