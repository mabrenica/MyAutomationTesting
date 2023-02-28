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
        public string? Name { get; set; }
        public string? Handle { get; set; }

        private IWebDriver? driver;
        public IDictionary<string, object>? vars { get; private set; }
        private IJavaScriptExecutor? js;
        public List<SeleniumCommands> windows = new List<SeleniumCommands>();

        //1. Start driver 
        public void StartDriver(string browserName)
        {
            var browserSwitch = browserName;
            
            switch (browserSwitch)
            {
                case "Chrome":
                    ChromeOptions? options = new();
                    options.AddArguments("use-fake-device-for-media-stream");
                    options.AddArguments("use-fake-ui-for-media-stream");
                    options.AddArguments("--disable-notifications");
                    driver = new ChromeDriver(options);
                    driver.Manage().Window.Maximize();
                    break;

                case "Firefox":
                    FirefoxOptions foptions = new();
                    driver = new FirefoxDriver(foptions);
                    driver.Manage().Window.Maximize();
                    break;


            }

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
                case "alphanumeric":
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


        //10. Save element text and returns value
        public string SaveText(string elementName)
        {
            var textName = driver.FindElement(By.XPath(elementName)).Text;
            return textName;
        }

        //11.Verify if element is present
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


        //12. Simulate Manual typing
        public void TypeM(string targetElement, string text)
        {
            int charCount = text.Length;

            for (int i = 0; i < charCount;) {           
                driver.FindElement(By.XPath(targetElement)).SendKeys(Char.ToString(text[i++]));
                Thread.Sleep(50);
            };

        }


        //13. Save Pop up windows
        public void SaveWindow(string windowName, int windowNumber)
        {

            string currentHandle = driver.WindowHandles[windowNumber];
            string wN = windowName;
            windows.Add(new SeleniumCommands { Name = wN, Handle = currentHandle });
        }

        //14. Switch to saved window
        public void SwitchWindow(string windowName)
        {
            string handle = windows.FirstOrDefault(w => w.Name == windowName)?.Handle;
            driver.SwitchTo().Window(handle);
        }

        //15. Start new window and save
        public void StartNewWindow(string windowName)
        {
            driver.SwitchTo().NewWindow(WindowType.Window);
            string currentHandle = driver.CurrentWindowHandle;
            string wN = windowName;
            windows.Add(new SeleniumCommands { Name = wN, Handle = currentHandle });
        }

        //16. Verify text in element
        public string VerifyText(string element, string textToVerify)
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath(element)).Text, Is.EqualTo(textToVerify));
                return "Pass";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //17. Refresh Page
        public void Refresh()
        {
            driver.Navigate().Refresh();
        }


    }
 
    
}
