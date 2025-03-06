using System.Collections.Generic;

namespace game15.Models
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    class ConfigInfo
    {
        public string Title { get; set; }
       
        public ConfigInfo() {
            Title = "Game 15 - Jira";
        }
    }
}
