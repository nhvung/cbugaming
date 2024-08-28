using System;
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
    }
}
