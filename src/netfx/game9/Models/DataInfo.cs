using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game9.Models
{
    public class DataInfo
    {
        protected string _ModuleName;
        public string ModuleName { get { return _ModuleName; } set { _ModuleName = value; } }
       protected string _VersionTool;
       public string VersionTool { get { return _VersionTool; } set { _VersionTool = value; } }
       protected string _TimeStart;
       public string TimeStart { get { return _TimeStart; } set { _TimeStart = value; } }
        public string DateStart { get { return _TimeStart?.Substring(0, 10); } }
       protected string _TimeEnd;
       public string TimeEnd { get { return _TimeEnd; } set { _TimeEnd = value; } }
        public string DateEnd { get { return _TimeEnd?.Substring(0, 10); } }
       protected string _TotalTestCase;
       public string TotalTestCase { get { return _TotalTestCase; } set { _TotalTestCase = value; } }
       protected string _TotalRun;
       public string TotalRun { get { return _TotalRun; } set { _TotalRun = value; } }
       protected string _TotalPassed;
       public string TotalPassed { get { return _TotalPassed; } set { _TotalPassed = value; } }
       protected string _TotalFailed;
       public string TotalFailed { get { return _TotalFailed; } set { _TotalFailed = value; } }
       protected string _TotalError;
       public string TotalError { get { return _TotalError; } set { _TotalError = value; } }
       protected string _NoData;
       public string NoData { get { return _NoData; } set { _NoData = value; } }
       protected string _TimeSearchMin;
       public string TimeSearchMin { get { return _TimeSearchMin; } set { _TimeSearchMin = value; } }
       protected string _TimeSearchMax;
       public string TimeSearchMax { get { return _TimeSearchMax; } set { _TimeSearchMax = value; } }
       protected string _AverageTimeSearch;
       public string AverageTimeSearch { get { return _AverageTimeSearch; } set { _AverageTimeSearch = value; } }
       protected string _AverageTimeRun;
       public string AverageTimeRun { get { return _AverageTimeRun; } set { _AverageTimeRun = value; } }
       protected string _SummaryFolder;
       public string SummaryFolder { get { return _SummaryFolder; } set { _SummaryFolder = value; } }
       protected string _ReportRef;
       public string ReportRef { get { return _ReportRef; } set { _ReportRef = value; } }

        public DataInfo() { }
    }
}
