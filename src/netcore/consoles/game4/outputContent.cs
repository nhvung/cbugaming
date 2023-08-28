using System.IO;

namespace game4
{
    class outputContent
    {
        string _IDFileName;
        public string IDFileName { get { return _IDFileName; } set { _IDFileName = value; } }
        string _IDFileContent;
        public string IDFileContent { get { return _IDFileContent; } set { _IDFileContent = value; } }
        FileInfo _CarImageFile;
        public FileInfo CarImageFile { get { return _CarImageFile; } set { _CarImageFile = value; } }
        FileInfo _PlateImageFile;
        public FileInfo PlateImageFile { get { return _PlateImageFile; } set { _PlateImageFile = value; } }
        public outputContent()
        {

        }
        public outputContent(string idFileName, string idFileContent, FileInfo carImageFile, FileInfo plateImageFile)
        {
            _IDFileName = idFileName;
            _IDFileContent = idFileContent;
            _CarImageFile = carImageFile;
            _PlateImageFile = plateImageFile;
        }
    }
}