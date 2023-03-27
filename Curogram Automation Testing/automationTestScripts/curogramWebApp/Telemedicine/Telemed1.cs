using Curogram_Automation_Testing.AppManager;
using NUnit.Framework;
using Curogram_Automation_Testing.CurogramApi.Practice;
using NUnit.Framework.Internal;
using Curogram_Automation_Testing.appManager;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    public class Telemed1
    {

        public static String? FirstName;
        public static String? LastName;
        public static String? Email;
        public static String? WindowRoot;
        public static String? WindowProvider;
        public static String? WindowPatient;
        public static String PracticeId = "63d295fe2046a186b99b2537";
        public static String AuthToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc5OTE3NjU1OTA5LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc5OTE3NjU1LCJleHAiOjE2ODI1MDk2NTUsImlzcyI6ImFwaSJ9.nTKgCY25PT0b9--S7LeoympcJCPyctRnJ95TQUYU98EDq-KDiXW6G7RHGPf_1LPrDZqlpPsSZGqeXsefU0_LKFTYlwcLet6q40rW9eCneqCm8lknBHScoAYHq5uWw_TAQaroEVomE-vhkfDI2meK9UfdsaRcCO70Dz7roypS4G_-15TsZ2-oqnmapA74JH1hgHtDL6LttP9Z9Zq98In851Mpzl36P8scKsyxKXGelPUOv_p1W9vAEP5813itDg-OezoupCcxE7hC7MFiKrkiPnwUUyjdCPbv78Y4j2OomWdLL-OaAjBmaQ8g8fMNYOm9q5w7tEfDsqBm5i9dINNxbQ";



        public static void ModifyVars()
        {
            SeleniumCommands a = new();
            CreatePatient b = new CreatePatient();
            string[] patientInfo = b.PatientGenerator(practiceId: PracticeId, authToken: AuthToken).Split(",");

            //patient info
            FirstName = patientInfo[1];
            LastName = patientInfo[3];
            Email = patientInfo[4];

            WindowRoot = a.StringGenerator("alphanumeric", 9);
            WindowProvider = a.StringGenerator("alphanumeric", 9);
            WindowPatient = a.StringGenerator("alphanumeric", 9);

        }


        //Update practice timezone to make sure automated messages are working
        public async Task TimeZone()
        {
            var practiceName = "TestRigor Automation General (Do not change settings)";
            var response = await new AutoUpdateTimeZone().AutoTimeZone(AuthToken, practiceName);
            Console.WriteLine(response);
        }



        [Test]
        public void Telemed()
        {
            string testCaseTitle = "Instant Telemedicine Test";
            SeleniumCommands a = new SeleniumCommands();
            a.AddLog("event", $"Started:  {testCaseTitle}");


            try {
                TimeZone().Wait();
                ModifyVars();
                //logging in to practice
                a.StartDriver("Chrome", WindowRoot);
                a.NavTo("https://staging.curogram.com/login?returnUrl=/");
                a.WUntil("//input[@placeholder='Enter your email address']");
                a.TypeM("//input[@placeholder='Enter your email address']", "testrigorcpuser@curogram.com");
                a.TypeM("//input[@placeholder='Enter password']", "password1");
                a.ClickOn("//button[@type='submit']");
                a.WUntil("//span[contains(text(),'Patients')]");
                a.ClickOn("//span[contains(text(),'Patients')]");
                a.Pause(4);


                //chosing practice using practice cover image
                a.ClickOn("//div[@style='background-image: url(\"https://files.staging.curogram.com/9efe4805-ffe4-492d-bf70-66fff1fd45e3.png\");']");
                a.Pause(3);


                //Locate patient in Patients tab and open patient conversation
                a.TypeM("//input[@placeholder='Find by name or phone number...']", FirstName);
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
                a.SaveWindow(WindowProvider, 1);

                //Manual Send Telemedicine Link
                a.SwitchWindow(WindowRoot);
                a.ClickOn("//span[contains(text(),'Telemedicine')]");
                a.Pause(5);
                a.TypeM("//input[@placeholder='Find by name']", FirstName);
                a.Pause(5);
                a.ClickOn("//curogram-icon[@name='more']");
                a.Pause(3);
                a.ClickOn("//curogram-icon[@name='refresh-1']");
                a.Pause(2);
                a.TypeM("//input[@placeholder='Email']", Email);
                a.Pause(2);
                a.ClickOn("//button[contains(text(),'Resend')]");
                a.Pause(5);

                //Switch back to conversation window
                a.ClickOn("//span[contains(text(),'Conversations')]");
                a.Pause(5);
                a.TypeM("//input[@placeholder='Find by name or phone number...']", FirstName);
                a.Pause(5);
                a.ClickOn("//div[@class='conversation-title text-truncate']");
                a.Pause(5);
                a.ClickOn("//a[@class='text-info']");
                a.Pause(15);
                a.SaveWindow(WindowPatient, 2);
                a.SwitchWindow(WindowPatient);


                //Check if video is working (patient)
                a.WUntil("//video[@style='height: 100%; width: 100%; object-fit: cover; position: absolute;']");
                a.CheckElement("//video[@style='height: 100%; width: 100%; object-fit: cover; position: absolute;']");
                a.WUntil("//video[@style='height: 100%; width: 100%; object-fit: cover; transform: scaleX(-1);']");
                a.CheckElement("//video[@style='height: 100%; width: 100%; object-fit: cover; transform: scaleX(-1);']");


                //Check if video is working (provider)
                a.SwitchWindow(WindowProvider);
                a.WUntil("//video[@style='height: 100%; position: absolute;']");
                a.CheckElement("//video[@style='height: 100%; position: absolute;']");
                a.WUntil("//video[@style='height: 100%; position: absolute; transform: scaleX(-1);']");
                a.CheckElement("//video[@style='height: 100%; position: absolute; transform: scaleX(-1);']");
                a.Pause(5);


                //Mark visit complete
                a.ClickOn("//button[@apptooltip='End Call']");
                a.Pause(2);
                a.ClickOn("//button[@class=\"btn btn-danger\"]");
                a.Pause(5);


                //Verify in telemedicine tab
                a.TypeM("//input[@placeholder='Find by name']", FirstName, typeSpeed: 200, pauseAfterType: 500);
                a.Pause(5);
                a.CheckElement("//span[contains(text(),\" Visit completed \")]");


                //Test success
                a.DQuit();
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

    }
}
