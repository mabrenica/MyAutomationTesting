/* 
 * Mailsac username: marnel.abrenica@curogram.com
 * Mailsac password: G3h_amping123
 */



using NUnit.Framework;
using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.CurogramApi.Provider;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword
{
    [TestFixture]
    [Parallelizable]
    internal class ResetProviderPassword
    {
        public static String FirstName;
        public static String LastName;
        public static String Email;
        public static String Password;
        public static String YopWeb;
        public static String CuroWeb;
        public static String YopEmail;



        //modify class variables
        public static void ModifyVars()
        {
            SeleniumCommands a= new SeleniumCommands();

            var genFirstName = a.StringGenerator("allletters", 9);
            var genLastName = a.StringGenerator("allletters", 9);
            var genEmail = a.StringGenerator("alphaneumeric", 9);
            var genPassword = a.StringGenerator("alphaneumeric", 9);
            var yopWeb = a.StringGenerator("alphanumeric", 9);
            var curoWeb = a.StringGenerator("alphanumeric", 9);
            var yopEmail = a.StringGenerator("alphanumeric", 9);

            ResetProviderPassword.FirstName = genFirstName;
            ResetProviderPassword.LastName = genLastName;
            ResetProviderPassword.Email = genEmail+"@mailsac.com";
            ResetProviderPassword.Password = genPassword + 1;
            ResetProviderPassword.YopWeb = yopWeb;
            ResetProviderPassword.CuroWeb = curoWeb;
            ResetProviderPassword.YopEmail = yopEmail;
        }




        //Create a user with yopmail email via api
        public async Task ApiRequest()
        {
            ModifyVars();
            string practiceId = "63d295fe2046a186b99b2537";
            string firstName = ResetProviderPassword.FirstName;
            string lastName = ResetProviderPassword.LastName;  
            string email = ResetProviderPassword.Email;
            string authToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoibG9naW5BcyIsImFjY291bnRJZCI6IjYzZTM2ZmExYWNhMjEwNTRjNmMzYzhkNyIsImNyZWF0ZWRBdCI6MTY3NTg2MDM4ODI4MywiYnVzaW5lc3NJZCI6IjYzZDI5NWZlMjA0NmExODZiOTliMjUzNyIsImlhdCI6MTY3NTg2MDM4OCwiZXhwIjoxNjc4NDUyMzg4LCJpc3MiOiJsb2dpbkFzIn0.p2DpDRQR7ALT23M2t9bHVFR142YnuFYSlfHhTOaWj7uQybOoPodd_QEyNKa4Zn1rYG5FnyUj1IeiQSFJCLDXOKAuvRRuSzbu9qTZZbrMptIFFH3353Ty7m2oLQopbnciotpUoYhobqQp-6NfEBuH_UWem-O8xotUra9txH_WGs4-kTwKSz7vrbQA6IjwAlbITNdwX4Oi4sE3vZbLysOOqvgwGwx9pE9Rilc_dRqWpDyF_2gyhDEX_Nq-5wTCQUK5J12IdrsKYGAoeosdnvbmQQqFOW3BGW6Dozlreu2oyeW_I9fN_2MauG1b3pB1PomaSOvrAdiBd7L0BBrcokuKYQ";
            var response = await new AddProviderApi().AddProvidertMethod(firstName, lastName, email, practiceId, authToken);
            //Console.WriteLine(response);
        }





        [Test]
        public void ResetUserPassword()
        {
            ModifyVars();
            ApiRequest();
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Reset User Password");

            try
            {
                //open yopmail website
                a.StartDriver("Chrome");
                a.SaveWindow(ResetProviderPassword.YopWeb, 0);
                a.NavTo("https://mailsac.com/login");
                a.Pause(4);
                a.TypeM("//input[@name='username']", "marnel.abrenica@curogram.com");
                a.Pause(1);
                a.TypeM("//input[@name='password']", "G3h_amping123");
                a.Pause(1);
                a.ClickOn("//button[@type='submit']");
                a.Pause(4);


                //register generated email in mailsac
                a.TypeM("//input[@type='text'][1]", ResetProviderPassword.Email);
                a.Pause(1);
                a.ClickOn("//button[contains(text(),'Check the mail!')]");


                //Start new Curogram window
                a.StartNewWindow(ResetProviderPassword.CuroWeb);
                a.Pause(4);
                a.NavTo("https://staging.curogram.com");
                a.Pause(7);


                //click Sign in
                a.ClickOn("//a[@href='/login?hsLang=en']");
                a.WUntil(30, "//div[@class='login-header']");


                //Click Forgot Password
                a.ClickOn("//button[@class='login-form__label login-form__label--grey bg-transparent border-0 mt-3 mx-auto d-block']");
                a.Pause(1);
                a.ClickOn("//input[@name='email']");
                a.Pause(1);

                //Enter generated email
                a.TypeM("//input[@name='email']", ResetProviderPassword.Email);
                a.Pause(1);
                a.ClickOn("//button[@_ngcontent-curogram-public-c97=''][2]");
                a.Pause(3);
                a.VerifyText("//div[@class='modal-body']", "We will send you an email with instructions to reset your password if we find an account associated with this email address");
                a.DClose();


                //Swith to Yopmail window and reset the password
                a.Pause(20);
                a.SwitchWindow(ResetProviderPassword.YopWeb);
                a.Refresh();
                a.Pause(7);
                a.ClickOn("//td[contains(text(),'[Curogram] Password reset')]");
                a.Pause(1);
                a.ClickOn("//a[@class='btn btn-info btn-xs']");
                a.Pause(3);
                a.SaveWindow(ResetProviderPassword.YopEmail, 1);
                a.SwitchWindow(ResetProviderPassword.YopEmail);
                a.ClickOn("//a[contains(text(),'Your Password')]");
                a.Pause(7);
                a.TypeM("//input[@type='password']", ResetProviderPassword.Password);
                a.Pause(1);
                a.ClickOn("//button[contains(text(),'Reset password')]");
                a.Pause(3);
                a.VerifyText("//div[contains(text(),'Quick Actions')]", "Quick Actions");
                a.DQuit();


                //Test Pass
                TestLogger.Logger("Reset Provider Login: Pass");
            }
            catch (Exception e)
            {
                string message = "Reset Provider Login: Fail - -";
                TestLogger.Logger(message + e.Message);
                Console.WriteLine(message + e.Message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));
            }
        }

        

    }

        


}

