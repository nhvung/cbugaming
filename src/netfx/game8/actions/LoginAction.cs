using System;
using System.Collections.Generic;
using System.IO;
using VSSystem.ThirdParty.Selenium.Actions;

namespace game8.actions
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public class LoginAction : AAction
    {
        string _Username;
        public string Username { get { return _Username; } set { _Username = value; } }
        protected string _UsernameElementId;
        public string UsernameElementId { get { return _UsernameElementId; } set { _UsernameElementId = value; } }
        string _Password;
        public string Password { get { return _Password; } set { _Password = value; } }
        protected string _PasswordElementId;
        public string PasswordElementId { get { return _PasswordElementId; } set { _PasswordElementId = value; } }
        protected string _SubmitButtonElementId;
        public string SubmitButtonElementId { get { return _SubmitButtonElementId; } set { _SubmitButtonElementId = value; } }
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
                string fileName = string.Empty;
                try
                {
                    fileName = string.Format(_ScreenShotFileName, now, sessionGuid);
                }
                catch
                {
                 
                }
                
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    fileName = string.Format(sessionFormat, now, sessionGuid);
                }
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    fileName = _ScreenShotFileName = "login";
                }
                result.Add(new WebAction { Url = $"{baseUrl}" });
                string usernameElementId = _UsernameElementId ?? "txtusername";
                string passwordElementId = _PasswordElementId ?? "txtpassword";
                string submitButtonElementId = _SubmitButtonElementId ?? "btnSubmit";
                result.Add(new WebAction
                {
                    Props = new ElementProps(usernameElementId)
                    {
                        Value = _Username
                    }
                });
                result.Add(new WebAction
                {
                    Props = new ElementProps(passwordElementId)
                    {
                        Value = _Password
                    }
                });
                result.Add(new WebAction
                {
                    Props = new ElementProps(submitButtonElementId),
                    Click = true
                });

                result.Add(new WebAction(VSSystem.ThirdParty.Selenium.Define.EActionType.Wait)
                {
                    DelaySeconds = 5
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