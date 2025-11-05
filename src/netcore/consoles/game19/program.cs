using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace game19
{
    class Program
    {
        static Task Main(string[] args)
        {
            try
            {
                Dictionary<string, string> mArgs = VSSystem.IO.CommandLine.GetCommandLineArgs(new string[]
                {
                    "-template-file",
                    "-number-of-samples",
                    "-output-folder",
                    "-configs-file",
                    "-file-name-format",
                });


                string configFileName = mArgs.ContainsKey("-configs-file") ? mArgs["-configs-file"] : null;
                if (!string.IsNullOrWhiteSpace(configFileName))
                {
                    var configs = new Configs(configFileName);
                    if (configs != null)
                    {
                        GenerateSample(configs);
                    }
                }
                else
                {
                    string templateFileName = mArgs.ContainsKey("-template-file") ? mArgs["-template-file"] : "template.xml";
                    string sNumberOfSamples = mArgs.ContainsKey("-number-of-samples") ? mArgs["-number-of-samples"] : "100";
                    int.TryParse(sNumberOfSamples, out int numberOfSamples);
                    string outputFolder = mArgs.ContainsKey("-output-folder") ? mArgs["-output-folder"] : "samples";
                    string fileNameFormat = mArgs.ContainsKey("-file-name-format") ? mArgs["-file-name-format"] : "{0}_{1:yyyyMMddHHmmss}_{2:0000}.xml";
                    GenerateSample(templateFileName, numberOfSamples, outputFolder, fileNameFormat);
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
        static void GenerateSample(Configs configs)
        {
            GenerateSample(configs.TemplateFilePath, configs.NumberOfSamples ?? 100, configs.OutputFolderPath, configs.FileNameFormat);
        }
        static void GenerateSample(string templateFile, int numberOfSamples, string outputFolder, string fileNameFormat)
        {
            Console.WriteLine("Generating samples...");
            try
            {
                DirectoryInfo outputDir = new DirectoryInfo(outputFolder);
                if (!outputDir.Exists)
                {
                    outputDir.Create();
                }
                Template template = new Template(templateFile);
                for (int i = 0; i < numberOfSamples; i++)
                {
                    try
                    {
                        string outputFileName = Path.Combine(outputDir.FullName, $"{DateTime.UtcNow.Ticks}_{i + 1:0000}.xml");
                        if (!string.IsNullOrWhiteSpace(fileNameFormat))
                        {
                            outputFileName = outputDir.FullName + "/" + string.Format(fileNameFormat, DateTime.UtcNow.Ticks, DateTime.UtcNow, i + 1);
                        }
                        template.SetValues("PlateUpload/InfoCar/Record/EventID", Guid.NewGuid().ToString().ToUpperInvariant());
                        template.Save(outputFileName);
                        Thread.Sleep(10);

                        if (i > 0 && (i % 100) == 0)
                        {
                            Console.WriteLine($"  {i} samples generated...");
                        }
                    }
                    catch { }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Sample generation completed successfully.");
        }

    }
}