using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using Newtonsoft.Json;

namespace T2.Classes
{
    public class ApiHelper
    {
        public async Task<MarketData> FetchDataAsync(long startDate, long endDate)
        {
            string baseUrl = "https://api.coingecko.com/api/v3/coins/bitcoin/market_chart/range";
            string url = $"{baseUrl}?vs_currency=eur&from={startDate}&to={endDate}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MarketData>(json);
            }
        }

        public async Task<string> ApiPing()
        {
            string url = "https://api.coingecko.com/api/v3/ping";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

    }
}
