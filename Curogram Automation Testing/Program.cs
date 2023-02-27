using Curogram_Automation_Testing.App_manager;
using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;

namespace Curogram_Automation_Testing
{
    internal class Program
    {


        static void Main(string[] args)
        {

            // import methods and declare objects
            UserInterface a = new UserInterface();
            TaskManager c = new TaskManager();

            a.StartProgram();

            try
            {
                c.ParallelRun();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in test execution");
            }
            TestLogger.FilterAndDisplayLogs();
        }
    }
}
