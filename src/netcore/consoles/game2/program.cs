using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace game2
{
    class Program
    {
        static Task Main(string[] args)
        {
            try
            {
                if (args?.Length > 1)
                {
                    string folderPath = args[0];
                    string outputName = args[1];
                    if (!string.IsNullOrWhiteSpace(folderPath))
                    {
                        DirectoryInfo folder = new DirectoryInfo(folderPath);
                        if (folder.Exists)
                        {
                            var files = folder.GetFiles();
                            if (files?.Length > 0)
                            {
                                List<string> lines = new List<string>();
                                foreach (var file in files)
                                {
                                    string fileName = Path.GetFileNameWithoutExtension(file.Name);
                                    var iBBB = new List<string>() { file.Name };
                                    var temp = fileName.Split('_');
                                    iBBB.AddRange(temp);
                                    lines.Add(string.Join(",", iBBB.Select(ite => $"\"{ite}\"")));
                                }

                                string outputFilePath = $"{Directory.GetCurrentDirectory()}/{outputName}.csv";
                                File.WriteAllLines(outputFilePath, lines, System.Text.Encoding.UTF8);

                                Console.WriteLine("Done. Output path: " + outputFilePath);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Params not valid....");
                }
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