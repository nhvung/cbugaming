using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace game16
{
    class Program
    {
        static Task Main(string[] args)
        {
            try
            {
                Dictionary<string, string> mArgs = CommandLine.GetCommandLineArgs(new string[]
                {
                    "-f", "--folder",
                    "-o", "--output",
                    "--numberOfThreads"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
            return Task.CompletedTask;
        }


    }
}