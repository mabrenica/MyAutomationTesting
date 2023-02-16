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
            ResetProviderPassword.FirstName = genFirstName;

            var genLastName = stringGen.StringGenerator();
            ResetProviderPassword.LastName = genLastName;

            var genEmail = stringGen.StringGenerator();
            ResetProviderPassword.Email = genEmail;

        }

        [Test]
        public void Telemed()
        {
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Telemedicine Test");
            ModifyVars();

            try { 




            a.StartDriver();
            a.NavTo("https://app.staging.curogram.com");
            a.Type("//input[@placeholder='Enter your email address']", "testrigorcpuser@curogram.com");
            a.Type("//input[@placeholder='Enter password']", "password1");
            a.ClickOn("//button[@type='submit']");
            a.Pause(5000);
            a.ClickOn("//span[contains(text(),'Patients')]");
            a.Pause(3000);
            a.ClickOn("//curogram-icon[@name='plus']");
            a.Pause(2000);
            a.Type("//input[@placeholder='First Name']", ResetProviderPassword.FirstName);
            a.Pause(1000);
            a.Type("//input[@placeholder='Last Name']", ResetProviderPassword.LastName);
            a.Pause(1000);
            a.Type("//input[@placeholder='Last Name']", ResetProviderPassword.Email);
            a.Pause(2000);
            a.ClickOn("//button[contains(text(),'Create')]");
            a.Pause(5000);

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
