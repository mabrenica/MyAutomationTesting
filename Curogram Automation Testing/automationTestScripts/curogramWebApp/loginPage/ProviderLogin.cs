using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage
{
    [TestFixture]
    [Parallelizable]
    internal class ProviderLogin
    {
        public static String? WindowRoot;
        public static String? Window1;
        public static String? Window2;

        public static void ModifyVars()
        {
            SeleniumCommands a = new SeleniumCommands();
            WindowRoot = a.StringGenerator("alphanumeric", 9);
            Window1 = a.StringGenerator("alphanumeric", 9);
            Window2 = a.StringGenerator("alphanumeric", 9);

        }




        public void ProviderLoginSuccess()
        {
            ModifyVars();
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Curogram Web Provider Login Success");

            try
            {
                a.StartDriver("Chrome");
                a.SaveWindow(WindowRoot, 0);
                a.NavTo("https://staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//a[contains(@href, \'/login?hsLang=en\')]");
                a.Pause(5);
                a.Type("//input[@type=\'text\']", "testrigorcpuser@curogram.com");
                a.Pause(3);
                a.Type("//input[@type=\'password\']", "password1");
                a.Pause(3);
                a.ClickOn("//button[@type=\'submit\']");
                a.Pause(7);
                a.VerifyText("//section/div/div", "Quick Actions");
                a.DClose();

                //Test Pass
                TestLogger.Logger("Curogram Web Provider Login Success: Pass");
            }
            //Test Fail
            catch (Exception e) 
            {
                string message = "Curogram Web Provider Login Success: Fail - -";
                TestLogger.Logger(message + e.Message);
                Console.WriteLine(message + e.Message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }




        public void IncorrectPassword()
        {
            ModifyVars();
            SeleniumCommands a = new();
            Console.WriteLine("Testing: Curogram Web Incorrect Password");

            try
            {
                a.StartDriver("Chrome");
                a.SaveWindow(WindowRoot, 0);
                a.NavTo("https://staging.curogram.com/");
                a.Pause(5);
                a.ClickOn("//a[contains(@href, \'/login?hsLang=en\')]");
                a.Pause(7);
                a.TypeM("//input[@type=\'text\']", "testrigorcpuser@curogram.com");
                a.Pause(2);
                a.TypeM("//input[@type=\'password\']", "incorrect");
                a.Pause(2);
                a.ClickOn("//button[@type=\'submit\']");
                a.Pause(5);
                a.VerifyText("//div[@class=\'alert-red text-center\']", "Your password is not matching our records.");
                a.DClose();

                //Test Pass
                TestLogger.Logger("Curogram Web Provider incorrect password test: Pass");
            }

            catch (Exception e)
            {
                string message = "Curogram Web Provider incorrect password test: Fail - -";
                TestLogger.Logger(message + e.Message);
                Console.WriteLine(message + e.Message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }



        public void IncorrectEmailFormat()
        {
            ModifyVars();
            SeleniumCommands a = new();
            Console.WriteLine("Testing: Curogram Web Incorrect Email Format Test");

            try
            {
                a.StartDriver("Chrome");
                a.SaveWindow(WindowRoot, 0);
                a.NavTo("https://staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//a[contains(@href, \'/login?hsLang=en\')]");
                a.Pause(5);
                a.TypeM("//input[@type=\'text\']", "incorrectemailformat");
                a.Pause(2);
                a.ClickOn("//input[@type=\'password\']");
                a.Pause(3);
                a.VerifyText("//curo-validation-messages/div", "You entered wrong email or phone number. Example: example@example.com, 1234567890");
                a.DClose();

                //Test Pass
                TestLogger.Logger("Curogram Web Incorrect Email Format: Pass");
            }

            catch (Exception e) 
            {
                string message = "Curogram Web Incorrect Email Format: Fail - -";
                TestLogger.Logger(message + e.Message);
                Console.WriteLine(message + e.Message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }




        [Test]
        public void ProviderLoginTest()
        {
            ProviderLogin a= new();
            a.IncorrectPassword();
            a.ProviderLoginSuccess();
            a.IncorrectEmailFormat();

        }

    }
}
