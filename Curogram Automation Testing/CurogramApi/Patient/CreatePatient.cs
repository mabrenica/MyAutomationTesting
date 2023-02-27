using System.Net.Http.Headers;
using System.Net;
using NUnit.Framework;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine;

namespace Curogram_Automation_Testing.CurogramApi.Practice
{

    internal class CreatePatient
    {
        public async Task<HttpResponseMessage> CreatePatientMethod(string firstName, string lastName, string email, string authToken)
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-v2.staging.curogram.com/practices/63d295fe2046a186b99b2537/patients"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
                    request.Headers.TryAddWithoutValidation("Authorization", authToken);
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

                    request.Content = new StringContent("{\"firstName\":\"" + firstName + "\",\"lastName\":\"" + lastName + "\",\"emails\":[\"" + email + "\"]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(responseContent);
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
         public async Task AddPatientApi()
        {
            var firstName = "{firstName}";
            var lastName = "{lastName}";
            var email = "{email}";
            var authToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc3MDgxNDc1MDc0LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc3MDgxNDc1LCJleHAiOjE2Nzk2NzM0NzUsImlzcyI6ImFwaSJ9.akR27vti8P0wn2dnl8OPtPs2u4JPmzoxE_CQDJqJ7x4NIiejSsR8onbYaBYn2Zv2bqeeuMheMI6cqfvN4ScXB1oPYbzcsVWLI_QOKuUEuHWso9z1w6lss9k-zOD64aECe7lWwgLCdKDF5WLv59Pe0lkUsv5TXNZmM6OABOp_fUX9ccF8ge59gNMzLYOMCg762-eMz2Yl9zqKRZGw6I5K4AXSCwPOp20nDJ6CVP0bwXzQwba9wJ_76yHWTPWReLJU64eh5JQ_0Cdb-_L4IIvtPjavdzstwBrMd59XJh59e-aRoaS6Jd0QJpXu7xT4mgE__YZz2teoFzhHpEKNlQnKgw";
            var response = await new CreatePatient().CreatePatientMethod(firstName, lastName, email, authToken);
            Console.WriteLine(response);
        }
*/

/* API link
 * https://api-v2.dev.curogram.com/apidoc/static/index.html#/Patients/PracticePatientsController_updateOrCreate
 */