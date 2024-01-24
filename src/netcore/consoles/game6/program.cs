using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace game6
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
                                "--prefixName",
                                "--deltaTimeMs"
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
                    // idIndex = 2;
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

                string prefixName = "";
                if (mArgs.ContainsKey("--prefixName"))
                {
                    prefixName = mArgs["--prefixName"];
                }

                double deltaTimeMs = 0;
                string sDeltaTimeMs = "";
                if (mArgs.ContainsKey("--deltaTimeMs"))
                {
                    sDeltaTimeMs = mArgs["--deltaTimeMs"];
                    double.TryParse(sDeltaTimeMs, out deltaTimeMs);
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
                        var files = folder.GetFiles("*.*");
                        if (files?.Length > 0)
                        {
                            List<itemRecord> recordObjs = new List<itemRecord>();
                            Dictionary<string, List<string>> mFileContent = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);

                            foreach (var file in files)
                            {
                                itemRecord recordObj = new itemRecord();

                                var temp = file.Name.Split(new char[] { '_' });
                                long ticks = 0;


                                string txtFileName = $"ID_{Path.GetFileNameWithoutExtension(file.Name)}.txt";
                                if (temp.Length > idIndex)
                                {
                                    string id = temp[idIndex];
                                    long.TryParse(id, out ticks);
                                    txtFileName = $"ID_{id}.txt";
                                }

                                string mKey = txtFileName;
                                if (ticks > 0)
                                {
                                    DateTime dt = new DateTime(ticks);
                                    recordObj.Time = dt;
                                    mKey = dt.ToString("yyyy-MM-dd HH:mm");
                                }
                                if (!mFileContent.ContainsKey(mKey))
                                {
                                    mFileContent[mKey] = new List<string>();
                                }

                                string relativePath = $"/{parentFolder.Name}/{file.FullName.Substring(parentFolder.FullName.Length + 1).Replace("\\", "/")}";

                                recordObj.Path = relativePath;
                                mFileContent[mKey].Add(relativePath);

                                recordObjs.Add(recordObj);
                                // kvFileContent.Add(oItem);
                            }


                            var comparer = TComparer.Create<itemRecord>((i1, i2) => (i2.Time - i1.Time).TotalMilliseconds < deltaTimeMs);

                            var grpItemObjs = recordObjs.GroupBy(ite => ite, comparer).ToList();



                            _WriteToFileV2(outputFolder, prefixName, grpItemObjs, removeDuplicate);
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
        static void _WriteToFile(DirectoryInfo outputFolder, string prefixName, IEnumerable<KeyValuePair<string, List<string>>> fileContentObjs, bool removeDuplicate)
        {
            try
            {
                if (!outputFolder.Exists)
                {
                    outputFolder.Create();
                }
                int idx = 1;
                foreach (var kvContentObj in fileContentObjs)
                {
                    try
                    {
                        string fileName = $"{outputFolder.FullName}/{string.Format(prefixName, idx)}.txt";
                        File.WriteAllLines(fileName, kvContentObj.Value.OrderBy(ite => ite, StringComparer.InvariantCultureIgnoreCase), System.Text.Encoding.UTF8);
                        idx++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch { }
        }
        static void _WriteToFileV2(DirectoryInfo outputFolder, string prefixName, IEnumerable<IGrouping<itemRecord, itemRecord>> records, bool removeDuplicate)
        {
            try
            {
                if (!outputFolder.Exists)
                {
                    outputFolder.Create();
                }
                int idx = 1;
                foreach (var record in records)
                {
                    try
                    {
                        string fileName = $"{outputFolder.FullName}/{string.Format(prefixName, idx)}.txt";
                        File.WriteAllLines(fileName, record.OrderBy(ite => ite.Path, StringComparer.InvariantCultureIgnoreCase).Select(ite => ite.Path), System.Text.Encoding.UTF8);
                        idx++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch { }
        }
    }
}