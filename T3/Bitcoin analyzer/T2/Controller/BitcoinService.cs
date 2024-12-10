using System.Threading.Tasks;
using T2.Classes;

namespace T2.Controller
{
    public class BitcoinService
    {
        private readonly ApiHelper apiHelper;

        public BitcoinService() // Acts as a controller between Model and View
        {
            apiHelper = new ApiHelper();
        }
        public async Task<string> TestApi()
        {
            string result = await apiHelper.ApiPing();
            return result;
        }

        public async Task<MarketData> FetchData(long startDate, long endDate)
        {
            return await apiHelper.FetchDataAsync(startDate, endDate);
        }

        public DateTime UnixToDateTime(double unixTime)
        {
            return apiHelper.UnixSecToDateTime(unixTime);
        }

        public (DateTime buyFirstDay, DateTime buyLastDay, DateTime sellFirstDay, DateTime sellLastDay) GetOptBuySellDays(List<List<double>> prices)
        {
            return apiHelper.GetOptimalBuyAndSellDays(prices);
        }

        public (int bearishDays, int bullishDays) CalculateBearBullTrends(List<List<double>> prices)
        {
            return apiHelper.CalculateBearishAndBullishTrends(prices);
        }
    }
}
