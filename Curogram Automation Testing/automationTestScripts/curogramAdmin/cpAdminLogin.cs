using NUnit.Framework;
using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;


namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramAdmin
{
    [TestFixture]
    [Parallelizable]
    public class CpAdminLoginTest
    {

        public static String WindowRoot;
        public static String Window2;
        public static String Window3;



        public static void ModifyVars()
        {
            SeleniumCommands a = new SeleniumCommands();
            var windowroot = a.StringGenerator("alphanumeric");
            var windowProvider = a.StringGenerator("alphanumeric");
            var windowPatient = a.StringGenerator("alphanumeric");


            CpAdminLoginTest.WindowRoot = windowroot;
            CpAdminLoginTest.Window2 = windowProvider;
            CpAdminLoginTest.Window3 = windowPatient;
        }



        public void IncorrectPassword()
        {
            ModifyVars();
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Incorrect Password Test");

            try {
                a.StartDriver("Chrome");
                a.SaveWindow(CpAdminLoginTest.WindowRoot, 0);
                a.NavTo("https://cp.staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//div[contains(.,'Sign In')]");
                a.SaveWindow(CpAdminLoginTest.Window2, 1);
                a.SwitchWindow(CpAdminLoginTest.Window2);
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
                a.SwitchWindow(CpAdminLoginTest.WindowRoot);
                a.DClose();
                TestLogger.Logger("Incorrect Password Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                TestLogger.Logger("Incorrect Password Test: Fail");
                Console.Write("Reason: " + e.Message);
                var result = e.Message;
                a.DQuit();
                Assert.That(result, Is.EqualTo(""));
            }
        }




        public void LoginSuccess()
        {
            ModifyVars();
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Provider Login Success Test");

            try {
                a.StartDriver("Chrome");
                a.SaveWindow(CpAdminLoginTest.WindowRoot, 0);
                a.NavTo("https://cp.staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//div[contains(.,\'Sign In\')]");
                a.SaveWindow(CpAdminLoginTest.Window2, 1);
                a.SwitchWindow(CpAdminLoginTest.Window2);
                a.Pause(10);
                a.ClickOn("//input[@id=\'login-email\']");
                a.Type("//input[@id=\'login-email\']", "testrigorcpuser@curogram.com");
                a.Pause(2);
                a.Type("//input[@id=\'login-password\']", "password1");
                a.Pause(2);
                a.ClickOn("//span[contains(.,\'Log in\')]");
                a.SwitchWindow(CpAdminLoginTest.WindowRoot);
                a.Pause(5);
                a.VerifyText("//a[contains(text(),\'Admin panel\')]", "Admin panel");
                a.DClose();

                //Test Pass
                TestLogger.Logger("Provider Login Success Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                TestLogger.Logger("Login Success Test: Pass");
                Console.Write("Reason: " + e.Message);
                var result = e.Message;
                a.DQuit();
                Assert.That(result, Is.EqualTo(""));
            }
        }




        public void IncorrectEmailFormat()
        {
            ModifyVars();
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Incorrect Email Format Test");

            try {
                a.StartDriver("Chrome");
                a.SaveWindow(CpAdminLoginTest.WindowRoot, 0);
                a.NavTo("https://cp.staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//div[contains(.,\'Sign In\')]");
                a.Pause(10);
                a.SaveWindow(CpAdminLoginTest.Window2, 1);
                a.SwitchWindow(CpAdminLoginTest.Window2);
                a.Type("//input[@id=\'login-email\']", "incorrectemailformat");
                a.Pause(2);
                a.ClickOn("//input[@id=\'login-password\']");
                a.Pause(5);
                a.CheckElement("//div[@class=\'bubble-error alert-red\']");
                a.DClose();
                a.SwitchWindow(CpAdminLoginTest.WindowRoot);
                a.DClose();
                TestLogger.Logger("Incorrect Email Format Test: Pass");
            }

            //Test Failed
            catch (Exception e)
            {
                TestLogger.Logger("Incorrect Email Format Test: Fail");
                Console.Write("Reason: " + e.Message);
                var result = e.Message;
                a.DQuit();
                Assert.That(result, Is.EqualTo(""));
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