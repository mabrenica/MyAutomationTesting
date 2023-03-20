using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.CurogramApi.Other;
using Curogram_Automation_Testing.CurogramApi.Patient;
using Curogram_Automation_Testing.CurogramApi.Practice;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Security.Cryptography.X509Certificates;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.FormStack
{
    [TestFixture]
    [Parallelizable]
    public class FormStack
    {
        public static String? FullAddress;
        public static String? AddressLine1;
        public static String? AptNo;
        public static String? City;
        public static String? State;
        public static String? ZipCode;
        public static String? AuthToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc5MDQ0MDI1MDE5LCJidXNpbmVzc0lkIjoiNjQxMmY1YjU2MDYxMDkxMmI4N2YzNjBkIiwiaWF0IjoxNjc5MDQ0MDI1LCJleHAiOjE2ODE2MzYwMjUsImlzcyI6ImFwaSJ9.ADz_K-b6k7oOVFOpfoJgsi9N2iRTDxPBAt6D2byKp9jwNy1_0Di84wHiiFmrhV2rn9tU11LNmcURjEv2v7bkS7rPMx_FO5dn0-HAdXS-9-rViGI7cUyXK3D8o8DPFUpz-6jOWz1-FdastSQGblEmkL_G3a9iC8viZuFs7T7psxg6gBa4IVPt9o4DJNTHtmrKJxMKY77RnaYo5R2k2A6HYXlFPU52VTrO7iP7K1QHQPBDHiPmmdpCUat7qZ9fu0o03oqe8H56grd6Oa1HR1VfiaZYQjdm6hHBLcukkMwMxUxa5nqIkrpJYb1mLetofpH8ueKn5zx4cv1sIcu7rUVufQ";

        public static String? FirstName;
        public static String? MiddleName;
        public static String? LastName;
        public static String? PhoneNumber = "(845) 266 7150";
        public static String? PhoneAreaCode = PhoneNumber.Split(" ")[0];
        public static String? TelePrefix = PhoneNumber.Split(" ")[1];
        public static String? LineNumber = PhoneNumber.Split(" ")[2];
        public static String? Email;

        public static String? CuroWeb;
        public static String? Nonce;
        public static String? SubmissionId;

        //Generate Random Address
        public async Task GetAddress()
        {
            var response = await new AddressGenerator().AddGen();
            string[] fullAddress = response.ToString().Split(",");
            string[] firstLine = fullAddress[0].Split("\"");
            string[] zipLine = fullAddress[2].Split("-");

            AddressLine1 = firstLine[1].ToString();
            AptNo = fullAddress[1].ToString();
            City = fullAddress[3].ToString();
            State = fullAddress[4].ToString();
            ZipCode = zipLine[0].ToString();
            FullAddress = $"{firstLine[1]},{fullAddress[1]},{fullAddress[3]},{fullAddress[4]},{zipLine[0]}";
        }

        //Add values to variables
        public void ModifyVars()
        {
            SeleniumCommands a = new();
            CuroWeb         = a.StringGenerator();
            FirstName       = a.StringGenerator();
            MiddleName      = a.StringGenerator();
            LastName        = a.StringGenerator();
            Email           = a.EmailGenerator();
            Nonce           = a.StringGenerator();
        }

        //Submit data to formstack through API
        public async Task SubmitForm()
        {
            FormStackSubmitForm a = new();
            await a.SubmitFormApi(FirstName, MiddleName, LastName, Email, FullAddress, Nonce, homePhone: PhoneNumber, cellPhone: PhoneNumber);
        }

        //Main test script
        [Test]
        public async Task SuccessSubmission()
        {
            SeleniumCommands a = new();
            FormStack b = new();
            VerifyPatientByName c = new();
            GetPatientDocumentByName d = new();
            string testCaseTitle = "Patient form successful submission test";            
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                //Generate Address and submit formstack via API
                ModifyVars();
                await b.GetAddress();
                await b.SubmitForm();
                await c.VerifyPatient(AuthToken, FirstName, MiddleName, LastName, Email, $"+1 {PhoneAreaCode} {TelePrefix}-{LineNumber}") ;
                await d.VerifyDocument(AuthToken, FirstName, LastName);

                //Login to Curogram as provider to check submission
                a.StartDriver("Chrome", CuroWeb);
                a.NavTo("https://app.staging.curogram.com");
                a.TypeM("//input[@type=\'text\']", "testrigorcpuser@curogram.com");
                a.TypeM("//input[@type=\'password\']", "password1");
                a.ClickOn("//button[@type=\'submit\']");
                a.WUntil("//div[contains(text(),'Quick Actions')]");
                a.ClickOn("//div[@style='background-image: url(\"https://files.staging.curogram.com/8b8a276d-9c35-4262-a94e-ada83795cb7c.png\");']");
                a.ClickOn("//span[contains(text(),'Documents')]");
                a.Pause(4);
                a.TypeM("//input[@placeholder=\"Find by document name or patient name\"]", FirstName);
                a.WUntil($"//span[contains(text(),' {FirstName} {MiddleName} {LastName} ')]");
                a.ClickOn("//a[@apptooltip=\"View\"]");

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

        public void PatientForm()
        {
            SuccessSubmission().Wait();
        }








    }
}
