using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    internal class TelemedicineTest
    {
        public static String FirstName;
        public static String LastName;
        public static String Email;

        public static void ModifyVars()
        {
            SeleniumCommands stringGen = new SeleniumCommands();
            var genFirstName = stringGen.StringGenerator();
            TelemedicineTest.FirstName = genFirstName;

            var genLastName = stringGen.StringGenerator();
            TelemedicineTest.LastName = genLastName;

            var genEmail = stringGen.StringGenerator();
            TelemedicineTest.Email = genEmail;

        }

        [Test]
        public void Telemed()
        {
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Telemedicine Test");
            ModifyVars();

            try { 

                //logging in to practice
                a.StartDriver();
                a.NavTo("https://staging.curogram.com/login?returnUrl=/");
                a.WUntil(60, "//input[@placeholder='Enter your email address']");
                a.Type("//input[@placeholder='Enter your email address']", "testrigorcpuser@curogram.com");
                a.Type("//input[@placeholder='Enter password']", "password1");
                a.ClickOn("//button[@type='submit']");
                a.WUntil(60, "//span[contains(text(),'Patients')]");

                //chosing practice using practice cover image
                a.ClickOn("//div[@style='background-image: url(\"https://files.staging.curogram.com/9efe4805-ffe4-492d-bf70-66fff1fd45e3.png\");']");

                //creating patient record
                a.Pause(5000);
                a.ClickOn("//span[contains(text(),'Patients')]");
                a.Pause(3000);
                a.ClickOn("//curogram-icon[@name='plus']");
                a.Pause(2000);
                a.Type("//input[@placeholder='First Name']", TelemedicineTest.FirstName);
                a.Pause(1000);
                a.Type("//input[@placeholder='Last Name']", TelemedicineTest.LastName);
                a.Pause(1000);
                a.Type("//input[@placeholder='Email 1']", TelemedicineTest.Email + "@mailsac.com");
                a.Pause(2000);
                a.ClickOn("//button[contains(text(),'Create')]");
                a.Pause(5000);

                //Opening patient conversation
                a.ClickOn("//div[@apptooltip='Message patient']");

                //Create instant telemedicine appointment
                a.WUntil(60, "//curogram-icon[@apptooltip='Schedule an appointment']");
                a.ClickOn("//curogram-icon[@apptooltip='Schedule an appointment']");
                a.WUntil(60, "//button[@class='btn btn-primary']");
                a.ClickOn("//button[@class='btn btn-primary']");
                a.newWindow();
                a.SwitchWin(1);
                a.NavTo("https://mailsac.com");
                a.SwitchWin(0);
                a.DClose();
                Console.WriteLine("Telemedicine Test: Pass");
            }
            catch (Exception e)
            {
                Console.WriteLine("Telemedicine Test: Fail");
                Console.Write("Reason: " + e.Message);
                var result = e.Message;
                a.DQuit();
                Assert.That(result, Is.EqualTo("Pass"));
            }
        }
    }
}
