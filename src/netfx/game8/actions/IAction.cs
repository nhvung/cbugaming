using System.Collections.Generic;

namespace game8.actions
{
    public interface IAction
    {
        List<VSSystem.ThirdParty.Selenium.Actions.WebAction> ToWebActions(string baseUrl, string sessionFormat, double timezoneOffset = 0);
    }
}