using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Curogram_Automation_Testing.appManager;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.AddUsers
{

    [TestFixture]
    [Parallelizable]
    public class AddUserTest
    {
        private IWebDriver? driver;
        public IDictionary<string, object>? vars { get; private set; }
        private IJavaScriptExecutor? js;

        public string waitForWindow(int timeout)
        {
            try
            {
                Thread.Sleep(timeout);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            var whNow = (driver.WindowHandles as IReadOnlyCollection<object>).ToList();
            var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
            if (whNow.Count > whThen.Count)
            {
                return whNow.Except(whThen).First().ToString();
            }
            else
            {
                return whNow.First().ToString();
            }
        }
        [Test]
        public void addUser()
        {
            driver = new FirefoxDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();

            try
            {
                Console.WriteLine("Testing: Add a user");
                var siteTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                siteTimeout.Until(webDriver =>
                {
                    driver.Navigate().GoToUrl("https://cp.staging.curogram.com/");
                    return true;
                });
                driver.Navigate().Refresh();
                driver.Manage().Window.Size = new System.Drawing.Size(1305, 700);
                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                vars["WindowHandles"] = driver.WindowHandles;
                driver.FindElement(By.XPath("//div[contains(.,\'Sign In\')]")).Click();
                vars["win188"] = waitForWindow(10000);
                try
                {
                    Thread.Sleep(7000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                vars["root"] = driver.CurrentWindowHandle;
                driver.SwitchTo().Window(vars["win188"].ToString());
                driver.FindElement(By.XPath("//input[@id=\'login-email\']")).Click();
                driver.FindElement(By.XPath("//input[@id=\'login-email\']")).SendKeys("testrigorcpuser@curogram.com");
                driver.FindElement(By.XPath("//input[@id=\'login-password\']")).Click();
                driver.FindElement(By.XPath("//input[@id=\'login-password\']")).SendKeys("password1");
                driver.FindElement(By.XPath("//span[contains(.,\'Log in\')]")).Click();
                driver.SwitchTo().Window(vars["root"].ToString());
                {
                    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
                    wait.Until(driver => driver.FindElements(By.XPath("//a[contains(text(),\'Admin panel\')]")).Count > 0);
                }
                Assert.That(driver.FindElement(By.XPath("//a[contains(text(),\'Admin panel\')]")).Text, Is.EqualTo("Admin panel"));
                driver.FindElement(By.XPath("//span[contains(.,\'Practices\')]")).Click();
                driver.FindElement(By.XPath("//input[@type=\'text\']")).Click();
                driver.FindElement(By.XPath("//input[@type=\'text\']")).SendKeys("testrigor automation general");
                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                driver.FindElement(By.XPath("//a[contains(text(),\'TestRigor Automation General (Do not change settings)\')]")).Click();
                {
                    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElements(By.XPath("//div[5]/div[2]/div")).Count > 0);
                }
                driver.FindElement(By.XPath("//div[5]/div[2]/div")).Click();
                {
                    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElements(By.XPath("(//input[@type=\'text\'])[2]")).Count > 0);
                }
                driver.FindElement(By.XPath("(//input[@type=\'text\'])[2]")).Click();
                driver.FindElement(By.XPath("(//input[@type=\'text\'])[2]")).SendKeys("Testrigor");
                Thread.Sleep(3000);
                vars["WindowHandles"] = driver.WindowHandles;
                driver.FindElement(By.XPath("//curogram-intel-provider-actions/div/i")).Click();
                vars["win3500"] = waitForWindow(2000);
                driver.SwitchTo().Window(vars["win3500"].ToString());
                driver.SwitchTo().Window(vars["root"].ToString());
                driver.Close();
                driver.SwitchTo().Window(vars["win3500"].ToString());
                {
                    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Settings')]")).Count > 0);
                }
                driver.FindElement(By.XPath("//span[contains(.,\'Settings\')]")).Click();
                {
                    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElements(By.XPath("//a[4]/div")).Count > 0);
                }
                driver.FindElement(By.XPath("//a[4]/div")).Click();
                {
                    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElements(By.XPath("//button[contains(.,\'Add\')]")).Count > 0);
                }
                driver.FindElement(By.XPath("//button[contains(.,\'Add\')]")).Click();

                Random rand = new Random();

                var email = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz0123456789", 9)
                    .Select(s => s[rand.Next(s.Length)]).ToArray()) + "@email.com";
                var firstName = char.ToUpper(new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 9)
                    .Select(s => s[rand.Next(s.Length)]).ToArray())[0]) + new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 9)
                    .Select(s => s[rand.Next(s.Length)]).ToArray()).Substring(1);
                var lastName = char.ToUpper(new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 9)
                    .Select(s => s[rand.Next(s.Length)]).ToArray())[0]) + new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 9)
                    .Select(s => s[rand.Next(s.Length)]).ToArray()).Substring(1);
                var fullName = firstName + " " + lastName;


                Thread.Sleep(2000);
                IWebElement inputField = driver.FindElement(By.XPath("//input[@type=\'email\']"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].value = '" + email + "';", inputField);
                driver.FindElement(By.XPath("//input[@type=\'email\']")).SendKeys(" ");
                driver.FindElement(By.XPath("//input[@type=\'email\']")).SendKeys(Keys.Backspace);
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                IWebElement firstNameInput = driver.FindElement(By.XPath("(//input[@type=\'text\'])[3]"));
                js.ExecuteScript("arguments[0].value = '" + firstName + "';", firstNameInput);
                driver.FindElement(By.XPath("(//input[@type=\'text\'])[3]")).Click();
                driver.FindElement(By.XPath("(//input[@type=\'text\'])[3]")).SendKeys(" ");
                driver.FindElement(By.XPath("(//input[@type=\'text\'])[3]")).SendKeys(Keys.Backspace);
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }

                IWebElement lastNameInput = driver.FindElement(By.XPath("(//input[@type=\'text\'])[4]"));
                js.ExecuteScript("arguments[0].value = '" + lastName + "';", lastNameInput);
                driver.FindElement(By.XPath("(//input[@type=\'text\'])[4]")).Click();
                driver.FindElement(By.XPath("(//input[@type=\'text\'])[4]")).SendKeys(" ");
                driver.FindElement(By.XPath("(//input[@type=\'text\'])[4]")).SendKeys(Keys.Backspace);
                try
                {
                    Thread.Sleep(3000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                driver.FindElement(By.XPath("//ui-switch[@formcontrolname=\'isAdmin\']/button[@type=\'button\']")).Click();
                driver.FindElement(By.XPath("//button[contains(.,\'Invite\')]")).Click();
                try
                {
                    Thread.Sleep(3000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                driver.FindElement(By.XPath("//input[@placeholder=\'Find by name or phone number...\']")).Click();
                IWebElement fullNameInput = driver.FindElement(By.XPath("//input[@placeholder='Find by name or phone number...']"));
                js.ExecuteScript("arguments[0].value = '" + firstName + "';", fullNameInput);
                driver.FindElement(By.XPath("//input[@placeholder=\'Find by name or phone number...\']")).Click();
                driver.FindElement(By.XPath("//input[@placeholder=\'Find by name or phone number...\']")).SendKeys(" ");
                driver.FindElement(By.XPath("//input[@placeholder=\'Find by name or phone number...\']")).SendKeys(Keys.Backspace);
                try
                {
                    Thread.Sleep(7000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                Assert.That(driver.FindElement(By.XPath("//div[@class='user-info__name user-info__name--cropped user-info__name--offset']")).Text, Is.EqualTo(fullName));
                driver.FindElement(By.XPath("//curogram-icon[@name='trash']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@class='btn btn-danger'][1]")).Click();
                driver.Close();
                TestLogger.Logger("Add Users Test: Pass");
            }
                        
            catch (Exception e) 
            {
                TestLogger.Logger("Add user test: Fail - - " + e.Message);
                var result = e.Message;
                driver.Quit();
                Assert.That(result, Is.EqualTo(""));
            }
}
    }








































}