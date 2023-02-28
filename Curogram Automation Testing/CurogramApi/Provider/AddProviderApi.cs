using System.Net.Http.Headers;
using System.Net;
using NUnit.Framework;

namespace Curogram_Automation_Testing.CurogramApi.Provider
{
    internal class AddProviderApi
    {
        public async Task<HttpResponseMessage> AddProvidertMethod(string firstName, string lastName, string email, string practiceId, string authToken)
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"https://api-v2.staging.curogram.com/practices/{practiceId}/staff"))
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
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                    request.Content = new StringContent("{\"role\":\"admin\",\"staffType\":\"staff\",\"lowRateNotificationEnabled\":false,\"incomingDocumentEmailEnabled\":false,\"screeningResultsEnabled\":false,\"appointmentRequestNotificationEnabled\":false,\"preferredLocationIds\":null,\"firstName\":\"" + firstName + "\",\"lastName\":\"" + lastName + "\",\"prefix\":null,\"suffix\":null,\"email\":\"" + email + "\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent);
                        return response;
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


/* use this to call this method from a different class
        public async Task testApiRequest()
        {
            ModifyVars();
            string practiceId = "";
            string firstName = "";
            string lastName = "";  
            string email = "";
            string authToken = "";
            var response = await new AddProviderApi().AddProvidertMethod(firstName, lastName, email, practiceId, authToken);
            //Console.WriteLine(response);
        }
*/
