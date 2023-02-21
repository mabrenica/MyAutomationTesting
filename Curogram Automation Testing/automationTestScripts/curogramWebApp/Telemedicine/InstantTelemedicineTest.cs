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

        //Add Patient record through API
        public async Task AddPatientApi()
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-v2.staging.curogram.com/practices/63d295fe2046a186b99b2537/patients"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
                    request.Headers.TryAddWithoutValidation("Authorization", "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc2OTE3NDI1NzY1LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc2OTE3NDI1LCJleHAiOjE2Nzk1MDk0MjUsImlzcyI6ImFwaSJ9.berD3cG1L965IDr40GrfODC7A_5STNgvu1Fc9FsRHPG53LhXHFTDtbVyy3qOUB3vjnBnB4Hd3h2oU0lrSDOMXGQ4j_FlSP3IafOk6vhv1xjoQH3MyLdyL3eLXUSVKIqKti8QfmH4Omnimu62r_DMh_eF7W5XKddIPsMnXg3qJN7kRpPLuX0m7GUo1_uG3SfwvmWnqc_0fSzKOQCwm3A7D-BiiQ_O2jH3eQRPQLWiwp8gnG3do9ICXFRqxDLQxI6YpfLZ8hzQb8xThNg9Kk67vNTUzvEnWdm29qbVCOMnI-PT2lEey_vwiG85jClzo1RqQfHklAi0YNKBcMxHd0qsvA");
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Origin", "https://app.staging.curogram.com");
                    request.Headers.TryAddWithoutValidation("Referer", "https://app.staging.curogram.com/");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-site");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Google Chrome\";v=\"110\"");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                    request.Headers.TryAddWithoutValidation("sec-gpc", "1");

                    request.Content = new StringContent("{\"firstName\":\""+ InstantTelemedicineTest.FirstName + "\",\"lastName\":\""+ InstantTelemedicineTest.LastName + "\",\"emails\":[\""+ InstantTelemedicineTest.Email+ "@mailsac.com"+"\"]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent);
                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }
        }


        [Test]
        public void Telemed()
        {
            ModifyVars();
            AddPatientApi();
            Console.WriteLine("First Name is :" + InstantTelemedicineTest.FirstName + " Last Name is : " + InstantTelemedicineTest.LastName);
            var FullName = InstantTelemedicineTest.FirstName + " " + InstantTelemedicineTest.LastName;
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

                //Opening patient conversation
                a.Pause(5);
                a.ClickOn("//curogram-icon[@apptooltip='New appointment']");
                a.Pause(5);
                a.ClickOn("//input[@placeholder='Find by name or phone number...']");
                a.Type("//input[@placeholder='Find by name or phone number...']", InstantTelemedicineTest.FirstName);
                a.Pause(5);
                a.ClickOn("//li[@class='list__item ng-star-inserted']");

                //Create instant telemedicine appointment
                a.Pause(4);
                a.ClickOn("//button[@class='btn btn-primary']");
                a.Pause(5);
                a.SwitchWin(0);
                a.ClickOn("//span[contains(text(),'Telemedicine')]");
                a.Pause(3);
                a.Type("//input[@placeholder='Find by name']", InstantTelemedicineTest.FirstName);
                a.Pause(3);
                a.ClickOn("//curogram-icon[@name='more']");
                a.Pause(2);
                a.ClickOn("//curogram-icon[@name='refresh-1']");
                a.Pause(2);
                a.Type("//input[@placeholder='Phone']", "9999999999");
                a.Pause(2);
                a.ClickOn("//button[@class='btn btn-peterriver']");
                a.Pause(6);

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
