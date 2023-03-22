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
    public class ResetProviderPassword
    {
        public static String? FirstName;
        public static String? LastName;
        public static String? Email;
        public static String? Password;
        public static String? YopWeb;
        public static String? CuroWeb;
        public static String? YopEmail;



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

            FirstName = genFirstName;
            LastName = genLastName;
            Email = genEmail+"@mailsac.com";
            Password = genPassword + 1;
            YopWeb = yopWeb;
            CuroWeb = curoWeb;
            YopEmail = yopEmail;
        }




        //Create a user with yopmail email via api
        public async Task ApiRequest()
        {
            ModifyVars();
            string practiceId = "63d295fe2046a186b99b2537";
            string firstName = FirstName;
            string lastName = LastName;  
            string email = Email;
            string authToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc4Njk3MDc1NzcwLCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc4Njk3MDc1LCJleHAiOjE2ODEyODkwNzUsImlzcyI6ImFwaSJ9.Tul3DE0hyCRJftip7svQVyWrof55C7d7ntvNYeNMPU7-bxP_UVQRpx7vwAXMNog9tlDu9UpjawsIW9FSBFvQeRs6WYp9wdk1el0HqtfhzR6hlKQeClRjWTzC1mDIlQVXgNdssRs_MNi-ItKmwDUXOAHE4AWsZPoB0mB2QoX8rdQyS_m0f2H7eub7HnZDFPb6tn8zEGOMfuAAblYPv0kx0CQZjuYQyKtobauzSfLkScWVfnPfVnHpca5DwCK2nt2vMCJ6dlHFVxa4X7La7cGsVHEUI1FkkVEBtPj2C2CHnH-daleJYCRk8R20eCd7sUy6JjDedgrVk-RFxJgJqyQQuA";
            var response = await new AddProviderApi().AddProvidertMethod(firstName, lastName, email, practiceId, authToken);
            Console.WriteLine(response);
        }





        [Test]
        public void ResetUserPassword()
        {
            string testCaseTitle = "Reset User Password";
            ModifyVars();
            _=ApiRequest();
            SeleniumCommands a = new SeleniumCommands();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                //open yopmail website
                a.StartDriver("Chrome", YopWeb);
                a.NavTo("https://mailsac.com/login");
                a.Pause(4);
                a.TypeM("//input[@name='username']", "marnel.abrenica@curogram.com");
                a.Pause(1);
                a.TypeM("//input[@name='password']", "G3h_amping123");
                a.Pause(1);
                a.ClickOn("//button[@type='submit']");
                a.Pause(4);


                //register generated email in mailsac
                a.TypeM("//input[@type='text'][1]", Email);
                a.Pause(1);
                a.ClickOn("//button[contains(text(),'Check the mail!')]");


                //Start new Curogram window
                a.StartNewWindow(CuroWeb);
                a.Pause(4);
                a.NavTo("https://staging.curogram.com");
                a.Pause(7);


                //click Sign in
                a.ClickOn("//a[@href='/login?hsLang=en']");
                a.WUntil("//div[@class='login-header']");


                //Click Forgot Password
                a.ClickOn("//button[@class='login-form__label login-form__label--grey bg-transparent border-0 mt-3 mx-auto d-block']");
                a.Pause(1);
                a.ClickOn("//input[@name='email']");
                a.Pause(1);

                //Enter generated email
                a.TypeM("//input[@name='email']", Email);
                a.Pause(1);
                a.ClickOn("//button[@_ngcontent-curogram-public-c97=''][2]");
                a.Pause(3);
                a.VerifyText("//div[@class='modal-body']", "We will send you an email with instructions to reset your password if we find an account associated with this email address");
                a.DClose();


                //Swith to Yopmail window and reset the password
                a.SwitchWindow(YopWeb);
                a.RefreshUntil("//td[contains(text(),'[Curogram] Password reset')]");
                a.ClickOn("//td[contains(text(),'[Curogram] Password reset')]");
                a.Pause(1);
                a.ClickOn("//a[@class='btn btn-info btn-xs']");
                a.Pause(3);
                a.SaveWindow(YopEmail, 1);
                a.SwitchWindow(YopEmail);
                a.ClickOn("//a[contains(text(),'Your Password')]");
                a.Pause(7);
                a.TypeM("//input[@type='password']", Password);
                a.Pause(1);
                a.ClickOn("//button[contains(text(),'Reset password')]");
                a.WUntil("//div[contains(text(),'Main Menu')]");
                a.VerifyText("//div[contains(text(),'Main Menu')]", "Main Menu");
                a.DQuit();


                //Test Pass
                a.AddLog("allType", $"Pass:  {testCaseTitle}");
            }
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

