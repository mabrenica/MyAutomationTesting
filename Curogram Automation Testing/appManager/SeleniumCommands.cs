﻿using System;
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
using NUnit.Framework;
using System.Runtime.ExceptionServices;
using System.Timers;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using System.Data;
using System.Security.Principal;

namespace Curogram_Automation_Testing.AppManager
{
    internal class SeleniumCommands
    {
        private IWebDriver driver;
        public IDictionary<string, object>? vars { get; private set; }
        private IJavaScriptExecutor js;
        public static List<string> windows = new List<string>();

        //Start driver
        public void StartDriver()
        {
                     
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("use-fake-device-for-media-stream"); 
            options.AddArguments("use-fake-ui-for-media-stream");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            SeleniumCommands.windows.Add(driver.WindowHandles[0]);
        }


        //click on element
        public void ClickOn(string elementName)
        {
            driver.FindElement(By.XPath(elementName)).Click();
        }


        //navigate to a website
        public void NavTo(string siteUrl)
        {
            Task.Run(() =>
            {               
                driver.Navigate().GoToUrl(siteUrl);
            }).Wait(TimeSpan.FromSeconds(30));

            driver.Navigate().Refresh();
        }


        //generate random strings
        public string StringGenerator(string type)
        {
            Random ranInt = new Random();
            var seedInt = ranInt.Next();
            Random rand = new Random(seedInt);
            string allowedChars = "";

            switch (type)
            {
                case "alphaneumeric":
                    allowedChars = "abcdefghijklmnopqrstuvwxyz0123456789";
                    break;
                case "allletters":
                    allowedChars = "abcdefghijklmnopqrstuvwxyz";
                    break;
                case "allnumbers":
                    allowedChars = "0123456789";
                    break;
                default:
                    allowedChars = "abcdefghijklmnopqrstuvwxyz0123456789";
                    break;
            }


            var newString = char.ToUpper(new string(Enumerable.Repeat(allowedChars, 9)
                .Select(s => s[rand.Next(s.Length)]).ToArray())[0]) + new string(Enumerable.Repeat(allowedChars, 9)
                .Select(s => s[rand.Next(s.Length)]).ToArray()).Substring(1);
            return newString;
        }


        //Quit driver
        public void DClose()
        {
            driver.Close();
        }


        //Pause
        public void Pause(int timeInSeconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeInSeconds));

        }


        //Send Key
        public void Type(string targetElement, string textInput)
        {
            js = (IJavaScriptExecutor)driver;
            IWebElement inputField = driver.FindElement(By.XPath(targetElement));
            js.ExecuteScript("arguments[0].value = '" + textInput + "';", inputField);
            driver.FindElement(By.XPath(targetElement)).Click();
            driver.FindElement(By.XPath(targetElement)).SendKeys(" ");
            driver.FindElement(By.XPath(targetElement)).SendKeys(Keys.Backspace);
        }


        //Close the driver
        public void DQuit()
        {
            driver.Quit();
        }


        //Wait until element is present
        public void WUntil(int timeOutInSeconds, string targetElement)
        {
            {
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(driver => driver.FindElements(By.XPath(targetElement)).Count > 0);
            }
        }


        //Open new window
        public void newWindow(int windowNum)
        {
            driver.SwitchTo().NewWindow(WindowType.Window);
            SeleniumCommands.windows.Add(driver.WindowHandles[windowNum]);
        }


        //Save open window
        public void saveWindow(int windowNum)
        {
            SeleniumCommands.windows.Add(driver.WindowHandles[windowNum]);
        }


        //Switch to window
        public void SwitchWin(int windowNum)
        {
            driver.SwitchTo().Window(SeleniumCommands.windows[windowNum]);
        }

        [Test]
        public void addList()
        {
            SeleniumCommands.windows.Add( new string("testwindow"));
            Console.WriteLine(SeleniumCommands.windows[0]);
         }
    }
}
