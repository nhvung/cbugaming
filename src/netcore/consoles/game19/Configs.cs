namespace game19
{
    public class Configs
    {
        protected string _TemplateFilePath;
        public string TemplateFilePath { get { return _TemplateFilePath; } set { _TemplateFilePath = value; } }
        protected int? _NumberOfSamples;
        public int? NumberOfSamples { get { return _NumberOfSamples; } set { _NumberOfSamples = value; } }
        protected string _OutputFolderPath;
        public string OutputFolderPath { get { return _OutputFolderPath; } set { _OutputFolderPath = value; } }
        protected string _FileNameFormat;
        public string FileNameFormat { get { return _FileNameFormat; } set { _FileNameFormat = value; } }
        public Configs() { }
        public Configs(string filePath)
        {
            string jsonText = System.IO.File.ReadAllText(filePath);
            Configs configs = Newtonsoft.Json.JsonConvert.DeserializeObject<Configs>(jsonText);
            _TemplateFilePath = configs.TemplateFilePath;
            _NumberOfSamples = configs.NumberOfSamples;
            _OutputFolderPath = configs.OutputFolderPath;
            _FileNameFormat = configs.FileNameFormat;
        }
    }
}