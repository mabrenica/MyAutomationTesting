using Curogram_Automation_Testing.App_manager;
using Curogram_Automation_Testing.AppManager;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;

namespace Curogram_Automation_Testing
{
    internal class Program
    {
        private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
        .AddFilter("Test", LogLevel.Information)
        .AddFilter("Testing", LogLevel.Information)
        .AddFilter("Microsoft", LogLevel.Error)
        .AddFilter("System", LogLevel.Error)
        .AddConsole();
        });

        static void Main(string[] args)
        {
            var logger = loggerFactory.CreateLogger<Program>();

            // import methods and declare objects
            UserInterface initProg = new UserInterface();
            TaskManager startManager = new TaskManager();

            initProg.StartProgram();

            try
            {
                startManager.ParallelRun();
            }
            catch (Exception)
            {
                logger.LogError("Error in test execution");
            }

            logger.LogInformation("Test execution completed.");
        }
    }
}
