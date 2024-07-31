using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game8
{
    public class AccountInfo
    {
        public long ID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public bool CanModify { get; set; }

        public AccountInfo() { }
        public AccountInfo(bool autoGenerate) 
        {
            if(autoGenerate)
            {

                ID = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                Url = "https://temp.org";
                Name = $"Temp-Name";
                Username = $"Temp-Username";
                Password = $"Temp-Password";
                Description = $"Temp-Description";
                CanModify = true;
            }
        }
    }
}
