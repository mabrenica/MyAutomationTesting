using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.CurogramApi.Other
{
    internal class AddressGenerator
    {
        public async Task<String> AddGen()
        {
            var handler = new HttpClientHandler();

            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://randommer.io/random-address"))
                {
                    request.Headers.TryAddWithoutValidation("authority", "randommer.io");
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("accept-language", "en-US,en;q=0.9");
                    request.Headers.TryAddWithoutValidation("cookie", "ezoadgid_232529=-1; ezoref_232529=bing.com; ezosuibasgeneris-1=e41f2e2d-86f4-4fb6-4f33-48449d16fcf3; ezoab_232529=mod1; ezovid_232529=344415328; lp_232529=https://randommer.io/random-address; ezovuuid_232529=d1584746-0cce-4704-652a-267781a38d22; ezds=ffid%3D1%2Cw%3D1536%2Ch%3D864; _pbjs_userid_consent_data=3524755945110770; ezouspvh=44; __gpi=UID=00000bda10c22c8e:T=1678966423:RT=1678966423:S=ALNI_MbXa06xXHX4hUVez3v2hjuOyt8jXQ; _cc_id=c68195d0962fed9cdead7ed40d48305e; panoramaId=2b2c2ab52c3cc6997a11a2c8107e16d539382954374ae062e52c6dfe343b8e15; panoramaIdType=panoIndiv; __gads=ID=10f848b9c9814b80-22aaaa9502dc00ea:T=1678966423:S=ALNI_MYnpYxAEypHpbpGQyQOMaTIrrFD5Q; panoramaId_expiry=1679571227988; ezux_ifep_232529=true; ezux_lpl_232529=1678966443318|75b75569-0ae0-42a0-7032-62e8ea93e1f2|false; active_template::232529=pub_site.1678966479; ezopvc_232529=2; ezepvv=80; ezovuuidtime_232529=1678966480; ezohw=w%3D1479%2Ch%3D414; ezux_et_232529=56; ezux_tos_232529=62; _sharedid=0e58f502-8d6e-4b08-a167-97c09f7b0d88; cto_bundle=EXKZpV9QOSUyRlZEbDZucVdjQTh6S2lYV2F5Nm9XdVFWMUl6cEhZU2ROWGpaZEl3bUZBUm1ZaWZ5U0c1aFE3YmZQNCUyQlolMkJlNTZHZ3AlMkZPck5FcTNlOXMxcVl0TWxDMlNFemh5V0Q2NTF3UUJUU2RBUnUxOHZtQUFlRWt0R0trJTJCaFltRTZJVzh4Y1I0NHFtbHg2VEk5eGRPOUFjaiUyQnclM0QlM0Q; cto_bidid=G0_-AF9sbWZaQiUyRnQlMkZDanQlMkJabExqS1ozT0FUVThYNHdsU1poOTBQVUZCeWxnOEIxRnhtSkw1OXlpVzVCMVZUcjNiNklweWxKcG9tVmh5a3BTQ2lYb2JQdWI1aHI0OFNUbFdyazh3NFJtQnZLN21EQSUzRA; ezouspvv=32; cto_dna_bundle=h1zGdl80M0RITmhlJTJCZkMwOUJGQlhaMUN2czNjaGJYZWxnYjNTMkx1UmJFQlQzTSUyRm00VDcyMTlvR291OUxkMzJSejklMkJk; ezouspva=7");
                    request.Headers.TryAddWithoutValidation("origin", "https://randommer.io");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Microsoft Edge\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                    request.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
                    request.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
                    request.Headers.TryAddWithoutValidation("sec-fetch-site", "same-origin");
                    request.Headers.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36 Edg/111.0.1661.43");
                    request.Headers.TryAddWithoutValidation("x-requested-with", "XMLHttpRequest");

                    request.Content = new StringContent("number=1&culture=en_US&X-Requested-With=XMLHttpRequest");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded; charset=UTF-8");

                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
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

    }
}
