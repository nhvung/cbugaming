namespace game9.Models
{[Newtonsoft.Json.JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

    public class DetailChartConfig
    {
        protected string _Column;
        public string Column { get { return _Column; } set { _Column = value; } }
        protected string _NewColumn;
        public string NewColumn { get { return _NewColumn; } set { _NewColumn = value; } }
        protected bool? _DrawLine;
        public bool? DrawLine { get { return _DrawLine; } set { _DrawLine = value; } }
        protected bool? _DrawPie;
        public bool? DrawPie { get { return _DrawPie; } set { _DrawPie = value; } }
        protected string _HexColor;
        public string HexColor { get { return _HexColor; } set { _HexColor = value; } }
    }
}