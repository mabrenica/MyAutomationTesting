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
using NUnit.Framework;
using System.Runtime.ExceptionServices;
using System.Timers;

namespace Curogram_Automation_Testing.appManager
{
    internal class SeleniumCommands
    {
        private IWebDriver? driver = new FirefoxDriver();
        public IDictionary<string, object>? vars { get; private set; }
        private IJavaScriptExecutor? js;

        //click on element
        public void ClickOn(string elementName)
        {
            driver.FindElement(By.XPath(elementName)).Click();
        }

        //navigate to a website
        public void NavTo(string siteUrl)
        {
            driver.Navigate().GoToUrl(siteUrl);
        }

        //generate random strings
        public string StringGenerator(int Seed)
        {
            Random rand = new Random(Seed);
            var newString = char.ToUpper(new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 9)
                .Select(s => s[rand.Next(s.Length)]).ToArray())[0]) + new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 9)
                .Select(s => s[rand.Next(s.Length)]).ToArray()).Substring(1);
            return newString;
        }

        //Quit driver
        public void DQuit()
        {
            driver.Close();
        }

        //Pause
        public void Pause(int time)
        {
            Thread.Sleep(time);

        }
    }
}
