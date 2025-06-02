using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace game18
{
    class Program
    {
        static Task Main(string[] args)
        {
            try
            {
                Dictionary<string, string> mArgs = VSSystem.IO.CommandLine.GetCommandLineArgs(new string[]
                {
                    "--result-file",
                    "--sample-file",
                    "--output-file",
                });

                string sampleFileName = mArgs.ContainsKey("--sample-file") ? mArgs["--sample-file"] : "sample.csv";
                string resultFileName = mArgs.ContainsKey("--result-file") ? mArgs["--result-file"] : "result.csv";
                string outputFileName = mArgs.ContainsKey("--output-file") ? mArgs["--output-file"] : "output.csv";

                var headers = VSSystem.IO.CsvFile.ReadHeader(sampleFileName);
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