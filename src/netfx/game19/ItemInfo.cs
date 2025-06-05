using System;

namespace game19
{
    public class ItemInfo
    {
        protected string _Path;
        public string Path { get { return _Path; } set { _Path = value; } }
        protected string _Plate;
        public string Plate { get { return _Plate; } set { _Plate = value; } }
        protected string _Make;
        public string Make { get { return _Make; } set { _Make = value; } }
        protected string _Model;
        public string Model { get { return _Model; } set { _Model = value; } }
        protected string _Color;
        public string Color { get { return _Color; } set { _Color = value; } }
        protected string _Ticks;
        public string Ticks { get { return _Ticks; } set { _Ticks = value; } }
        protected string _ImageType;
        public string ImageType { get { return _ImageType; } set { _ImageType = value; } }
        protected string _Time;
        public string Time { get { return _Time; } set { _Time = value; } }
        public ItemInfo() { }
        public ItemInfo(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path))
                {
                    _Path = path;
                    var parts = path.Replace("\\", "/").Split(new[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 2)
                    {
                        _Plate = parts[2];
                    }
                    if (parts.Length > 3)
                    {
                        _Make = parts[3];
                    }
                    if (parts.Length > 4)
                    {
                        _Model = parts[4];
                    }
                    if (parts.Length > 5)
                    {
                        _Color = parts[5];
                    }
                    if (parts.Length > 7)
                    {
                        _Ticks = parts[7];
                    }
                    if (parts.Length > 7)
                    {
                        _Ticks = parts[7];
                    }
                    if (parts.Length > 12)
                    {
                        _ImageType = parts[12];
                    }
                    if (parts.Length > 11)
                    {
                        _Time = parts[11];
                    }
                }
            }
            catch
            {

            }
        }
    }
}
