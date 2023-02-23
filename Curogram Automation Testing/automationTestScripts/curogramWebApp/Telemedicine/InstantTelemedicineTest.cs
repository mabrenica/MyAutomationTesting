﻿using Curogram_Automation_Testing.AppManager;
using NUnit.Framework;
using Curogram_Automation_Testing.CurogramApi.Practice;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    class InstantTelemedicineTest
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
                a.WUntil(60, "//span[contains(text(),'Patients')]");
                a.ClickOn("//span[contains(text(),'Patients')]");
                a.Pause(4);


                //chosing practice using practice cover image
                a.ClickOn("//div[@style='background-image: url(\"https://files.staging.curogram.com/9efe4805-ffe4-492d-bf70-66fff1fd45e3.png\");']");
                a.Pause(3);


                //Locate patient in Patients tab and open patient conversation
                a.Type("//input[@placeholder='Find by name or phone number...']", InstantTelemedicineTest.FirstName);
                a.Pause(4);
                a.ClickOn("//div[@class='user-info__name user-info__name--cropped']");
                a.Pause(4);
                a.ClickOn("//curogram-icon[@name='conversation-filled']");
                a.Pause(5);


                //create instant telemedicine appointment
                a.ClickOn("//curogram-icon[@apptooltip='Schedule an appointment']");
                a.Pause(4);
                a.ClickOn("//button[@class='btn btn-primary']");
                a.Pause(6);               
                a.saveWindow(1);


                //Switch back to conversation window
                a.SwitchWin(0);
                a.ClickOn("//a[@class='text-info']");
                a.Pause(15);
                a.saveWindow(2);
                a.SwitchWin(2);


                //Check if video is working
                a.CheckElement("//video[@style='height: 100%; width: 100%; object-fit: cover; position: absolute;']");
                a.CheckElement("//video[@style='height: 100%; width: 100%; object-fit: cover; transform: scaleX(-1);']");
                a.SwitchWin(1);
                a.CheckElement("//video[@style='height: 100%; position: absolute;']");
                a.CheckElement("//video[@style='height: 100%; position: absolute; transform: scaleX(-1);']");
                a.Pause(5);


                //Mark visit complete
                a.ClickOn("//button[@apptooltip='End Call']");
                a.Pause(2);
                a.ClickOn("//button[@class=\"btn btn-danger\"]");
                a.Pause(5);


                //Verify in telemedicine tab
                a.TypeM("//input[@placeholder='Find by name']", InstantTelemedicineTest.FirstName);
                a.Pause(5);
                a.CheckElement("//span[contains(text(),\" Visit completed \")]");


                //Test success
                a.DQuit();
                Console.WriteLine("Telemedicine Test: Pass");
            }

                //Test Failed
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
