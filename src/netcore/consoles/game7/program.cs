using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using game7.actions;
using Newtonsoft.Json;

namespace game7
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
                    "-f", "--folder",
                    "-o", "--output",
                    "--numberOfThreads"
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

                string workingFolderPath = Directory.GetCurrentDirectory();

                string driverFolderPath = $"{workingFolderPath}/drivers";
                string executePath = $"{workingFolderPath}/browsers/chrome/chrome.exe";

                string testLoginFilePath = $"{workingFolderPath}/tasks/test-login.json";
                if (File.Exists(testLoginFilePath))
                {
                    string json = File.ReadAllText(testLoginFilePath, System.Text.Encoding.UTF8);
                    List<models.LoginInfo> paramObjs = JsonConvert.DeserializeObject<List<models.LoginInfo>>(json);
                    if (paramObjs?.Count > 0)
                    {
                        if (nThreads == -1)
                        {
                            paramObjs.ParallelRun(infoObj => _run(workingFolderPath, driverFolderPath, executePath, infoObj), paramObjs.Count);
                        }
                        else
                        {
                            paramObjs.ParallelRun(infoObj => _run(workingFolderPath, driverFolderPath, executePath, infoObj), nThreads);
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

        static Task _run(string workingFolderPath, string driverFolderPath, string executePath, models.LoginInfo infoObj)
        {
            try
            {
                LoginAction actionObj = new LoginAction
                {
                    Username = infoObj.Username,
                    Password = infoObj.Password,
                    TakeScreenshot = !string.IsNullOrWhiteSpace(infoObj.ScreenshotFileNameFormat) ? "1" : "0",
                    ScreenShotFileName = $"{workingFolderPath}/temp/screenshots/{infoObj.ScreenshotFileNameFormat}.png"
                };
                var client = new VSSystem.ThirdParty.Selenium.Client();
                var taskParamsObj = new VSSystem.ThirdParty.Selenium.Actions.ActionTask("Test web chrome")
                {
                    IsIncognito = true,
                    Browser = "chrome",
                    Sections = actionObj.ToWebActions(infoObj.Url, infoObj.ScreenshotFileNameFormat)
                };

                client.Execute(new VSSystem.ThirdParty.Selenium.Actions.ActionTask[] { taskParamsObj }, driverFolderPath, executePath,
                    errorLogAction: ex =>
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine(ex.InnerException.Message);
                            Console.WriteLine(ex.InnerException.StackTrace);
                        }
                    }
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}