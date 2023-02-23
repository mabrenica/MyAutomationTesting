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
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using System.Data;
using System.Security.Principal;
using NUnit.Framework.Constraints;

namespace Curogram_Automation_Testing.AppManager
{
    internal class SeleniumCommands
    {
        private IWebDriver driver;
        public IDictionary<string, object>? vars { get; private set; }
        private IJavaScriptExecutor js;
        public static List<string> windows = new List<string>();

        //1. Start driver and save window as root [0]
        public void StartDriver()
        {
                     
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("use-fake-device-for-media-stream"); 
            options.AddArguments("use-fake-ui-for-media-stream");
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            SeleniumCommands.windows.Add(driver.WindowHandles[0]);
        }


        //2. click on element
        public void ClickOn(string elementName)
        {
            driver.FindElement(By.XPath(elementName)).Click();
        }


        //3. navigate to a website
        public void NavTo(string siteUrl)
        {
            Task.Run(() =>
            {               
                driver.Navigate().GoToUrl(siteUrl);
            }).Wait(TimeSpan.FromSeconds(30));

            driver.Navigate().Refresh();
        }


        //4. generate random strings
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


        //5. Close current window
        public void DClose()
        {
            driver.Close();
        }


        //6. Pause
        public void Pause(int timeInSeconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeInSeconds));

        }


        //7. Send Key
        public void Type(string targetElement, string textInput)
        {
            js = (IJavaScriptExecutor)driver;
            IWebElement inputField = driver.FindElement(By.XPath(targetElement));
            js.ExecuteScript("arguments[0].value = '" + textInput + "';", inputField);
            driver.FindElement(By.XPath(targetElement)).Click();
            driver.FindElement(By.XPath(targetElement)).SendKeys(" ");
            driver.FindElement(By.XPath(targetElement)).SendKeys(Keys.Backspace);
        }


        //8. Close entire driver
        public void DQuit()
        {
            driver.Quit();
        }


        //9. Wait until element is present
        public void WUntil(int timeOutInSeconds, string targetElement)
        {
            {
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(driver => driver.FindElements(By.XPath(targetElement)).Count > 0);
            }
        }


        //10. Open new window
        public void newWindow(int windowNum)
        {
            driver.SwitchTo().NewWindow(WindowType.Window);
            SeleniumCommands.windows.Add(driver.WindowHandles[windowNum]);
        }


        //11. Save open window
        public void saveWindow(int windowNum)
        {
            SeleniumCommands.windows.Add(driver.WindowHandles[windowNum]);
        }


        //12. Switch to window
        public void SwitchWin(int windowNum)
        {
            driver.SwitchTo().Window(SeleniumCommands.windows[windowNum]);
        }

        //13. Save element text and returns value
        public string SaveText(string elementName)
        {
            var textName = driver.FindElement(By.XPath(elementName)).Text;
            return textName;
        }

        //14.Verify if element is present
        public string CheckElement(string elementName)
        {
            bool targetElement = driver.FindElement(By.XPath(elementName)).Displayed;
            if (targetElement)
            {
                return "Passed";
            }
            else
            {
                throw new Exception($"Element not found: " + elementName);
            };
            
        }


        //15. Simulate Manual typing
        public void TypeM(string targetElement, string text)
        {
            int charCount = text.Length;

            for (int i = 0; i < charCount;) {           
                driver.FindElement(By.XPath(targetElement)).SendKeys(Char.ToString(text[i++]));
                Thread.Sleep(50);
            };
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(targetElement)).SendKeys(Keys.Space);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(targetElement)).SendKeys(Keys.Backspace);
        }

    }
}
