//This updates the practice's timezone to make sure that the automated messages are working and being sent to patients.

using NUnit.Framework;
using System.Net.Http.Headers;
using System.Net;


namespace Curogram_Automation_Testing.CurogramApi.Practice
{
    [TestFixture]
    internal class AutoUpdateTimeZone
    {
        public static String NewTimeZone;
        public void AutoUpTime()
        {
            DateTime now = DateTime.UtcNow.AddHours(-8);
            DateTime nineAm = DateTime.Today.AddHours(9);
            DateTime threePm = DateTime.Today.AddHours(15);
            DateTime ninePm = DateTime.Today.AddHours(21);
            DateTime threeAm = DateTime.Today.AddHours(3).AddDays(1);


            if (now >= nineAm && now < threePm)
            {
                AutoUpdateTimeZone.NewTimeZone = "US/Pacific";
            }
            else if(now >= threePm && now < ninePm)
            {
                AutoUpdateTimeZone.NewTimeZone = "America/New_York";
            }
            else if (now >= ninePm && now < threeAm)
            {
                AutoUpdateTimeZone.NewTimeZone = "Asia/Karachi";
            }
            else
            {
                AutoUpdateTimeZone.NewTimeZone = "Australia/West";
            };

        }



        public async Task<HttpResponseMessage> AutoTimeZone(string authToken, string practiceName)
        {
            AutoUpTime();
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PUT"), "https://api-v2.staging.curogram.com/practices/settings"))
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

                    request.Content = new StringContent("{\"name\":\"" + practiceName + "\",\"timezone\":\"" + AutoUpdateTimeZone.NewTimeZone + "\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        //var responseContent = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(responseContent);
                        return response;
                    }
                    else
                    {
                        //Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                        throw new Exception($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }
        }
    }
}

/* Use this code to call this method
 *         public async Task TimeZone()
        {
            var practiceName = "TestRigor Automation General (Do not change settings)";
            var authToken = "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoiYXBpIiwiYWNjb3VudElkIjoiNjNlMzZmYTFhY2EyMTA1NGM2YzNjOGQ3IiwiY3JlYXRlZEF0IjoxNjc3MDgxNDc1MDc0LCJidXNpbmVzc0lkIjoiNjNkMjk1ZmUyMDQ2YTE4NmI5OWIyNTM3IiwiaWF0IjoxNjc3MDgxNDc1LCJleHAiOjE2Nzk2NzM0NzUsImlzcyI6ImFwaSJ9.akR27vti8P0wn2dnl8OPtPs2u4JPmzoxE_CQDJqJ7x4NIiejSsR8onbYaBYn2Zv2bqeeuMheMI6cqfvN4ScXB1oPYbzcsVWLI_QOKuUEuHWso9z1w6lss9k-zOD64aECe7lWwgLCdKDF5WLv59Pe0lkUsv5TXNZmM6OABOp_fUX9ccF8ge59gNMzLYOMCg762-eMz2Yl9zqKRZGw6I5K4AXSCwPOp20nDJ6CVP0bwXzQwba9wJ_76yHWTPWReLJU64eh5JQ_0Cdb-_L4IIvtPjavdzstwBrMd59XJh59e-aRoaS6Jd0QJpXu7xT4mgE__YZz2teoFzhHpEKNlQnKgw";
            var response = await new AutoUpdateTimeZone().AutoTimeZone(authToken, practiceName);
            Console.WriteLine(response);
        }
*/