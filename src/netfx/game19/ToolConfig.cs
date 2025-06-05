using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSSystem
{
    [Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    class ToolConfig
    {
        public string Title { get; set; }

        public string TotalCmdExePath { get; set; }

        public string InputFolderPath { get; set; }
        public string OutputFolderPath { get; set; }
        public string AliasOutputFolderPath { get; set; }


        public ToolConfig()
        {
            Title = "Game 19";
        }

        public void Save(string path            )
        {
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(path, json, Encoding.UTF8);
            }
            catch
            {

            }
        }
    }
}
