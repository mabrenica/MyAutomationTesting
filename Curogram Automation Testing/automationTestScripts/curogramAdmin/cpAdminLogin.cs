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
        }

        public void loginSuccess()
        {
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
        }


        public void incorrectEmailFormat()
        {
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
            Thread.Sleep(3000);
            var elements = driver.FindElements(By.XPath("//div[@class=\'bubble-error alert-red\']"));
            Assert.True(elements.Count > 0);
            driver.Close();
            driver.SwitchTo().Window(rootWindow);
            driver.Close();
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