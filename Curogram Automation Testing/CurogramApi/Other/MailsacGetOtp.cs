using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Curogram_Automation_Testing.CurogramApi.Other
{
    public class MailsacGetOtp
    {
        public static String Email;
        public static String MailSacKey;
        public static String Otp;


        public async Task<String> GetMessagesByEmail()
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://mailsac.com/api/addresses/{Email}/messages"))
                {
                    request.Headers.TryAddWithoutValidation("Mailsac-Key", MailSacKey);


                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(responseContent);
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

        public async Task<String> GetMessageById()
        {
            MailsacGetOtp a = new();
            string stringResponse = await a.GetMessagesByEmail();
            JArray obj = JArray.Parse(stringResponse);
            string messageId = obj[0]["_id"].ToString();

            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://mailsac.com/api/text/{Email}/{messageId}"))
                {
                    request.Headers.TryAddWithoutValidation("Mailsac-Key", MailSacKey);


                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(responseContent);
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

        public async Task ExtractOTP()
        {
            MailsacGetOtp a = new();
            string stringResponse = await a.GetMessageById();

            Regex regex = new Regex(@"\d{6}");
            Match match = regex.Match(stringResponse);
            string otpCode = match.Value;
            Otp = otpCode;


        }

        public string GetOTP(string email, string mailSacKey = "k_rtJ7fZ6197XAsC5f4Ujyp2477Xc479U0rI4tg66ef")
        {
            Email = email;
            MailSacKey = mailSacKey;

            MailsacGetOtp a = new();
            a.ExtractOTP().Wait();
            return Otp;
        }
    }


}
