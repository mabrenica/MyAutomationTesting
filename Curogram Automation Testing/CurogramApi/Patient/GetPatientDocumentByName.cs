using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.CurogramApi.Patient
{
    public class GetPatientDocumentByName
    {
        public async Task VerifyDocument(string authToken, string firstName, string lastName)
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://api-v2.staging.curogram.com/practice/documents?skip=0&take=30&isReviewed=false&q={firstName}"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9,fil;q=0.8,es;q=0.7");
                    request.Headers.TryAddWithoutValidation("Authorization", authToken);
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Origin", "https://app.staging.curogram.com");
                    request.Headers.TryAddWithoutValidation("Referer", "https://app.staging.curogram.com/");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-site");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Google Chrome\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        JObject obj = JObject.Parse(responseContent);
                        string rFirstName = obj["items"][0]["patient"]["firstName"].ToString();
                        string rLastName = obj["items"][0]["patient"]["lastName"].ToString();
                        string rDocumentUrl = obj["items"][0]["file"]["fileVariations"][0]["url"].ToString();


                        Assert.IsTrue(rFirstName == firstName);
                        Assert.IsTrue(rLastName == lastName);
                        Assert.IsNotNull(rDocumentUrl);
                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                        throw new Exception($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }
        }
    }
}
