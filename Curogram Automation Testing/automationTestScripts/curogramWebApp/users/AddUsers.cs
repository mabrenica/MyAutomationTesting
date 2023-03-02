using NUnit.Framework;
using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;


namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.AddUsers
{

    [TestFixture]
    [Parallelizable]
    public class AddUserTest
    {
        public static String? FirstName;
        public static String? LastName;
        public static String? Email;
        public static String? FullName;
        public static String? WindowRoot;
        public static String? Cp;
        public static String? CuroWeb;



        public static void ModifyVars()
        {
            SeleniumCommands a = new SeleniumCommands();
            var genFirstName = a.StringGenerator("allletters", 9);
            var genLastName = a.StringGenerator("allletters", 9);
            var genEmail = a.StringGenerator("allletters", 9);
            var windowroot = a.StringGenerator("alphanumeric", 9);
            var windowProvider = a.StringGenerator("alphanumeric", 9);
            var windowPatient = a.StringGenerator("alphanumeric", 9);

            WindowRoot = windowroot;
            Cp = windowProvider;
            CuroWeb = windowPatient;
            LastName = genLastName;
            FirstName = genFirstName;
            Email = genEmail+"@mailsac.com";
            FullName = genFirstName+" "+genLastName;
        }




        [Test]
        public void addUser()
        {
            ModifyVars();
            SeleniumCommands a = new();
            Console.WriteLine("Testing: Add User Test");

            try
            {
                //Login as provider in CP
                a.StartDriver("Chrome");
                a.SaveWindow(WindowRoot, 0);
                a.NavTo("https://cp.staging.curogram.com/");
                a.Pause(10);
                a.ClickOn("//div[contains(.,\'Sign In\')]");
                a.Pause(5);
                a.SaveWindow(Cp, 1);
                a.SwitchWindow(Cp);
                a.TypeM("//input[@id=\'login-email\']", "testrigorcpuser@curogram.com");
                a.Pause(1);
                a.TypeM("//input[@id=\'login-password\']", "password1");
                a.Pause(1);
                a.ClickOn("//span[contains(.,\'Log in\')]");
                a.Pause(5);
                a.SwitchWindow(WindowRoot);
                a.VerifyText("//a[contains(text(),\'Admin panel\')]", "Admin panel");


                //Locate the practice in Practices Dashboard
                a.WUntil(60, "//span[contains(.,\'Practices\')]");
                a.ClickOn("//span[contains(.,\'Practices\')]");
                a.Pause(3);
                a.TypeM("//input[@type=\'text\']", "testrigor automation general");
                a.Pause(4);
                a.ClickOn("//a[contains(text(),\'TestRigor Automation General (Do not change settings)\')]");
                a.Pause(5);
                a.ClickOn("//div[5]/div[2]/div");
                a.Pause(4);


                //Login to practice
                a.TypeM("(//input[@type=\'text\'])[2]", "Testrigor");
                a.Pause(3);
                a.ClickOn("//curogram-intel-provider-actions/div/i");
                a.Pause(5);
                a.SaveWindow(CuroWeb, 1);
                a.SwitchWindow(WindowRoot);
                a.DClose();
                a.SwitchWindow(CuroWeb);


                //Go to Settings
                a.WUntil(40,"//span[contains(.,'Settings')]");
                a.ClickOn("//span[contains(.,'Settings')]");
                a.Pause(4);
                a.ClickOn("//a[4]/div");
                a.Pause(5);
                a.ClickOn("//button[contains(.,\'Add\')]");
                a.Pause(4);


                //Enter user details
                a.TypeM("//input[@type=\'email\']", Email);
                a.Pause(1);
                a.TypeM("(//input[@type=\'text\'])[3]", FirstName);
                a.Pause(1);
                a.TypeM("(//input[@type=\'text\'])[4]", LastName);
                a.Pause(1);
                a.ClickOn("//ui-switch[@formcontrolname=\'isAdmin\']/button[@type=\'button\']");
                a.Pause(2);
                a.ClickOn("//button[contains(.,\'Invite\')]");
                a.Pause(3);


                //Verify if user is added
                a.TypeM("//input[@placeholder=\'Find by name or phone number...\']", FirstName);
                a.Pause(3);
                a.VerifyText("//div[@class='user-info__name user-info__name--cropped user-info__name--offset']", FullName);
                a.Pause(3);


                //Delete added user
                a.ClickOn("//curogram-icon[@name='trash']");
                a.Pause(3);
                a.ClickOn("//button[@class='btn btn-danger'][1]");
                a.DClose();

                //Test pass
                TestLogger.Logger("Add Users Test: Pass");
            }

            //Test Fail           
            catch (Exception e) 
            {
                string message = "Add Users Test: Fail - -";
                TestLogger.Logger(message + e.Message);
                Console.WriteLine(message + e.Message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
}
    }








































}