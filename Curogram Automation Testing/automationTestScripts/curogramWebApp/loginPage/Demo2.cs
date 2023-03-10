using NUnit.Framework;
using Curogram_Automation_Testing.AppManager;


namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage
{
    [TestFixture]
    [Parallelizable]
    public class Demo2
    {
        public static String? WindowRoot;

        public static void ModifyVars()
        {
            SeleniumCommands a = new SeleniumCommands();
            WindowRoot = a.StringGenerator("alphanumeric", 9);
        }



        [Test]
        public void DemoTest()
        {
            string testCaseTitle = "Demo Test 2";
            ModifyVars();
            SeleniumCommands a = new SeleniumCommands();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                a.StartDriver("Chrome", WindowRoot);
                a.NavTo("https://www.saucedemo.com/");
                a.TypeM("//input[@placeholder=\"Username\"]", "standard_user");
                a.TypeM("//input[@placeholder=\"Password\"]", "secret_saucewhatsoever");
                a.ClickOn("//input[@type=\"submit\"]");
                a.ClickOn("//div[contains(text(),'Sauce Labs Backpack')]");
                a.ClickOn("//button[contains(text(),'Add to cart')]");
                a.ClickOn("//a[@class=\"shopping_cart_link\"]");
                a.ClickOn("//button[@name=\"checkout\"]");
                a.TypeM("//input[@placeholder=\"First Name\"]", "Marnel");
                a.TypeM("//input[@placeholder=\"Last Name\"]", "Abrenica");
                a.TypeM("//input[@name=\"postalCode\"]", "92660");
                a.ClickOn("//input[@type=\"submit\"]");
                a.ClickOn("//button[@name=\"finish\"]");
                a.VerifyText("//h2[contains(text(),'Thank you for your order!')]", "Thank you for your order!");

                //Test Pass
                a.DQuit();
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
