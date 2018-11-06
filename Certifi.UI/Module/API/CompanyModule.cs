using Nancy;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApplication1.Module.API
{
    public class CompanyModule : NancyModule
    {
        public CompanyModule()
        {
            Get("/api/company/{number:int}", p => GetCompanyDetails(p.number));
        }

        public dynamic GetCompanyDetails(int number)
        {
            string text = "cbDDrDEdCMRnScMRxqDTwWe3U400pApmPOjyQ4_D";
            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(text));

            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.companieshouse.gov.uk/company/" + number.ToString("00000000")),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", "Basic " + encoded);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var task = client.SendAsync(request);
            task.Wait();
            HttpResponseMessage response = task.Result;

            var jsonTask = response.Content.ReadAsStringAsync();
            jsonTask.Wait();
            var resultText = jsonTask.Result;

            var responseObj = JsonConvert.DeserializeObject<FindCompanyResponse>(resultText);

            return new
            {
                Number = responseObj.company_number,
                Name = responseObj.company_name,
                SiteLocation = responseObj.jurisdiction,
                Status = responseObj.type
            };
        }
    }

    public class FindCompanyResponse
    {
        public string company_number { get; set; }

        public string company_name { get; set; }

        public string jurisdiction { get; set; }

        public string type { get; set; }
    }
}
