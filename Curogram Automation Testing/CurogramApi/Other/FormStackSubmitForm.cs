using System.Net.Http.Headers;
using System.Net;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Curogram_Automation_Testing.CurogramApi.Other
{
    [TestFixture]
    public class FormStackSubmitForm
    {
        public static String? SubmissionID;
        [Test]
        public async Task<string> SubmitFormApi(string firstName, string middleName, string lastName, string email, string address, string nonce, string homePhone = "(845) 266-7150", string cellPhone = "(845) 266-7150")
        {
            string fileName = "test_image.png";
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-v2.curogram.com/practice/forms/submit-form?url=https%253A%252F%252Fcurogram.formstack.com%252Fforms%252Findex.php%253Fjsonp"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Origin", "https://forms.staging.curogram.com");
                    request.Headers.TryAddWithoutValidation("Referer", "https://forms.staging.curogram.com/");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-site");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Google Chrome\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");

                    var multipartContent = new MultipartFormDataContent();
                    multipartContent.Add(new StringContent("5208257"), "form");
                    multipartContent.Add(new StringContent("WsD22v51CT"), "viewkey");
                    multipartContent.Add(new StringContent(""), "password");
                    multipartContent.Add(new StringContent(""), "hidden_fields");
                    multipartContent.Add(new StringContent(""), "incomplete");
                    multipartContent.Add(new StringContent(""), "incomplete_password");
                    multipartContent.Add(new StringContent("https://forms.staging.curogram.com/"), "referrer");
                    multipartContent.Add(new StringContent("js"), "referrer_type");
                    multipartContent.Add(new StringContent("1"), "_submit");
                    multipartContent.Add(new StringContent("3"), "style_version");
                    multipartContent.Add(new StringContent("833397"), "viewparam");
                    multipartContent.Add(new StringContent(firstName), "field141065980-first");
                    multipartContent.Add(new StringContent(middleName), "field141065980-middle");
                    multipartContent.Add(new StringContent(lastName), "field141065980-last");
                    multipartContent.Add(new StringContent("MDY"), "field141065982Format");
                    multipartContent.Add(new StringContent("January"), "field141065982M");
                    multipartContent.Add(new StringContent("01"), "field141065982D");
                    multipartContent.Add(new StringContent("2000"), "field141065982Y");
                    multipartContent.Add(new StringContent(homePhone), "field141065995");
                    multipartContent.Add(new StringContent(cellPhone), "field141065998");
                    multipartContent.Add(new StringContent(email), "field141066000");
                    multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(imagePath)), "field141066002", Path.GetFileName(imagePath));
                    multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(imagePath)), "field141066123", Path.GetFileName(imagePath));
                    multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(imagePath)), "field141066124", Path.GetFileName(imagePath));
                    multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(imagePath)), "field141066125", Path.GetFileName(imagePath));
                    multipartContent.Add(new StringContent(address), "field141066249");
                    multipartContent.Add(new StringContent("\"Mozilla/5.0 (Windows NT 10.0"), "fsUserAgent");
                    multipartContent.Add(new StringContent(nonce), "nonce");
                    request.Content = multipartContent;


                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        Regex regex = new Regex(@"\d{10}");
                        Match match = regex.Match(responseContent);
                        string submissionId = match.Value;
                        SubmissionID = submissionId;
                        
                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                        throw new Exception($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }

            FormStackSubmitForm a = new();
            string formstackResponse = await a.ReceivePackage(SubmissionID);
            return formstackResponse;
        }


        public async Task<string> ReceivePackage(string submissionID)
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-v2.staging.curogram.com/practice/forms/receive-package"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Origin", "https://forms.staging.curogram.com");
                    request.Headers.TryAddWithoutValidation("Referer", "https://forms.staging.curogram.com/");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-site");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Google Chrome\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");

                    request.Content = new StringContent("{\"packageId\":\"6412fb93fd87f5818844e769\",\"submissionIds\":[\"" + submissionID + "\"]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return responseContent;
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
