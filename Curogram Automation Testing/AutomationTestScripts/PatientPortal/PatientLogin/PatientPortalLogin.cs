using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.CurogramApi.Practice;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    public class PatientPortalLogin
    {
        Dictionary<int, string> SecurityQuestions = new();
        Dictionary<int, string> AnswerList = new();

        //Patient Variables
        public static string? PFName;
        public static string? PLName;
        public static string? PMName;
        public static string? PEmail;
        public static string? Month;
        public static string MonthAbbrv;
        public static string? Day;
        public static string? Year;
        public static string DayOfWeek;

        //others
        public static string? UserName;
        public static string UserPassword;
        public static string? Password1;
        public static string? Password2;
        public static string? PassAllLetters;
        public static string? PassAllNumbers;
        public static string PasswordSpecialChar;
        public static string PracticeId = "63d295fe2046a186b99b2537";
        public static string AuthToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc5OTE3NjU1OTA5LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc5OTE3NjU1LCJleHAiOjE2ODI1MDk2NTUsImlzcyI6ImFwaSJ9.nTKgCY25PT0b9--S7LeoympcJCPyctRnJ95TQUYU98EDq-KDiXW6G7RHGPf_1LPrDZqlpPsSZGqeXsefU0_LKFTYlwcLet6q40rW9eCneqCm8lknBHScoAYHq5uWw_TAQaroEVomE-vhkfDI2meK9UfdsaRcCO70Dz7roypS4G_-15TsZ2-oqnmapA74JH1hgHtDL6LttP9Z9Zq98In851Mpzl36P8scKsyxKXGelPUOv_p1W9vAEP5813itDg-OezoupCcxE7hC7MFiKrkiPnwUUyjdCPbv78Y4j2OomWdLL-OaAjBmaQ8g8fMNYOm9q5w7tEfDsqBm5i9dINNxbQ";
        public static string MailsacKey = "k_rtJ7fZ6197XAsC5f4Ujyp2477Xc479U0rI4tg66ef";
        public static int Question1no;
        public static int Question2no;
        public static int Question3no;
        public static string SQuestion1;
        public static string SQuestion2;
        public static string SQuestion3;
        public static string Answer1;
        public static string Answer2;
        public static string Answer3;

        //Recover username variables
        public static string RQuestion1;
        public static string RQuestion2;
        public static string RecoveryAnswer1;
        public static string RecoveryAnswer2;



        //Window Variables
        public static string? PatientPortal;


        //Set Values to Variables with random strings
        public void ModifyVars()
        {
            SeleniumCommands a = new();
            CreatePatient b = new CreatePatient();
            Random ranInt = new();
            var seedInt = ranInt.Next();
            Random sQuestions = new(seedInt);
            

            string[] patientInfo = b.PatientGenerator(practiceId: PracticeId, authToken: AuthToken, mailsacKey: MailsacKey, forOtp: true).Split(",");



            //patient info
            PFName = patientInfo[1];
            PMName = patientInfo[2];
            PLName = patientInfo[3];
            PEmail = patientInfo[4];
            Month = patientInfo[6];
            MonthAbbrv = patientInfo[8];
            Day = patientInfo[10];
            Year = patientInfo[11];
            DayOfWeek = patientInfo[12];

            //Security questions
            Question1no = sQuestions.Next(1, 8);
            Question2no = sQuestions.Next(1, 7);
            Question3no = sQuestions.Next(1, 6);
            Answer1 = a.StringGenerator("allletters", 15);
            Answer2 = a.StringGenerator("allletters", 15);
            Answer3 = a.StringGenerator("allletters", 15);
            AnswerList.Add(0, Answer1);
            AnswerList.Add(1, Answer2);
            AnswerList.Add(2, Answer3);

            //passwords
            Password1 = a.StringGenerator("alphanumeric", 8) + "!()-@_ \"#$%&'*+,./:;<=>?[\\]^`{|}~ ";
            Password2 = a.StringGenerator("alphanumeric", 8);
            UserName = a.StringGenerator("alphanumeric", 10) + "-!()@_";
            string passAllLetters = a.StringGenerator("allletters", 3);
            string passAllNumbers = a.StringGenerator("allnumbers", 3);
            string passSpecialChar = a.StringGenerator("specialcharacters", 3);

            PassAllLetters = passAllLetters;
            PassAllNumbers = passAllNumbers;
            PasswordSpecialChar = passSpecialChar;
            UserPassword = passAllLetters + passAllNumbers + passSpecialChar;

            //Windows
            PatientPortal = a.StringGenerator("allletters", 9);
            
        }



        //Test execution
        public void CreateUserName()
        {
            SeleniumCommands a = new();
            string testCaseTitle = "Patient Portal Create User Name";
            a.AddLog("event", $"Started:  {testCaseTitle}");
            
            
            

            try
            {
                ModifyVars();

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
                a.TypeM("//input[@placeholder=\"Password\"]", UserPassword);
                a.TypeM("//input[@placeholder=\"Confirm Password\"]", UserPassword);
                a.ClickOn("//button[contains(text(),'Continue')]");
                a.ClickOn("//i[@class=\"icon ci-calendar\"]");
                a.ClickOn("//select[@class=\"custom-select\"][2]");
                a.ClickOn($"//option[contains(text(),'{Year}')]");
                a.ClickOn("//select[@class=\"custom-select\"][1]");
                a.ClickOn($"//option[contains(text(),'{MonthAbbrv}')]");
                a.ClickOn($"//div[@aria-label=\"{DayOfWeek}, {Month} {Day}, {Year}\"]");
                a.ClickOn("//button[@class=\"login-form__action-button login-form__action-button--sm login-form__action-button--blue mt-0\"]");
                a.ClickOn("//li[@formarrayname=\"answers\"][1]//div[@role=\"combobox\"]");
                SQuestion1 = a.SaveText($"//div[@role=\"option\"][{Question1no}]");
                SecurityQuestions.Add(0, SQuestion1);
                a.ClickOn($"//div[@role=\"option\"][{Question1no}]");
                a.TypeM("//li[@formarrayname=\"answers\"][1]//input[@formcontrolname=\"answer\"]", Answer1);
                a.ClickOn("//li[@formarrayname=\"answers\"][2]//div[@role=\"combobox\"]");
                a.Pause(1);
                SQuestion2 = a.SaveText($"//div[@role=\"option\"][{Question2no}]");
                SecurityQuestions.Add(1, SQuestion2);
                a.ClickOn($"//div[@role=\"option\"][{Question2no}]");
                a.TypeM("//li[@formarrayname=\"answers\"][2]//input[@formcontrolname=\"answer\"]", Answer2);
                a.ClickOn("//li[@formarrayname=\"answers\"][3]//div[@role=\"combobox\"]");
                a.Pause(1);
                SQuestion3 = a.SaveText($"//div[@role=\"option\"][{Question3no}]");
                SecurityQuestions.Add(2, SQuestion3);
                a.ClickOn($"//div[@role=\"option\"][{Question3no}]");
                a.TypeM("//li[@formarrayname=\"answers\"][3]//input[@formcontrolname=\"answer\"]", Answer3);
                a.ClickOn("//button[contains(text(),'Continue')]");
                a.WUntil("//aside[@class=\"main-menu d-flex flex-column\"]", 60);

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



        public void UserLogin()
        {
            SeleniumCommands a = new();
            string testCaseTitle = "Patient Portal User login";
            a.AddLog("event", $"Started:  {testCaseTitle}");
            

            try
            {
                CreateUserName();
                //Open Patient portal website
                a.StartDriver("Chrome", PatientPortal);
                a.NavTo("https://staging.curogram.com/login?hsLang=en");
                a.ClickOn("//button[contains(text(),' Login as Patient ')]");
                a.TypeM("//input[@placeholder=\"Username\"]",UserName);
                a.TypeM("//input[@placeholder=\"Password\"]", UserPassword);
                a.ClickOn("//button[@type=\"submit\"]");
                a.Pause(5);
                var otp2 = a.OtpViaMailSac(PEmail);
                a.TypeCode(otp2, "//input[@placeholder=\"—\"]");
                a.ClickOn("//button[@type=\"submit\"]");
                a.WUntil("//aside[@class=\"main-menu d-flex flex-column\"]", 60);


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

        public void RecoverUserName()
        {
            SeleniumCommands a = new();
            string testCaseTitle = "Patient Portal Recover Username";
            a.AddLog("event", $"Started:  {testCaseTitle}");


            try
            {

                UserLogin();

                //Open Patient portal website
                a.StartDriver("Chrome", PatientPortal);
                a.NavTo("https://staging.curogram.com/login?hsLang=en");
                a.ClickOn("//button[contains(text(),' Login as Patient ')]");
                a.ClickOn("//a[contains(text(),'Recover username')]");
                a.TypeM("//input[@placeholder=\"Enter your email address\"]", PEmail);
                a.ClickOn("//button[@type=\"submit\"]");
                a.Pause(5);
                var otp3 = a.OtpViaMailSac(PEmail);
                a.TypeCode(otp3, "//input[@placeholder=\"—\"]");
                a.ClickOn("//button[@type=\"submit\"]");
                a.WUntil("//div[@formarrayname=\"questions\"][1]//div[@class=\"login-form__label login-form__label--bold mb-2\"]");
                RQuestion1 = a.SaveText("//div[@formarrayname=\"questions\"][1]//div[@class=\"login-form__label login-form__label--bold mb-2\"]");
                RQuestion2 = a.SaveText("//div[@formarrayname=\"questions\"][2]//div[@class=\"login-form__label login-form__label--bold mb-2\"]");

                foreach (KeyValuePair<int, string> question in SecurityQuestions)
                {
                    if (question.Value == RQuestion1.Substring(3))
                    {
                        int keyNumber1 = question.Key;
                        RecoveryAnswer1 = AnswerList[keyNumber1];
                    }
                    if (question.Value == RQuestion2.Substring(3))
                    {
                        int keyNumber2 = question.Key;
                        RecoveryAnswer2 = AnswerList[keyNumber2];
                    }
                }
                a.TypeM("//div[@formarrayname=\"questions\"][1]//input[@placeholder=\"Enter your answer\"]", RecoveryAnswer1);
                a.TypeM("//div[@formarrayname=\"questions\"][2]//input[@placeholder=\"Enter your answer\"]", RecoveryAnswer2);
                a.ClickOn("//button[@type=\"submit\"]");
                a.WUntil("//div[contains(text(),'Please find the username in your email address or phone number. We have just sent it!')]");
                a.CheckElement("//div[contains(text(),'Please find the username in your email address or phone number. We have just sent it!')]");
                a.Pause(8);
                a.CheckEmailSubject(PEmail, "[Curogram] Account Recovery");


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

        [Test]
        public void ForgotPassword()
        {
            SeleniumCommands a = new();
            string testCaseTitle = "Patient Portal Forgot Password";
            a.AddLog("event", $"Started:  {testCaseTitle}");


            try
            {

                RecoverUserName();

                //Open Patient portal website
                a.StartDriver("Chrome", PatientPortal);
                a.NavTo("https://staging.curogram.com/login?hsLang=en");
                a.ClickOn("//button[contains(text(),' Login as Patient ')]");
                


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
