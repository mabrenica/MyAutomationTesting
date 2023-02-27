using Curogram_Automation_Testing.AppManager;
using NUnit.Framework;
using Curogram_Automation_Testing.CurogramApi.Practice;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    class Telemed2
    {

        public static String FirstName;
        public static String LastName;
        public static String Email;
        public static String WindowRoot;
        public static String WindowProvider;
        public static String WindowPatient;


        public static void ModifyVars()
        {
            SeleniumCommands a = new SeleniumCommands();
            var genFirstName = a.StringGenerator("allletters");         
            var genLastName = a.StringGenerator("allletters");   
            var genEmail = a.StringGenerator("allletters");
            var windowroot = a.StringGenerator("alphanumeric");
            var windowProvider = a.StringGenerator("alphanumeric");
            var windowPatient = a.StringGenerator("alphanumeric");

            Telemed2.LastName = genLastName;
            Telemed2.FirstName = genFirstName;
            Telemed2.Email = genEmail;
            Telemed2.WindowRoot = windowroot;
            Telemed2.WindowProvider = windowProvider;
            Telemed2.WindowPatient= windowPatient;
        }


        //Update practice timezone to make sure automated messages are working
        public async Task TimeZone()
        {
            var practiceName = "TestRigor Automation General (Do not change settings)";
            var authToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc3MDgxNDc1MDc0LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc3MDgxNDc1LCJleHAiOjE2Nzk2NzM0NzUsImlzcyI6ImFwaSJ9.akR27vti8P0wn2dnl8OPtPs2u4JPmzoxE_CQDJqJ7x4NIiejSsR8onbYaBYn2Zv2bqeeuMheMI6cqfvN4ScXB1oPYbzcsVWLI_QOKuUEuHWso9z1w6lss9k-zOD64aECe7lWwgLCdKDF5WLv59Pe0lkUsv5TXNZmM6OABOp_fUX9ccF8ge59gNMzLYOMCg762-eMz2Yl9zqKRZGw6I5K4AXSCwPOp20nDJ6CVP0bwXzQwba9wJ_76yHWTPWReLJU64eh5JQ_0Cdb-_L4IIvtPjavdzstwBrMd59XJh59e-aRoaS6Jd0QJpXu7xT4mgE__YZz2teoFzhHpEKNlQnKgw";
            var response = await new AutoUpdateTimeZone().AutoTimeZone(authToken, practiceName);
            //Console.WriteLine(response);
        }


        //Add Patient record through API
        public async Task AddPatientApi()
        {
            var firstName = Telemed2.FirstName;
            var lastName = Telemed2.LastName;
            var email = Telemed2.Email+"@mailsac.com";
            var authToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc3MDgxNDc1MDc0LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc3MDgxNDc1LCJleHAiOjE2Nzk2NzM0NzUsImlzcyI6ImFwaSJ9.akR27vti8P0wn2dnl8OPtPs2u4JPmzoxE_CQDJqJ7x4NIiejSsR8onbYaBYn2Zv2bqeeuMheMI6cqfvN4ScXB1oPYbzcsVWLI_QOKuUEuHWso9z1w6lss9k-zOD64aECe7lWwgLCdKDF5WLv59Pe0lkUsv5TXNZmM6OABOp_fUX9ccF8ge59gNMzLYOMCg762-eMz2Yl9zqKRZGw6I5K4AXSCwPOp20nDJ6CVP0bwXzQwba9wJ_76yHWTPWReLJU64eh5JQ_0Cdb-_L4IIvtPjavdzstwBrMd59XJh59e-aRoaS6Jd0QJpXu7xT4mgE__YZz2teoFzhHpEKNlQnKgw";
            var response = await new CreatePatient().CreatePatientMethod(firstName, lastName, email, authToken);
            //Console.WriteLine(response);
        }



        [Test]
        public void Telemed()
        {
            TimeZone();
            ModifyVars();
            AddPatientApi();
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Telemedicine Test 2");
           

            try { 

                //logging in to practice
                a.StartDriver("Chrome");
                a.SaveWindow(Telemed2.WindowRoot, 0);
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
                a.Type("//input[@placeholder='Find by name or phone number...']", Telemed2.FirstName);
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
                a.SaveWindow(Telemed2.WindowProvider, 1);


                //Switch back to conversation window
                a.SwitchWindow(Telemed2.WindowRoot);
                a.ClickOn("//a[@class='text-info']");
                a.Pause(15);
                a.SaveWindow(Telemed2.WindowPatient,2);
                a.SwitchWindow(Telemed2.WindowPatient);


                //Check if video is working (patient)
                a.WUntil(60,"//video[@style='height: 100%; width: 100%; object-fit: cover; position: absolute;']");
                a.CheckElement("//video[@style='height: 100%; width: 100%; object-fit: cover; position: absolute;']");
                a.WUntil(60, "//video[@style='height: 100%; width: 100%; object-fit: cover; transform: scaleX(-1);']");
                a.CheckElement("//video[@style='height: 100%; width: 100%; object-fit: cover; transform: scaleX(-1);']");


                //Check if video is working (provider)
                a.SwitchWindow(Telemed2.WindowProvider);
                a.WUntil(60, "//video[@style='height: 100%; position: absolute;']");
                a.CheckElement("//video[@style='height: 100%; position: absolute;']");
                a.WUntil(60, "//video[@style='height: 100%; position: absolute; transform: scaleX(-1);']");
                a.CheckElement("//video[@style='height: 100%; position: absolute; transform: scaleX(-1);']");
                a.Pause(5);


                //Mark visit complete
                a.ClickOn("//button[@apptooltip='End Call']");
                a.Pause(2);
                a.ClickOn("//button[@class=\"btn btn-danger\"]");
                a.Pause(5);


                //Verify in telemedicine tab
                a.TypeM("//input[@placeholder='Find by name']", Telemed2.FirstName);
                a.Pause(5);
                a.CheckElement("//span[contains(text(),\" Visit completed \")]");


                //Test success
                a.DQuit();
                Console.WriteLine("Telemedicine Test 2: Pass");
            }

                //Test Failed
            catch (Exception e)
            {
                Console.WriteLine("Telemedicine Test 2: Fail");
                Console.Write("Reason: " + e.Message);
                var result = e.Message;
                a.DQuit();
                Assert.That(result, Is.EqualTo("Pass"));
            }
        }

    }
}
