using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace game3
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
                                "-plevel",
                                "-idx",
                                "-o", "--output",
                            });
                string folderPath = "";
                if (mArgs.ContainsKey("-f"))
                {
                    folderPath = mArgs["-f"];
                }
                else if (mArgs.ContainsKey("--folder"))
                {
                    folderPath = mArgs["--folder"];
                }

                int idIndex = 0;
                if (mArgs.ContainsKey("-idx"))
                {
                    int.TryParse(mArgs["-idx"], out idIndex);
                }
                if (idIndex == 0)
                {
                    idIndex = 2;
                }


                int parentLevel = 0;
                if (mArgs.ContainsKey("-plevel"))
                {
                    int.TryParse(mArgs["-plevel"], out parentLevel);
                }

                string outputFolderPath = "";
                if (mArgs.ContainsKey("-o"))
                {
                    outputFolderPath = mArgs["-o"];
                }
                else if (mArgs.ContainsKey("--output"))
                {
                    outputFolderPath = mArgs["--output"];
                }

                bool removeDuplicate = false;
                if (mArgs.ContainsKey("-rd"))
                {
                    removeDuplicate = true;
                }

                if (!string.IsNullOrWhiteSpace(folderPath))
                {
                    DirectoryInfo folder = new DirectoryInfo(folderPath);
                    if (folder.Exists)
                    {
                        DirectoryInfo parentFolder = folder;
                        DirectoryInfo outputFolder = folder;
                        if (!string.IsNullOrWhiteSpace(outputFolderPath))
                        {
                            outputFolder = new DirectoryInfo(outputFolderPath);
                            if (!outputFolder.Exists)
                            {
                                outputFolder.Create();
                            }
                        }

                        while (parentLevel > 0 && parentFolder.Parent != null)
                        {
                            parentFolder = parentFolder.Parent;
                            parentLevel--;
                        }
                        var files = folder.GetFiles();
                        if (files?.Length > 0)
                        {
                            Dictionary<string, outputContent> mFileContent = new Dictionary<string, outputContent>(StringComparer.InvariantCultureIgnoreCase);
                            List<outputContent> kvFileContent = new List<outputContent>();
                            foreach (var file in files)
                            {
                                string txtFileName = $"ID_{Path.GetFileNameWithoutExtension(file.Name)}.txt";
                                if (idIndex > 0)
                                {
                                    var temp = file.Name.Split(new char[] { '_' });
                                    if (temp.Length > idIndex)
                                    {
                                        string id = temp[idIndex];
                                        txtFileName = $"ID_{id}.txt";
                                    }
                                }

                                string relativePath = $"/{parentFolder.Name}/{file.FullName.Substring(parentFolder.FullName.Length + 1).Replace("\\", "/")}";

                                outputContent oItem = new outputContent(txtFileName, relativePath, file);
                                if (!mFileContent.ContainsKey(txtFileName))
                                {
                                    mFileContent[txtFileName] = oItem;
                                }

                                kvFileContent.Add(oItem);
                            }

                            if (removeDuplicate)
                            {
                                _WriteToFile(outputFolder, mFileContent.Values);
                            }
                            else
                            {
                                _WriteToFile(outputFolder, kvFileContent);
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
        static void _WriteToFile(DirectoryInfo outputFolder, IEnumerable<outputContent> fileContentObjs)
        {
            foreach (var file in fileContentObjs)
            {
                try
                {
                    string outputImageFilePath = $"{outputFolder.FullName}/{file.ImageFile.Name}";
                    FileInfo outputImageFile = new FileInfo(outputImageFilePath);
                    if (!file.ImageFile.FullName.Equals(outputImageFile.FullName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        file.ImageFile.CopyTo($"{outputFolder.FullName}/{file.ImageFile.Name}");
                    }

                    File.WriteAllText($"{outputFolder.FullName}/{file.IDFileName}", file.IDFileContent, System.Text.Encoding.UTF8);
                }
                catch { }
            }
        }

    }
}