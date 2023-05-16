using Curogram_Automation_Testing.AppManager;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.AutomationTestScripts.ApiTesting.Default
{
    [TestFixture]
    public class Files
    {
        public static string ProviderAuthStaging;

        [Test]
        public void GetToken()
        {
            string providerAuthStaging = ConfigurationManager.AppSettings["providerAuthTokenStaging"];
            ProviderAuthStaging = providerAuthStaging;

        }





        public async Task FilesImage()
        {

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api-v2.staging.curogram.com/files?skip=0&take=30&type=image"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlYjY4ZWM0NzY5MWE1N2Y2ODRjODEyIiwiY3JlYXRlZEF0IjoxNjgzNTU2NDk5NjEwLCJidXNpbmVzc0lkIjoiNjJhMzAzZGI2YTQ1YWM0ZGU1ZGJkMWRiIiwiaWF0IjoxNjgzNTU2NDk5LCJleHAiOjE2ODYxNDg0OTksImlzcyI6ImFwaSJ9.U84OekHjqepdtuhcd9GsBIrNQu8wgoyhO6BUU6RhL1uAGDoGqu8So7G_S21tXKerCkvGvV_JogbvRndHW0N73utwruTqwO7sphxvsW8n75xAOkRo1y38aXM77V5N7tU-dXU1rxlcwUTb5DWjcDgMA3V_Ha9tJU-kYhGcGEKEmzieTKvjTxa_2cXI96a_8Cr-sIPHkAglDcYxOGrHphiCE0RL5cc-oVcE5ZqK01tyIa3DGbcXJ09HYMqZZAZte-xmfHGeI2L2WP6mb5IRPzbPMM_TfcFXoxJUIMCmhXAcboBIutqUMe9Oy34XvFcyouhNlGKxVrqEbyzBb24OtsP12A");
                    var response = await httpClient.SendAsync(request);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }
        }


        [Test]
        public void InvokeFilesApi()
        {
            string testCaseTitle = "Files";
            SeleniumCommands a = new();
            a.AddLog("event", $"Started:  {testCaseTitle}");

            try
            {
                GetToken();
                FilesImage().Wait();
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
