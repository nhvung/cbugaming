using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game8
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public class WebElementProps {
        public string UsernameId { get; set; }
        public string PasswordId { get; set; }
        public string SubmitId { get; set; }
    }

    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    class ToolConfigs
    {
        public string SharedAccountFilePath { get; set; }
        public string PrivateAccountFilePath { get; set; }
        public int? NumberOfExecuteThreads { get; set; }
        public int? NumberOfWarningThreads { get; set; }
        public WebElementProps WebElementIds { get; set; }
    }
}
