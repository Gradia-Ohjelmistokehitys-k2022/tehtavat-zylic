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
            string baseUrl = "https://api.coingecko.com/api/v3/coins/bitcoin/market_chart/range"; // API Url
            string url = $"{baseUrl}?vs_currency=eur&from={startDate}&to={endDate}"; // Combines baseUrl with an endpoint for more concise code and readability

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);  // Sends a GET request and waits for APIs response
                response.EnsureSuccessStatusCode(); // Ensures the GET request comes back true
                string json = await response.Content.ReadAsStringAsync(); // Reads the API response
                return JsonConvert.DeserializeObject<MarketData>(json); // Deserializes the response into a .NET object so its easier to use in code
            }
        }
        public async Task<string> ApiPing()
        {
            string url = "https://api.coingecko.com/api/v3/ping"; // Api URL

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url); // GET request to API to check for connection

            response.EnsureSuccessStatusCode(); // Ensures the GET request comes back true

            string content = await response.Content.ReadAsStringAsync(); // Reads the APIs response

            dynamic parsedResponse = JsonConvert.DeserializeObject(content); // Deserializes the JSON into a .NET object

            return parsedResponse.gecko_says; // Returns APIs response
        }
        public DateTime UnixSecToDateTime(double unixTime)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds((long)unixTime).UtcDateTime; // Takes Unix time (seconds since 1970) and turns it into a DateTime
        }
        public (DateTime buyFirstDay, DateTime buyLastDay, DateTime sellFirstDay, DateTime sellLastDay) GetOptimalBuyAndSellDays(List<List<double>> prices)
        {
            if (prices == null || prices.Count < 2) // Throws an exception if prices are null or there are less than 2 price data points found
                throw new ArgumentException("Insufficient data");

            int minIndex = 0, buyLastDayIndex = 0, sellLastDayIndex = 0, sellFirstDayIndex = 0, buyFirstDayIndex = 0; // Stores indexes of best days to buy/sell
            double minPrice = prices[0][1]; // Initial best day to buy
            double maxPrice = prices[0][1]; // Initial best day to sell
            double maxProfit = 0; // Tracks max profit
            double maxLoss = 0; // Tracks max loss

            for (int i = 1; i < prices.Count; i++)
            {
                double currentPrice = prices[i][1];

                // Checks for best days to buy first then sell
                if (currentPrice - minPrice > maxProfit)
                {
                    maxProfit = currentPrice - minPrice;
                    buyFirstDayIndex = minIndex;
                    sellLastDayIndex = i;
                }

                // Update minimum price and index
                if (currentPrice < minPrice)
                {
                    minPrice = currentPrice;
                    minIndex = i;
                }

                // Checks for best days to sell first then buy back
                if (maxPrice - currentPrice > maxLoss && i > prices.FindIndex(p => p[1] == maxPrice))
                {
                    maxLoss = maxPrice - currentPrice;
                    sellFirstDayIndex = prices.FindIndex(p => p[1] == maxPrice);
                    buyLastDayIndex = i;
                }

                // Update the maximum price for selling
                if (currentPrice > maxPrice)
                {
                    maxPrice = currentPrice;
                }
            }

            DateTime buyFirstDay = UnixSecToDateTime(prices[buyFirstDayIndex][0]);
            DateTime buyLastDay = UnixSecToDateTime(prices[buyLastDayIndex][0]);
            DateTime sellFirstDay = UnixSecToDateTime(prices[sellFirstDayIndex][0]);
            DateTime sellLastDay = UnixSecToDateTime(prices[sellLastDayIndex][0]);

            return (buyFirstDay, buyLastDay, sellFirstDay, sellLastDay);
        }
        public (int bearishDays, int bullishDays) CalculateBearishAndBullishTrends(List<List<double>> prices)
        {
            int maxBearish = 0, maxBullish = 0;
            int currentBearish = 0, currentBullish = 0;

            for (int i = 1; i < prices.Count; i++)
            {
                double todayPrice = prices[i][1];
                double yesterdaysPrice = prices[i - 1][1]; // Yesterdays price is today-1

                if (todayPrice < yesterdaysPrice)
                {
                    // Continuing a bearish trend
                    currentBearish++;
                    maxBearish = Math.Max(maxBearish, currentBearish);

                    // Reset bullish counter
                    currentBullish = 0;
                }
                else if (todayPrice > yesterdaysPrice)
                {
                    // Continuing a bullish trend
                    currentBullish++;
                    maxBullish = Math.Max(maxBullish, currentBullish);

                    // Reset bearish counter
                    currentBearish = 0;
                }
                else
                {
                    // Prices are equal, don't reset counters
                }
            }

            return (maxBearish, maxBullish);
        }
    }
}
