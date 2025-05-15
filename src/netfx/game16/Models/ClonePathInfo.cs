namespace game16.Models
{
    public class ClonePathInfo
    {
        public string Guid { get; set; }
        public string Path { get; set; }
        public string ExecuteFile { get; set; }
        public ClonePathInfo() { }
        public ClonePathInfo(string guid, string path, string exeFile)
        {
            Guid = guid;
            Path = path;
            ExecuteFile = exeFile;
        }
        public override string ToString()
        {
            return $"{Guid}: {Path}/{ExecuteFile}";
        }
    }
}
