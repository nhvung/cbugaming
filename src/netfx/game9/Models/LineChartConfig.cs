using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game9.Models
{[Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

    public class LineChartConfig
    {
        protected string _FilterColumn;
        public string FilterColumn { get { return _FilterColumn; } set { _FilterColumn = value; } }
        protected string _GroupColumn;
        public string GroupColumn { get { return _GroupColumn; } set { _GroupColumn = value; } }
        protected List<DetailChartConfig> _ValueColumns;
        public List<DetailChartConfig> ValueColumns { get { return _ValueColumns; } set { _ValueColumns = value; } }
    }
}
