using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V107.ServiceWorker;
using Curogram_Automation_Testing.App_manager;
using Curogram_Automation_Testing.appManager;

namespace Curogram_Automation_Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //import methods adn declare objects
            UserInterface initProg = new UserInterface();
            TaskManager startManager = new TaskManager();








            initProg.StartProgram();

            try
            {
                startManager.ParallelRun();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in test execution");
            }










        }
    }
}