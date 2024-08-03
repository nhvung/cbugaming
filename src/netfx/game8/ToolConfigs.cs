using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game8
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    class ToolConfigs
    {
        public string SharedAccountFilePath { get; set; }
        public string PrivateAccountFilePath { get; set; }
    }
}
