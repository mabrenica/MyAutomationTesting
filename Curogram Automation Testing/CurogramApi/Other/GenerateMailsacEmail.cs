using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.CurogramApi.Other
{
    public class GenerateMailsacEmail
    {
 
        public async Task Generate(string generatedEmail, string passedMailsacKey = "k_rtJ7fZ6197XAsC5f4Ujyp2477Xc479U0rI4tg66ef")
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://mailsac.com/api/addresses/{generatedEmail}"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");
                    request.Headers.TryAddWithoutValidation("Mailsac-Key", passedMailsacKey);

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(response);
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
