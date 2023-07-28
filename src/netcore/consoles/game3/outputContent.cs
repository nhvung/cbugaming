using System.IO;

namespace game3
{
    class outputContent
    {
        string _IDFileName;
        public string IDFileName { get { return _IDFileName; } set { _IDFileName = value; } }
        string _IDFileContent;
        public string IDFileContent { get { return _IDFileContent; } set { _IDFileContent = value; } }
        FileInfo _ImageFile;
        public FileInfo ImageFile { get { return _ImageFile; } set { _ImageFile = value; } }
        public outputContent()
        {

        }
        public outputContent(string idFileName, string idFileContent, FileInfo imageFile)
        {
            _IDFileName = idFileName;
            _IDFileContent = idFileContent;
            _ImageFile = imageFile;
        }
    }
}