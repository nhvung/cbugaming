namespace game12
{
    public class FileInfoExt
    {
        string _Path;
        public string Path { get { return _Path; } set { _Path = value; } }
        string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        string[] _SplitPaths;
        public string[] SplitPaths { get { return _SplitPaths; } set { _SplitPaths = value; } }
        string[] _SplitNames;
        public string[] SplitNames { get { return _SplitNames; } set { _SplitNames = value; } }
        public FileInfoExt() { }
        public FileInfoExt(string path, string name)
        {
            _Path = path.Replace("\\", "/");
            if (!string.IsNullOrWhiteSpace(path))
            {
                char[] splitChars = System.IO.Path.GetInvalidFileNameChars();
                _SplitPaths = path.Split(System.IO.Path.GetInvalidFileNameChars());
            }
            _Name = name;
            if (!string.IsNullOrWhiteSpace(name))
            {
                _SplitNames = name.Split(new char[] { '_' });
            }
        }
    }
}