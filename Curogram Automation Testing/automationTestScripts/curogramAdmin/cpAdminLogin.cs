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
            string testCaseTitle = "Cp Incorrect Password Test";
            ModifyVars();
            SeleniumCommands a = new();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try {
                a.StartDriver("Chrome", WindowRoot);
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
                a.AddLog("allType", $"Pass:  {testCaseTitle}");
            }

            //Test Failed
            catch (Exception e)
            {
                string message = $"Fail: {testCaseTitle} - - " + e.Message;
                a.AddLog("allType", message);
                Console.WriteLine(message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }




        public void LoginSuccess()
        {
            string testCaseTitle = "Cp Provider Login Success Test";
            ModifyVars();
            SeleniumCommands a = new();

            try {
                a.StartDriver("Chrome", WindowRoot);
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
                a.AddLog("allType", $"Pass:  {testCaseTitle}");
            }

            //Test Failed
            catch (Exception e)
            {
                string message = $"Fail: {testCaseTitle} - - " + e.Message;
                a.AddLog("allType", message);
                Console.WriteLine(message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }




        public void IncorrectEmailFormat()
        {
            string testCaseTitle = "CP Incorrect Email Format Test";
            ModifyVars();
            SeleniumCommands a = new();

            try {
                a.StartDriver("Chrome", WindowRoot);
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
                a.AddLog("allType", $"Pass:  {testCaseTitle}");
            }

            //Test Failed
            catch (Exception e)
            {
                string message = $"Fail: {testCaseTitle} - - " + e.Message;
                a.AddLog("allType", message);
                Console.WriteLine(message);
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