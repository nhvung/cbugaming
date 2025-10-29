using System;
using System.IO;
using System.Xml;

namespace game19
{
    class Template
    {
        XmlDocument _xmlDocument;
        FileInfo _file;
        public Template(string xmlFileName)
        {
            _file = new FileInfo(xmlFileName);
            InitializeValues();
        }
        void InitializeValues()
        {
            _xmlDocument = new XmlDocument();
            if (_file.Exists)
            {
                _xmlDocument = new XmlDocument();
                _xmlDocument.Load(_file.FullName);
            }
        }
        public void SetValue(string xpath, string value)
        {
            XmlNode node = _xmlDocument.SelectSingleNode(xpath);
            if (node != null)
            {
                node.InnerText = value;
            }
        }
        public void Save(string fileName)
        {
            _xmlDocument.Save(fileName);
        }
    }
}