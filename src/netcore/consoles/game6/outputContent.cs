using System.IO;
using System.Collections.Generic;

namespace game6
{
    class outputContent
    {
        string _IDFileName;
        public string IDFileName { get { return _IDFileName; } set { _IDFileName = value; } }
        string _IDFileContent;
        public string IDFileContent { get { return _IDFileContent; } set { _IDFileContent = value; } }
        List<FileInfo> _Files;
        public List<FileInfo> Files { get { return _Files; } set { _Files = value; } }
        public outputContent()
        {

        }
        public outputContent(string idFileName, string idFileContent, FileInfo file)
        {
            _IDFileName = idFileName;
            _IDFileContent = idFileContent;
        }
    }
}