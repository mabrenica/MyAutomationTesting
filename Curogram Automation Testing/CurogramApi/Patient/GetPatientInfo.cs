using GraphQL;
using GraphQL.Client.Http;
using NUnit.Framework;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace Curogram_Automation_Testing.CurogramApi.Practice
{
    [TestFixture]
    public class VerifyPatientByName
    {
        public static String? PatientID;
        public static String AuthToken;

        public async Task GetPatientByName(string firstName)
        {
            var query = new GraphQLRequest
            {
                Query = @"
        query GetPatientList($skip: Int, $take: Int, $q: String) {
          patients(skip: $skip, take: $take, q: $q) {
            totalItemCount
            items {
              id
            }
          }
        }
    ",
                Variables = new
                {
                    skip = 0,
                    take = 30,
                    q = $"{firstName}"
                }
            };

            var client = new GraphQLHttpClient("https://api-v2.staging.curogram.com/graphql", new NewtonsoftJsonSerializer());
            client.HttpClient.DefaultRequestHeaders.Add("Authorization", AuthToken);
            var response = await client.SendQueryAsync<dynamic>(query);
            var patientID = response.Data.patients.items[0].id;

            PatientID = patientID;
        }

        public async Task VerifyPatient(string authToken, string firstName, string middleName, string lastName, string email, string phone)
        {
            AuthToken = authToken;
            await GetPatientByName(firstName);
            
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://api-v2.staging.curogram.com/patients/{PatientID}"))
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
                        string rEmail = obj["emails"][0].ToString();
                        string rFirstName = obj["firstName"].ToString();
                        string rMiddleName = obj["middleName"].ToString();
                        string rLastName = obj["lastName"].ToString();
                        string rPhone = obj["phones"][0].ToString();
                        string rInsuranceFront = obj["insurance"]["front"]["fileVariations"][0]["url"].ToString();
                        string rInsuranceBack = obj["insurance"]["back"]["fileVariations"][0]["url"].ToString();
                        string rDriversLicenseFront = obj["driversLicense"]["front"]["fileVariations"][0]["url"].ToString();
                        string rDriversLicenseBack = obj["driversLicense"]["back"]["fileVariations"][0]["url"].ToString();


                        Assert.IsTrue(rEmail == email);
                        Assert.IsTrue(rPhone == phone);
                        Assert.IsTrue(rFirstName == firstName);
                        Assert.IsTrue(rMiddleName == middleName);
                        Assert.IsTrue(rLastName== lastName);
                        Assert.IsNotNull(rInsuranceFront);
                        Assert.IsNotNull(rInsuranceBack);
                        Assert.IsNotNull(rDriversLicenseFront);
                        Assert.IsNotNull(rDriversLicenseBack);
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
