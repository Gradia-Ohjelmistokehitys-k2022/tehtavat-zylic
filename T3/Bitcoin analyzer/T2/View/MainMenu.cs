using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using T2.Classes;
using T2.Controller;

namespace T2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
        private DateTime UnixToDateTime(double unixTime)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds((long)unixTime).UtcDateTime;
        }
        public (int bearishDays, int bullishDays) CalculateBearBullTrends(List<List<double>> prices)
        {
            int maxBearish = 0, maxBullish = 0;
            int currentBearish = 0, currentBullish = 0;

            for (int i = 1; i < prices.Count; i++)
            {
                double todayPrice = prices[i][1];
                double yesterdaysPrice = prices[i - 1][1];

                if (todayPrice < yesterdaysPrice)
                {
                    currentBearish++;
                    maxBearish = Math.Max(maxBearish, currentBearish);
                    currentBullish = 0;
                }
                if (todayPrice > yesterdaysPrice)
                {
                    currentBullish++;
                    maxBullish = Math.Max(maxBullish, currentBullish);
                    currentBearish = 0;
                }
                else
                {
                    currentBullish = 0; currentBearish = 0;
                }
            }

            return (maxBearish, maxBullish);
        }
        private async void buttonFetchData_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = dtpStartDate.Value;
                DateTime end = dtpEndDate.Value;

                long startTimestamp = new DateTimeOffset(start).ToUnixTimeSeconds();
                long endTimestamp = new DateTimeOffset(end).ToUnixTimeSeconds();

                var btcService = new BitcoinService();
                var marketData = await btcService.FetchData(startTimestamp, endTimestamp);

                if (marketData.Prices == null || !marketData.Prices.Any())
                {
                    MessageBox.Show("Price data is unavailable for the selected date range");
                    return;
                }
                if (marketData.TotalVolumes == null || !marketData.TotalVolumes.Any())
                {
                    MessageBox.Show("Volume data is unavailable for the selected date range.");
                    return;
                }

                var (bearishDays, bullishDays) = CalculateBearBullTrends(marketData.Prices);

                var minPrice = marketData.Prices.MinBy(p => p[1]);
                var maxPrice = marketData.Prices.MaxBy(p => p[1]);
                var minVolume = marketData.TotalVolumes.MinBy(v => v[1]);
                var maxVolume = marketData.TotalVolumes.MaxBy(v => v[1]);

                var roundMinP = Math.Round(minPrice[1], 0);
                var roundMaxP = Math.Round(maxPrice[1], 0);
                var roundMinV = Math.Round(minVolume[1], 0);
                var roundMaxV = Math.Round(maxVolume[1], 0);

                MessageBox.Show(
                    $"Lowest Price: {roundMinP}€ on {UnixToDateTime(minPrice[0])}\n" +
                    $"Highest Price: {roundMaxP}€ on {UnixToDateTime(maxPrice[0])}\n" +
                    $"Lowest Volume: {roundMinV}€ on {UnixToDateTime(minVolume[0])}\n" +
                    $"Highest Volume: {roundMaxV}€ on {UnixToDateTime(maxVolume[0])}\n" +
                    $"Longest Bearish Trend: {bearishDays} days\n" +
                    $"Longest Bullish Trend: {bullishDays} days"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private async void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var btcService = new BitcoinService();

            try
            {
                string response = await btcService.TestApi();

                MessageBox.Show(response, "Ping Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
