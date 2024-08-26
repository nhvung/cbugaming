using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game9.Models
{
    public class ChartConfig
    {
        protected List<string> _Titles;
        public List<string> Titles { get { return _Titles; } set { _Titles = value; } }
        protected List<string> _XAxisLabels;
        public List<string> XAxisLabels { get { return _XAxisLabels; } set { _XAxisLabels = value; } }
        protected List<string> _XAxisLableAngles;
        public List<string> XAxisLableAngles { get { return _XAxisLableAngles; } set { _XAxisLableAngles = value; } }
        protected List<string> _YAxisLabels;
        public List<string> YAxisLabels { get { return _YAxisLabels; } set { _YAxisLabels = value; } }

        public ChartConfig() { }
        public static ChartConfig Default
        {
            get
            {
                return new ChartConfig
                {
                    _Titles = new List<string> { "CHART ADVANCE ANALYTIC" },
                    _XAxisLabels = new List<string> { "Date" },
                    _XAxisLableAngles = new List<string> { "-90", "-75", "-45" },
                    _YAxisLabels = new List<string> { "#Test Case" },

                };
            }
        }
    }
}
