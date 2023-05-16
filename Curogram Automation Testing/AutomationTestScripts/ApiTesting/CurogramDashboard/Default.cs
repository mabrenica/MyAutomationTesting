using Curogram_Automation_Testing.AppManager;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.AutomationTestScripts.ApiTesting.Default
{
    [TestFixture]
    public class Default
    {

        public async Task Check()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api-v2.staging.curogram.com/check"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");

                    var response = await httpClient.SendAsync(request);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }
        }

        public async Task Ready()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api-v2.staging.curogram.com/ready"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");

                    var response = await httpClient.SendAsync(request);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }
        }

        [Test]
        public void InvokeDefaultApi()
        {
            string testCaseTitle = "Default";
            SeleniumCommands a = new();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                Check().Wait();
                Ready().Wait();
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
