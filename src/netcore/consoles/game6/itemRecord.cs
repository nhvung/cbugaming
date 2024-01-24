using System;

namespace game6
{
    public class itemRecord
    {
        DateTime _Time;
        public DateTime Time { get { return _Time; } set { _Time = value; } }
        string _Path;
        public string Path { get { return _Path; } set { _Path = value; } }
    }
}