namespace game8.models
{
    public class LoginInfo
    {
        string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        string _Url;
        public string Url { get { return _Url; } set { _Url = value; } }
        string _Username;
        public string Username { get { return _Username; } set { _Username = value; } }
        string _Password;
        public string Password { get { return _Password; } set { _Password = value; } }
        string _ScreenshotFileNameFormat;
        public string ScreenshotFileNameFormat { get { return _ScreenshotFileNameFormat; } set { _ScreenshotFileNameFormat = value; } }
    }
}