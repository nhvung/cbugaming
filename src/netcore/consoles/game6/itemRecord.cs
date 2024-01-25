using System;

namespace game6
{
    public class itemRecord
    {
        DateTime _Time;
        public DateTime Time { get { return _Time; } set { _Time = value; } }
        string _Path;
        public string Path { get { return _Path; } set { _Path = value; } }
        string[] _SplitPathNames;
        public string[] SplitPathNames { get { return _SplitPathNames; } set { _SplitPathNames = value; } }
        public override string ToString()
        {
            return $"{_Path}: {_Time:MM/dd/yyyy HH:mm:ss}";
        }
    }
}