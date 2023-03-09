using NUnit.Framework;
using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.appManager;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage
{
    [TestFixture]
    [Parallelizable]
    public class ProviderLogin
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
            string testCaseTitle = "Curogram Web Provider Login Success";
            ModifyVars();
            SeleniumCommands a = new SeleniumCommands();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                a.StartDriver("Chrome", WindowRoot);
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
                a.AddLog("allType", $"Pass:  {testCaseTitle}");
            }
            //Test Fail
            catch (Exception e) 
            {
                string message = $"Fail: {testCaseTitle} - - " + e.Message;
                a.AddLog("allType", message);
                Console.WriteLine(message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }




        public void IncorrectPassword()
        {
            string testCaseTitle = "Curogram Web Incorrect Password";
            ModifyVars();
            SeleniumCommands a = new();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                a.StartDriver("Chrome", WindowRoot);
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
                a.AddLog("allType", $"Pass:  {testCaseTitle}");
            }

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
            string testCaseTitle = "Curogram Web Incorrect Email Format Test";
            ModifyVars();
            SeleniumCommands a = new();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                a.StartDriver("Chrome", WindowRoot);
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
                a.AddLog("allType", $"Pass:  {testCaseTitle}");
            }

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
        public void ProviderLoginTest()
        {
            ProviderLogin a= new();
            a.IncorrectPassword();
            a.ProviderLoginSuccess();
            a.IncorrectEmailFormat();

        }

    }
}
