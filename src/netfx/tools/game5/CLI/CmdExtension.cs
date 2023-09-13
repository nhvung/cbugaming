using System;
namespace game5
{
    public class CmdExtension : CLIExtension
    {
        public CmdExtension() : base(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\cmd.exe")
        {

        }
    }
}