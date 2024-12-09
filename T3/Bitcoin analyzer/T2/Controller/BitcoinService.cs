using System.Threading.Tasks;
using T2.Classes;

namespace T2.Controller
{
    public class BitcoinService
    {
        private readonly ApiHelper apiHelper;

        public BitcoinService()
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
    }
}
