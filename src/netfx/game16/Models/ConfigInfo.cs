using System.Collections.Generic;

namespace game16.Models
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    class ConfigInfo
    {
        public string Title { get; set; }
        public string SourceFolderPath { get; set; }
        public string CloneFolderPath { get; set; }
        public int NumberOfClones { get; set; }
        public string CloneNameFormat { get; set; }
        public string DefaultExecuteFileName { get; set; }
        public List<ClonePathInfo> CloneItems { get; set; }
        public ConfigInfo() {
            Title = "Game 16 - Clone";
        }
    }
}
