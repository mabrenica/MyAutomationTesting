using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Curogram_Automation_Testing.CurogramApi.Practice;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    internal class InstantTelemedicineTest
    {
        public static String FirstName;
        public static String LastName;
        public static String Email;


        public static void ModifyVars()
        {
            SeleniumCommands stringGen = new SeleniumCommands();
            var genFirstName = stringGen.StringGenerator("allletters");
            InstantTelemedicineTest.FirstName = genFirstName;
            var genLastName = stringGen.StringGenerator("allletters");
            InstantTelemedicineTest.LastName = genLastName;
            var genEmail = stringGen.StringGenerator("allletters");
            InstantTelemedicineTest.Email = genEmail;

        }

        //Update practice timezone to make sure automated messages are working
        public async Task TimeZone()
        {
            var practiceName = "TestRigor Automation General (Do not change settings)";
            var authToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc3MDgxNDc1MDc0LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc3MDgxNDc1LCJleHAiOjE2Nzk2NzM0NzUsImlzcyI6ImFwaSJ9.akR27vti8P0wn2dnl8OPtPs2u4JPmzoxE_CQDJqJ7x4NIiejSsR8onbYaBYn2Zv2bqeeuMheMI6cqfvN4ScXB1oPYbzcsVWLI_QOKuUEuHWso9z1w6lss9k-zOD64aECe7lWwgLCdKDF5WLv59Pe0lkUsv5TXNZmM6OABOp_fUX9ccF8ge59gNMzLYOMCg762-eMz2Yl9zqKRZGw6I5K4AXSCwPOp20nDJ6CVP0bwXzQwba9wJ_76yHWTPWReLJU64eh5JQ_0Cdb-_L4IIvtPjavdzstwBrMd59XJh59e-aRoaS6Jd0QJpXu7xT4mgE__YZz2teoFzhHpEKNlQnKgw";
            var response = await new AutoUpdateTimeZone().AutoTimeZone(authToken, practiceName);
            Console.WriteLine(response);
        }

        //Add Patient record through API
        public async Task AddPatientApi()
        {
            var firstName = InstantTelemedicineTest.FirstName;
            var lastName = InstantTelemedicineTest.LastName;
            var email = InstantTelemedicineTest.Email+"@mailsac.com";
            var authToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc3MDgxNDc1MDc0LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc3MDgxNDc1LCJleHAiOjE2Nzk2NzM0NzUsImlzcyI6ImFwaSJ9.akR27vti8P0wn2dnl8OPtPs2u4JPmzoxE_CQDJqJ7x4NIiejSsR8onbYaBYn2Zv2bqeeuMheMI6cqfvN4ScXB1oPYbzcsVWLI_QOKuUEuHWso9z1w6lss9k-zOD64aECe7lWwgLCdKDF5WLv59Pe0lkUsv5TXNZmM6OABOp_fUX9ccF8ge59gNMzLYOMCg762-eMz2Yl9zqKRZGw6I5K4AXSCwPOp20nDJ6CVP0bwXzQwba9wJ_76yHWTPWReLJU64eh5JQ_0Cdb-_L4IIvtPjavdzstwBrMd59XJh59e-aRoaS6Jd0QJpXu7xT4mgE__YZz2teoFzhHpEKNlQnKgw";
            var response = await new CreatePatient().CreatePatientMethod(firstName, lastName, email, authToken);
            Console.WriteLine(response);
        }



        [Test]
        public void Telemed()
        {
            TimeZone();
            ModifyVars();
            AddPatientApi();
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Telemedicine Test");
           

            try { 

                //logging in to practice
                a.StartDriver();
                a.NavTo("https://staging.curogram.com/login?returnUrl=/");
                a.WUntil(60, "//input[@placeholder='Enter your email address']");
                a.Type("//input[@placeholder='Enter your email address']", "testrigorcpuser@curogram.com");
                a.Type("//input[@placeholder='Enter password']", "password1");
                a.ClickOn("//button[@type='submit']");
                a.WUntil(60, "//span[contains(text(),'Appointments')]");
                a.ClickOn("//span[contains(text(),'Appointments')]");
                a.Pause(5);

                //chosing practice using practice cover image
                a.ClickOn("//div[@style='background-image: url(\"https://files.staging.curogram.com/9efe4805-ffe4-492d-bf70-66fff1fd45e3.png\");']");

                //Creating telemedicine appointment
                a.Pause(5);
                a.ClickOn("//curogram-icon[@apptooltip='New appointment']");
                a.Pause(5);
                a.ClickOn("//input[@placeholder='Find by name or phone number...']");
                a.Type("//input[@placeholder='Find by name or phone number...']", InstantTelemedicineTest.FirstName);
                a.Pause(5);
                a.ClickOn("//li[@class='list__item ng-star-inserted']");

                //open conversation
                a.ClickOn("//span[contains(text(),'Conversations')]");
                a.Pause(4);
                a.Type("//input[@placeholder='Find by name or phone number...']", InstantTelemedicineTest.FirstName);
                a.Pause(4);
                a.ClickOn("//div[@class='conversation-title text-truncate']");
                a.Pause(4);


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
