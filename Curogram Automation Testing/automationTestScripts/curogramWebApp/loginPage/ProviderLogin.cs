using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.appManager;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage
{
    [TestFixture]
    [Parallelizable]
    internal class ProviderLogin
    {
        private IWebDriver? driver;
        public IDictionary<string, object>? vars { get; private set; }
        private IJavaScriptExecutor? js;


        public void ProviderLoginSuccess()
        {
            driver = new FirefoxDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
            try
            {
                Console.WriteLine("Testing: Provider Login Success");
                var siteTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                siteTimeout.Until(webDriver =>
                {
                    driver.Navigate().GoToUrl("https://staging.curogram.com/");
                    return true;
                });
                driver.Navigate().Refresh();
                driver.Manage().Window.Maximize();

                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                driver.FindElement(By.XPath("//a[contains(@href, \'/login?hsLang=en\')]")).Click();
                driver.FindElement(By.XPath("//input[@type=\'text\']")).Click();
                driver.FindElement(By.XPath("//input[@type=\'text\']")).SendKeys("testrigorcpuser@curogram.com");
                driver.FindElement(By.XPath("//input[@type=\'password\']")).Click();
                driver.FindElement(By.XPath("//input[@type=\'password\']")).SendKeys("password1");
                driver.FindElement(By.XPath("//button[@type=\'submit\']")).Click();
                {
                    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElements(By.XPath("//section/div/div")).Count > 0);
                }
                Assert.That(driver.FindElement(By.XPath("//section/div/div")).Text, Is.EqualTo("Quick Actions"));
                driver.Close();

                TestLogger.Logger("Provider Login Success: Pass");
            }
            catch (Exception e) 
            {
                TestLogger.Logger("Provider Login Success: Fail - - " + e.Message);
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }

        public void IncorrectPassword()
        {
            driver = new FirefoxDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
            try
            {
                Console.WriteLine("Testing: Provider incorrect login test");
                var siteTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                siteTimeout.Until(webDriver =>
                {
                    driver.Navigate().GoToUrl("https://staging.curogram.com/");
                    return true;
                });
                driver.Navigate().Refresh();
                driver.Manage().Window.Maximize();
                //driver.Manage().Window.Size = new System.Drawing.Size(1305, 700);
                driver.FindElement(By.XPath("//a[contains(@href, \'/login?hsLang=en\')]")).Click();
                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                driver.FindElement(By.XPath("//input[@type=\'text\']")).Click();
                driver.FindElement(By.XPath("//input[@type=\'text\']")).SendKeys("testrigorcpuser@curogram.com");
                driver.FindElement(By.XPath("//input[@type=\'password\']")).Click();
                driver.FindElement(By.XPath("//input[@type=\'password\']")).SendKeys("incorrect");
                driver.FindElement(By.XPath("//button[@type=\'submit\']")).Click();
                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                Assert.That(driver.FindElement(By.XPath("//div[@class=\'alert-red text-center\']")).Text, Is.EqualTo("Your password is not matching our records."));
                driver.Close();

                TestLogger.Logger("Provider incorrect login test: Pass");
            }
            catch (Exception e)
            {

                TestLogger.Logger("Provider incorrect login test: Fail - -" + e.Message);
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }

        public void IncorrectEmailFormat()
        {
            driver = new FirefoxDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
            try
            {
                Console.WriteLine("Testing: Incorrect Email Format");
                var siteTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                siteTimeout.Until(webDriver =>
                {
                    driver.Navigate().GoToUrl("https://staging.curogram.com/");
                    return true;
                });
                driver.Navigate().Refresh();
                driver.Manage().Window.Maximize();
                //driver.Manage().Window.Size = new System.Drawing.Size(1305, 700);
                driver.FindElement(By.XPath("//a[contains(@href, \'/login?hsLang=en\')]")).Click();
                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                driver.FindElement(By.XPath("//input[@type=\'text\']")).Click();
                driver.FindElement(By.XPath("//input[@type=\'text\']")).SendKeys("incorrectemailformat");
                driver.FindElement(By.XPath("//input[@type=\'password\']")).Click();
                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                Assert.That(driver.FindElement(By.XPath("//curo-validation-messages/div")).Text, Is.EqualTo("You entered wrong email or phone number. Example: example@example.com, 1234567890"));
                driver.Close();

                TestLogger.Logger("Incorrect Email Format: Pass");
            }
            catch (Exception e) { 

                TestLogger.Logger("Incorrect Email Format: Fail- -" + e.Message);
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }

        [Test]
        public void ProviderLoginTest()
        {
            ProviderLogin a= new ProviderLogin();
            a.IncorrectPassword();
            a.ProviderLoginSuccess();
            a.IncorrectEmailFormat();

        }

    }
}
