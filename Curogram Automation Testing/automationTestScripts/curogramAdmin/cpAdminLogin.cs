using NUnit.Framework;
using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;


namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramAdmin
{
    [TestFixture]
    [Parallelizable]
    public class CpAdminLoginTest
    {

        public static String? WindowRoot;
        public static String? Window2;
        public static String? Window3;



        public static void ModifyVars()
        {
            SeleniumCommands a = new();
            var windowroot = a.StringGenerator("alphanumeric", 9);
            var windowProvider = a.StringGenerator("alphanumeric", 9);
            var windowPatient = a.StringGenerator("alphanumeric", 9);


            WindowRoot = windowroot;
            Window2 = windowProvider;
            Window3 = windowPatient;
        }



        public void IncorrectPassword()
        {
            ModifyVars();
            SeleniumCommands a = new();
            Console.WriteLine("Testing: Cp Incorrect Password Test");

            try {
                a.StartDriver("Chrome");
                a.SaveWindow(WindowRoot, 0);
                a.NavTo("https://cp.staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//div[contains(.,'Sign In')]");
                a.SaveWindow(Window2, 1);
                a.SwitchWindow(Window2);
                a.Pause(10);
                a.ClickOn("//input[@id=\'login-email\']");
                a.Type("//input[@id=\'login-email\']", "testrigorcpuser@curogram.com");
                a.Pause(2);
                a.Type("//input[@id=\'login-password\']", "incorrectpassword");
                a.Pause(5);
                a.ClickOn("//span[contains(.,\'Log in\')]");
                a.Pause(5);
                a.VerifyText("//div[@class=\'alert-red\']", "Your password is not matching our records.");
                a.DClose();
                a.SwitchWindow(WindowRoot);
                a.DClose();
                TestLogger.Logger("Cp Incorrect Password Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                string message = "Cp Incorrect Password Test: Fail - - ";
                TestLogger.Logger(message + e.Message);
                Console.WriteLine(message + e.Message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }




        public void LoginSuccess()
        {
            ModifyVars();
            SeleniumCommands a = new();
            Console.WriteLine("Testing: Cp Provider Login Success Test");

            try {
                a.StartDriver("Chrome");
                a.SaveWindow(WindowRoot, 0);
                a.NavTo("https://cp.staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//div[contains(.,\'Sign In\')]");
                a.SaveWindow(Window2, 1);
                a.SwitchWindow(Window2);
                a.Pause(10);
                a.ClickOn("//input[@id=\'login-email\']");
                a.Type("//input[@id=\'login-email\']", "testrigorcpuser@curogram.com");
                a.Pause(2);
                a.Type("//input[@id=\'login-password\']", "password1");
                a.Pause(2);
                a.ClickOn("//span[contains(.,\'Log in\')]");
                a.SwitchWindow(WindowRoot);
                a.Pause(5);
                a.VerifyText("//a[contains(text(),\'Admin panel\')]", "Admin panel");
                a.DClose();

                //Test Pass
                TestLogger.Logger("Cp Provider Login Success Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                string message = "Cp Provider Login Success Test: Fail - - ";
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
            Console.WriteLine("Cp Testing: Incorrect Email Format Test");

            try {
                a.StartDriver("Chrome");
                a.SaveWindow(WindowRoot, 0);
                a.NavTo("https://cp.staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//div[contains(.,\'Sign In\')]");
                a.Pause(10);
                a.SaveWindow(Window2, 1);
                a.SwitchWindow(Window2);
                a.Type("//input[@id=\'login-email\']", "incorrectemailformat");
                a.Pause(2);
                a.ClickOn("//input[@id=\'login-password\']");
                a.Pause(5);
                a.CheckElement("//div[@class=\'bubble-error alert-red\']");
                a.DClose();
                a.SwitchWindow(WindowRoot);
                a.DClose();
                TestLogger.Logger("Cp Incorrect Email Format Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                string message = "Cp Incorrect Email Format Test: Fail - - ";
                TestLogger.Logger(message + e.Message);
                Console.WriteLine(message + e.Message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));

            }
        }




        [Test]
        public void CpAdminLogin()
        {
            CpAdminLoginTest a = new CpAdminLoginTest();
            a.IncorrectEmailFormat();
            a.IncorrectPassword();
            a.LoginSuccess();
        }

    }
}