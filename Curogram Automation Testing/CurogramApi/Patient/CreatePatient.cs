using System.Net.Http.Headers;
using System.Net;
using NUnit.Framework;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine;
using Curogram_Automation_Testing.AppManager;
using System.Net.NetworkInformation;
using Newtonsoft.Json.Linq;

namespace Curogram_Automation_Testing.CurogramApi.Practice
{
    [TestFixture]
    internal class CreatePatient
    {
        public static String AuthToken;
        public static String MailsacKey ;
        public static String PatientInfo;
        public static String PracticeId;
        public static bool ForOtp;

        public async Task CreatePatientMethod()
        {
            SeleniumCommands b = new();


            string firstName = b.StringGenerator();
            string lastName = b.StringGenerator();
            string middleName = b.StringGenerator();
            string email = b.EmailGenerator(mailsacKey: MailsacKey, forOtp: ForOtp) ;


            var handler = new HttpClientHandler();

            

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"https://api-v2.staging.curogram.com/practices/{PracticeId}/patients"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
                    request.Headers.TryAddWithoutValidation("Authorization", AuthToken);
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

                    request.Content = new StringContent("{\"firstName\":\"" + firstName + "\",\"middleName\":\""+ middleName + "\",\"lastName\":\"" + lastName + "\",\"emails\":[\"" + email + "\"],\"dob\":\"2023-01-01T12:00:00.000Z\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(response);

                        JObject obj = JObject.Parse(responseContent);
                        string patientID = obj["id"].ToString();
                        string patientFirstName = obj["firstName"].ToString();
                        string patientMiddleName = obj["middleName"].ToString();
                        string patientLastName = obj["lastName"].ToString();
                        string patientDob = obj["dob"].ToString();
                        string patientEmail = obj["emails"][0].ToString();


                        PatientInfo = $"{patientID},{patientFirstName},{patientMiddleName},{patientLastName},{patientDob},{patientEmail}";
                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                        throw new Exception($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }
        }
        [Test]
        public string PatientGenerator(string practiceId, string authToken, string mailsacKey = "k_rtJ7fZ6197XAsC5f4Ujyp2477Xc479U0rI4tg66ef", bool forOtp = false)
        {
            PracticeId = practiceId;
            AuthToken= authToken;
            MailsacKey = mailsacKey;
            ForOtp= forOtp;


            CreatePatient a = new();
            a.CreatePatientMethod().Wait();
            return PatientInfo;
        }
    }
}
