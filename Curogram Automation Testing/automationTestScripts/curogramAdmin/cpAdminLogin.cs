using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;


namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramAdmin
{
    [TestFixture]
    [Parallelizable]
    public class CpAdminLoginTest
    {
        private IWebDriver driver;

        public void incorrectPassword()
        {
            try { 
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://cp.staging.curogram.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(10000);
            string rootWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.XPath("//div[contains(.,\'Sign In\')]")).Click();
            string window2 = driver.WindowHandles[1];
            driver.SwitchTo().Window(window2);
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//input[@id=\'login-email\']")).Click();
            driver.FindElement(By.XPath("//input[@id=\'login-email\']")).SendKeys("testrigorcpuser@curogram.com");
            driver.FindElement(By.XPath("//input[@id=\'login-password\']")).Click();
            driver.FindElement(By.XPath("//input[@id=\'login-password\']")).SendKeys("incorrectpassword");
            Thread.Sleep(5000);         
            driver.FindElement(By.XPath("//span[contains(.,\'Log in\')]")).Click();
            Thread.Sleep(5000);
            Assert.That(driver.FindElement(By.XPath("//div[@class=\'alert-red\']")).Text, Is.EqualTo("Your password is not matching our records."));
            driver.Close();
            driver.SwitchTo().Window(rootWindow);
            driver.Close();
            Console.WriteLine("Incorrect Password Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                Console.WriteLine("Incorrect Password Test: Fail");
                Console.Write("Reason: " + e.Message);
                var result = e.Message;
                driver.Quit();
                Assert.That(result, Is.EqualTo("Pass"));
            }
        }

        public void loginSuccess()
        {
            try { 
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://cp.staging.curogram.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(10000);
            string rootWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.XPath("//div[contains(.,\'Sign In\')]")).Click();
            string window2 = driver.WindowHandles[1];
            driver.SwitchTo().Window(window2);
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//input[@id=\'login-email\']")).Click();
            driver.FindElement(By.XPath("//input[@id=\'login-email\']")).SendKeys("testrigorcpuser@curogram.com");
            driver.FindElement(By.XPath("//input[@id=\'login-password\']")).Click();
            driver.FindElement(By.XPath("//input[@id=\'login-password\']")).SendKeys("password1");
            driver.FindElement(By.XPath("//span[contains(.,\'Log in\')]")).Click();
            driver.SwitchTo().Window(rootWindow);
            Thread.Sleep(10000);
            Assert.That(driver.FindElement(By.XPath("//a[contains(text(),\'Admin panel\')]")).Text, Is.EqualTo("Admin panel"));
            driver.Close();
            Console.WriteLine("Login Success Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                Console.WriteLine("Login Success Test: Fail");
                Console.Write("Reason: " + e.Message);
                var result = e.Message;
                driver.Quit();
                Assert.That(result, Is.EqualTo("Pass"));
            }
        }


        public void incorrectEmailFormat()
        {
            try { 
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://cp.staging.curogram.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(10000);
            string rootWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.XPath("//div[contains(.,\'Sign In\')]")).Click();
            Thread.Sleep(10000);
            string window2 = driver.WindowHandles[1];
            driver.SwitchTo().Window(window2);
            driver.FindElement(By.XPath("//input[@id=\'login-email\']")).Click();
            driver.FindElement(By.XPath("//input[@id=\'login-email\']")).SendKeys("incorrectemailformat");
            driver.FindElement(By.XPath("//input[@id=\'login-password\']")).Click();
            Thread.Sleep(5000);
            var elements = driver.FindElements(By.XPath("//div[@class=\'bubble-error alert-red\']"));
            Assert.True(elements.Count > 0);
            driver.Close();
            driver.SwitchTo().Window(rootWindow);
            driver.Close();
            Console.WriteLine("Incorrect Email Format Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                Console.WriteLine("Incorrect Email Format Test: Fail");
                Console.Write("Reason: " + e.Message);
                var result = e.Message;
                driver.Quit();
                Assert.That(result, Is.EqualTo("Pass"));
            }
        }

        [Test]
        public void CpAdminLogin()
        {
            CpAdminLoginTest a = new CpAdminLoginTest();
            a.incorrectEmailFormat();
            a.incorrectPassword();
            a.loginSuccess();
        }
    }
}