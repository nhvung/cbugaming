using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace game12
{
    class Program
    {
        static Task Main(string[] args)
        {
            // vm-processing-panel
            // vm-processing-bg
            try
            {
                Dictionary<string, string> mArgs = CommandLine.GetCommandLineArgs(new string[]
                {
                    "-f",
                    "-o",
                    "--numberOfThreads",
                    "-pLevel"
                });

                int nThreads = -1;
                if (mArgs.ContainsKey("--numberOfThreads"))
                {
                    int.TryParse(mArgs["--numberOfThreads"], out nThreads);
                }
                if (nThreads < -1 || nThreads == 0)
                {
                    nThreads = 1;
                }

                int pLevel = -1;
                if (mArgs.ContainsKey("-pLevel"))
                {
                    int.TryParse(mArgs["-pLevel"], out pLevel);
                }

                string inputFolderPath = Directory.GetCurrentDirectory();
                if (mArgs.ContainsKey("-f"))
                {
                    inputFolderPath = mArgs["-f"];
                }
                string outputFolderPath = string.Empty;
                if (mArgs.ContainsKey("-o"))
                {
                    outputFolderPath = mArgs["-o"];
                }
                if (string.IsNullOrWhiteSpace(outputFolderPath))
                {
                    outputFolderPath = $"{Directory.GetCurrentDirectory()}/output";
                }
                if (!string.IsNullOrWhiteSpace(inputFolderPath))
                {
                    DirectoryInfo inputFolder = new DirectoryInfo(inputFolderPath);
                    if (inputFolder.Exists)
                    {
                        var files = inputFolder.GetFiles();
                        List<FileInfoExt> fExtObjs = new List<FileInfoExt>();
                        foreach (var file in files)
                        {
                            if (file.Extension.Equals(".txt", StringComparison.InvariantCultureIgnoreCase))
                            {
                                continue;
                            }
                            string name = Path.GetFileNameWithoutExtension(file.Name);
                            string path = file.FullName;
                            if (pLevel > 0)
                            {
                                DirectoryInfo pFolder = file.Directory;
                                int tLevel = pLevel;
                                while (tLevel > 0 && pFolder.Parent != null)
                                {
                                    pFolder = pFolder.Parent;
                                    tLevel--;
                                }
                                path = path.Substring(pFolder.FullName.Length);
                            }
                            FileInfoExt fExtObj = new FileInfoExt(path, name);
                            fExtObjs.Add(fExtObj);
                        }

                        if (fExtObjs.Count > 0)
                        {
                            var groupObjs = fExtObjs.GroupBy(ite => ite.SplitNames[0]).ToList();
                            var outputFolder = new DirectoryInfo(outputFolderPath);
                            if (!outputFolder.Exists)
                            {
                                outputFolder.Create();
                            }
                            foreach (var groupObj in groupObjs)
                            {
                                var lines = groupObj.Select(ite => ite.Path).ToArray();
                                var outputFilePath = $"{outputFolder.FullName}/{groupObj.Key}.txt";
                                File.WriteAllLines(outputFilePath, lines);
                            }
                        }
                    }
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