using System.Net.Http.Headers;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace Curogram_Automation_Testing.CurogramApi.Provider
{
    [TestFixture]
    public class ProviderLoginApi
    {
        public static string UserEmail;
        public static string Password;
        public static string AuthToken;
        public async Task ProviderLoginApiMethod()
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-v2.staging.curogram.com/authenticate/login"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json");

                    request.Content = new StringContent("{\n  \"email\": \"" +UserEmail+ "\",\n  \"password\": \""+Password+"\",\n  \"userType\": \"provider\",\n  \"deviceType\": \"web\"\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        JObject authTokenRaw = JObject.Parse(responseContent);
                        string authToken = authTokenRaw["authToken"].ToString();
                        AuthToken = authToken;
                    }
                    else
                    {;
                        AuthToken = null;
                    }
                }
            }
        }

        public async Task GetToken(string userEmail, string password)
        {
            UserEmail = userEmail;
            Password = password;    
            ProviderLoginApi a = new();
            await a.ProviderLoginApiMethod();
        }
        public string ReturnString()
        {
            return AuthToken;
        }
    }
}

