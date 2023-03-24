using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.CurogramApi.Practice;
using NUnit.Framework;
using System.Runtime.InteropServices;


namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    public class PatientPortalLogin
    {


        //Patient Variables
        public static String? PFName;
        public static String? PLName;
        public static String? PMName;
        public static String? PEmail;
        public static String? UserName;
        public static String? Password1;
        public static String? Password2;
        public static String? PassAllLetters;
        public static String? PassAllNumbers;
        public static String PasswordSpecialChar = "!()-@_\"#$%&'*+,./;:<=>?[|]~ ";
        public static String PracticeId = "63d295fe2046a186b99b2537";
        public static String AuthToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc3MDgxNDc1MDc0LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc3MDgxNDc1LCJleHAiOjE2Nzk2NzM0NzUsImlzcyI6ImFwaSJ9.akR27vti8P0wn2dnl8OPtPs2u4JPmzoxE_CQDJqJ7x4NIiejSsR8onbYaBYn2Zv2bqeeuMheMI6cqfvN4ScXB1oPYbzcsVWLI_QOKuUEuHWso9z1w6lss9k-zOD64aECe7lWwgLCdKDF5WLv59Pe0lkUsv5TXNZmM6OABOp_fUX9ccF8ge59gNMzLYOMCg762-eMz2Yl9zqKRZGw6I5K4AXSCwPOp20nDJ6CVP0bwXzQwba9wJ_76yHWTPWReLJU64eh5JQ_0Cdb-_L4IIvtPjavdzstwBrMd59XJh59e-aRoaS6Jd0QJpXu7xT4mgE__YZz2teoFzhHpEKNlQnKgw";
        public static String MailsacKey = "k_rtJ7fZ6197XAsC5f4Ujyp2477Xc479U0rI4tg66ef";


        //Window Variables
        public static String? PatientPortal;


        //Set Values to Variables with random strings
        public static void ModifyVars()
        {
            SeleniumCommands a = new();
            CreatePatient b = new CreatePatient();
            string[] patientInfo = b.PatientGenerator(practiceId: PracticeId, authToken: AuthToken, mailsacKey: MailsacKey, forOtp: true).Split(",");

            //patient info
            PFName = patientInfo[1];
            PMName = patientInfo[2];
            PLName = patientInfo[3];
            PEmail = patientInfo[5];

            //passwords
            Password1 = a.StringGenerator("alphanumeric", 8) + "!()-@_\"#$%&'*+,./;:<=>?[|]~ ";
            Password2 = a.StringGenerator("alphanumeric", 8);
            UserName = a.StringGenerator("alphanumeric", 10) + "-!()@_";
            PassAllLetters = a.StringGenerator("allletters",8);
            PassAllNumbers = a.StringGenerator("allnumbers", 8);

            //Windows
            PatientPortal = a.StringGenerator("allletters", 9);
        }



        //Test execution
        [Test] 
        public void CreateUserName()
        {          
            string testCaseTitle = "Patient Portal Create User Name";
            ModifyVars();
            SeleniumCommands a = new();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                //Open Patient portal website
                a.StartDriver("Chrome", PatientPortal);
                a.NavTo("https://staging.curogram.com/login?hsLang=en");
                a.ClickOn("//button[contains(text(),' Login as Patient ')]");
                a.ClickOn("//button[contains(text(),'I don’t have a username yet')]");
                a.TypeM("//input[@placeholder=\"Enter your email address\"]", PEmail);
                a.ClickOn("//button[@type=\"submit\"]");
                a.Pause(3);

                //Verify OTP
                var otp = a.OtpViaMailSac(PEmail);
                a.TypeCode(otp, "//input[@placeholder=\"—\"]");
                a.ClickOn("//button[@type=\"submit\"]");

                //Create username
                a.TypeM("//input[@placeholder=\"Username\"]", UserName.Substring(0, 7));
                a.CheckElement("//button[@disabled]");
                a.ClearInput("//input[@placeholder=\"Username\"]");
                a.TypeM("//input[@placeholder=\"Username\"]", "ldiejgndkkdfejdkgkkseugjdkjkflked");
                a.CheckElement("//button[@disabled]");
                a.ClearInput("//input[@placeholder=\"Username\"]");
                a.TypeM("//input[@placeholder=\"Username\"]", "#$%^&#$%%");
                a.CheckElement("//button[@disabled]");
                a.ClearInput("//input[@placeholder=\"Username\"]");
                a.TypeM("//input[@placeholder=\"Username\"]", UserName);
                a.ClickOn("//button[@type=\"button\"]");

                //Create Password
                a.TypeM("//input[@placeholder=\"Password\"]", Password1.Substring(0, 7));
                a.CheckElement("//div[contains(text(),' Minimum character requirement is 8 characters ')]");
                a.ClearInput("//input[@placeholder=\"Password\"]");
                a.TypeM("//input[@placeholder=\"Password\"]", PassAllLetters);
                a.CheckElement("//div[contains(text(),' Must include at least one number or special character and one letter ')]");
                a.ClearInput("//input[@placeholder=\"Password\"]");
                a.TypeM("//input[@placeholder=\"Password\"]", PassAllLetters + PassAllNumbers);
                a.CheckElement("//div[contains(text(),' Must include at least one number or special character and one letter ')]");
                a.ClearInput("//input[@placeholder=\"Password\"]");
                a.TypeM("//input[@placeholder=\"Password\"]", PassAllNumbers);
                a.CheckElement("//div[contains(text(),' Must include at least one number or special character and one letter ')]");
                a.ClearInput("//input[@placeholder=\"Password\"]");
                a.TypeM("//input[@placeholder=\"Password\"]", PassAllLetters + PasswordSpecialChar);
                a.CheckElement("//div[contains(text(),' Must include at least one number or special character and one letter ')]");
                a.ClearInput("//input[@placeholder=\"Password\"]");
                a.TypeM("//input[@placeholder=\"Password\"]", PassAllNumbers + PasswordSpecialChar);
                a.CheckElement("//div[contains(text(),' Must include at least one number or special character and one letter ')]");
                a.ClearInput("//input[@placeholder=\"Password\"]");
                a.TypeM("//input[@placeholder=\"Password\"]", PasswordSpecialChar);
                a.CheckElement("//div[contains(text(),' Must include at least one number or special character and one letter ')]");
                a.ClearInput("//input[@placeholder=\"Password\"]");
                a.TypeM("//input[@placeholder=\"Password\"]", Password1);
                a.TypeM("//input[@placeholder=\"Confirm Password\"]", Password2);
                a.CheckElement("//div[contains(text(),' Password matched ')]");
                a.ClearInput("//input[@placeholder=\"Password\"]");
                a.ClearInput("//input[@placeholder=\"Confirm Password\"]");
                a.TypeM("//input[@placeholder=\"Password\"]", PassAllLetters + PassAllNumbers + PasswordSpecialChar);
                a.TypeM("//input[@placeholder=\"Confirm Password\"]", PassAllLetters + PassAllNumbers + PasswordSpecialChar);
                a.ClickOn("//button[contains(text(),'Continue')]");


                //Test Pass
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
