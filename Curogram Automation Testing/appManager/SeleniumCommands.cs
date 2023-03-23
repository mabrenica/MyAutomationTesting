using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Data;
using System.Text.RegularExpressions;
using Curogram_Automation_Testing.appManager;
using System.Text;
using Curogram_Automation_Testing.CurogramApi.Other;


namespace Curogram_Automation_Testing.AppManager
{
    public class SeleniumCommands
    {
        public string? Name { get; set; }
        public string? Handle { get; set; }

        public IWebDriver? driver;
        public IDictionary<string, object>? vars { get; private set; }
        private IJavaScriptExecutor? js;
        public List<SeleniumCommands> windows = new List<SeleniumCommands>();

        //1. Start driver 
        public void StartDriver(string browserName, string windowName)
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            var browserSwitch = browserName;

            switch (browserSwitch)
            {
                case "Chrome":
                    ChromeOptions? options = new();
                    options.AddArguments("use-fake-device-for-media-stream");
                    options.AddArguments("use-fake-ui-for-media-stream");
                    options.AddArguments("--disable-notifications");
                    driver = new ChromeDriver(chromeDriverService, options);
                    driver.Manage().Window.Maximize();
                    break;

                case "Firefox":
                    FirefoxOptions foptions = new();
                    driver = new FirefoxDriver(foptions);
                    driver.Manage().Window.Maximize();
                    break;


            }
            Thread.Sleep(3000);           
            string currentHandle = driver.CurrentWindowHandle;
            string wN = windowName;
            windows.Add(new SeleniumCommands { Name = wN, Handle = currentHandle });
        }


        //2. click on element
        public void ClickOn(string elementName)
        {
            {
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.FindElements(By.XPath(elementName)).Count > 0);
            }
            driver.FindElement(By.XPath(elementName)).Click();
            Thread.Sleep(500);
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
        public string StringGenerator(string type= "allletters", int digit = 9)
        {
            Random ranInt = new();
            var seedInt = ranInt.Next();
            Random rand = new(seedInt);
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


            var newString = char.ToUpper(new string(Enumerable.Repeat(allowedChars, digit)
                .Select(s => s[rand.Next(s.Length)]).ToArray())[0]) + new string(Enumerable.Repeat(allowedChars, digit)
                .Select(s => s[rand.Next(s.Length)]).ToArray()).Substring(1);
            return newString;
        }

        //Email Generator
        public string EmailGenerator(string type = "alphanumeric", int digit = 9, string emailDomain = "@curogram.com")
        {
            Random ranInt = new();
            var seedInt = ranInt.Next();
            Random rand = new(seedInt);
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


            var newString = new string(Enumerable.Repeat(allowedChars, digit)
                .Select(s => s[rand.Next(s.Length)]).ToArray()).Substring(1);
            return newString + emailDomain;
        }

        //5. Close current window
        public void DClose()
        {
            driver?.Close();
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
        public void WUntil(string targetElement, int timeOutInSeconds = 30)
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
        public void TypeM(string targetElement, string text, int typeSpeed = 5, int pauseAfterType = 100)
        {
            {
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.FindElements(By.XPath(targetElement)).Count > 0);
            }

            int charCount = text.Length;

            for (int i = 0; i < charCount;)
            {
                driver.FindElement(By.XPath(targetElement)).SendKeys(Char.ToString(text[i++]));
                Thread.Sleep(typeSpeed);
            };
            //Thread.Sleep(pauseAfterType);
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
        public void VerifyText(string element, string textToVerify)
        {
            Assert.That(driver.FindElement(By.XPath(element)).Text, Is.EqualTo(textToVerify));    
        }

        //17. Refresh Page
        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        //18. Refresh page until element is displayed
        public void RefreshUntil(string element)
        {
            bool isElementDisplayed = false;

            for (int a = 0; a < 10 && !isElementDisplayed; a++)
            {
                Thread.Sleep(5000);
                driver.Navigate().Refresh();
                try
                {
                    isElementDisplayed = driver.FindElement(By.XPath(element)).Displayed;
                }
                catch (NoSuchElementException)
                {
                    isElementDisplayed = false;
                }
            }
        }

        //19. Extract OTP from element
        public string GetOtp(string element)
        {
            string textFromElement = driver.FindElement(By.XPath(element)).Text;
            Regex regex = new Regex(@"\d{6}");
            Match match = regex.Match(textFromElement);
            string otpCode = match.Value;
            return otpCode;
        }

        //20. Type OTP code
        public void TypeCode(string otpCode, string element, int otpDigitCount = 6)
        {
            var otpDigit = 0;
            int elementDigit = 1;

            for (int counter = 0; counter < otpDigitCount;)
            {
                string otpSingle = otpCode[otpDigit].ToString();
                driver.FindElement(By.XPath(element + $"[{elementDigit}]")).SendKeys(otpSingle);
                counter++;
                elementDigit++;
                otpDigit++;
            }
        }

        //21. Upload image file
        public void UploadImage(string element)
        {
            string fileName = "test_image.png";
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            driver.FindElement(By.XPath(element)).SendKeys(imagePath);

        }


        //22. Draw signature
        public void DrawSign(string element)
        {
            var signElement = driver.FindElement(By.XPath(element));
            Actions builder = new(driver);
            builder.MoveToElement(signElement, 0, 0).Perform();
            builder.ClickAndHold().Perform();
            builder.MoveByOffset(50, 0).Perform();
            builder.MoveByOffset(0, 50).Perform();
            builder.MoveByOffset(-50, 0).Perform();
            builder.MoveByOffset(0, -50).Perform();
            builder.Release().Perform();
        }

        //23. Input text within iFrame
        public void iFrameInput(string iFrameName, string elementName, string textInput, int pauseAfterChar = 10)
        {
            js = (IJavaScriptExecutor)driver;

            IWebElement iframe = driver.FindElement(By.XPath(iFrameName));
            driver.SwitchTo().Frame(iframe);

            int charCount = textInput.Length;
            for (int i = 0; i < charCount;)
            {
                driver.FindElement(By.XPath(elementName)).SendKeys(Char.ToString(textInput[i++]));
                Thread.Sleep(pauseAfterChar);
            };
            driver.SwitchTo().DefaultContent();
        }

        public void AddLog(string logType, string message)
        {
           switch (logType) 
            { 
                case "event":
                TestLogger.EventLogger(message); 
                    break;


                case "summary":
                    TestLogger.Logger(message); 
                    break;

                case "allType":
                    TestLogger.Logger(message);
                    TestLogger.EventLogger(message);                  
                    break;
            }
        }

        public string OtpViaMailSac(string email)
        {
            MailsacGetOtp a = new();
            string otp = a.GetOTP(email);
            return otp;
        }

        public void GenerateOtpEmail(string email, string mailsacKey = "k_rtJ7fZ6197XAsC5f4Ujyp2477Xc479U0rI4tg66ef")
        {
            GenerateMailsacEmail a = new();
            a.Generate(generatedEmail: email, passedMailsacKey: mailsacKey).Wait();
        }
    }
}
