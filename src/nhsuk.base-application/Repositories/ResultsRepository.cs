using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using nhsuk.base_application.Configuration;
using nhsuk.base_application.Models;

namespace nhsuk.base_application.Repositories
{
    public class ResultsRepository : IResultsRepository
    {
        private readonly IAppSettings _appSettings;

        public ResultsRepository(IAppSettings appSettings) => _appSettings = appSettings;

        public async Task<List<Result>> GetResults(string org)
        {
            List<Result> results = new List<Result>();
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_appSettings.ResultsApiEndpoint + org + "/repos"),
                Method = HttpMethod.Get,
            };
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "test-app");

            HttpResponseMessage apiResponse = await client.SendAsync(request);

            if (apiResponse.IsSuccessStatusCode)
            {
                string apiResponseString = await apiResponse.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<Result>>(apiResponseString);
            }
            else
            {
                // Add logging with API error
            }

            return results;
        }
    }
}
