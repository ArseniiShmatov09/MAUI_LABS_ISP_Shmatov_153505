using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using MAUI_LABS.Entities;


namespace MAUI_LABS.Services
{
    public class RateService : IRateService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://www.nbrb.by/api/exrates/rates/";

        public RateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Rate GetRates(DateTime date, Currency currency)
        {
            string requestUrl = $"{_baseUrl}{currency.Cur_ID}?ondate={date:yyyy-MM-dd}";

            HttpResponseMessage response = _httpClient.GetAsync(requestUrl).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get exchange rate. Response status code: {response.StatusCode}");
            }

            string responseContent = response.Content.ReadAsStringAsync().Result;
            var rate = JsonConvert.DeserializeObject<Rate>(responseContent);

             return rate;
        }
    }
}
