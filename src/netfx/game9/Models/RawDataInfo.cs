using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game9.Models
{
    public class RawDataInfo
    {
        protected Dictionary<string,int> _Headers;
        public Dictionary<string,int> Headers { get { return _Headers; } set { _Headers = value; } }
        protected List<List<string>> _Rows;
        public List<List<string>> Rows { get { return _Rows; } set { _Rows = value; } }
        public RawDataInfo(){
            _Headers=new Dictionary<string,int>(StringComparer.InvariantCultureIgnoreCase);
            _Rows = new List<List<string>>();
        }

        public bool IsValid()
        {
            return _Headers?.Count > 0 && _Rows?.Count > 0;
        }

        public List<dynamic> ToDynamicObjects()
        {
            if(_Rows?.Count > 0 && _Headers?.Count > 0)
            {
                List<dynamic> dObjs = new List<dynamic>();
                foreach(var row in Rows)
                {
                    List<string> jsonFieldsValues = new List<string>();
                    foreach(var header in _Headers)
                    {
                        string jsonFieldValue = $"\"{header.Key}\": \"{row[header.Value]}\"";
                        jsonFieldsValues.Add(jsonFieldValue);
                    }
                    string jsonObj = "{" + string.Join(",", jsonFieldsValues) + "}";
                    dynamic dObj = JsonConvert.DeserializeObject<dynamic>(jsonObj);
                    dObjs.Add(dObj);
                }
                return dObjs;
            }
            return null;
        }
    }
}
