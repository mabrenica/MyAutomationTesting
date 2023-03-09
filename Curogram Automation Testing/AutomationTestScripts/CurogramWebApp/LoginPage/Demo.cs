using NUnit.Framework;
using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.appManager;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage
{
    [TestFixture]
    [Parallelizable]
    public class Demo
    {
        public static String? WindowRoot;

        public static void ModifyVars()
        {
            SeleniumCommands a = new SeleniumCommands();
            WindowRoot = a.StringGenerator("alphanumeric", 9);
        }




        public void DemoTest()
        {
            string testCaseTitle = "Demo Test";
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
    }
}
