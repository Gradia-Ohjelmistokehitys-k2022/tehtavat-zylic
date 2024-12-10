using System.Net.Http;
using System.Windows.Forms.DataVisualization.Charting;
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
            chart1.Series.Clear(); // Clear the chart on app start up
        }
        private async void buttonFetchData_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = dtpStartDate.Value;
                DateTime end = dtpEndDate.Value;

                // Convert date to unix time
                long startTimestamp = new DateTimeOffset(start).ToUnixTimeSeconds();
                long endTimestamp = new DateTimeOffset(end).ToUnixTimeSeconds();

                var btcService = new BitcoinService();
                var marketData = await btcService.FetchData(startTimestamp, endTimestamp); // Fetches bitcoin data between 2 timestamps

                // If prices arent found, return with a message box giving an error
                if (marketData.Prices == null || !marketData.Prices.Any())
                {
                    MessageBox.Show("Price data is unavailable for the selected date range");
                    return;
                }
                // If volumes arent found, return with a message box giving an error
                if (marketData.TotalVolumes == null || !marketData.TotalVolumes.Any())
                {
                    MessageBox.Show("Volume data is unavailable for the selected date range.");
                    return;
                }

                // Variables for getting Bearish and Bullish trends and optimal Buy/Sell days
                var (bearishDays, bullishDays) = btcService.CalculateBearBullTrends(marketData.Prices);
                var (buyFirstDay, buyLastDay, sellFirstDay, sellLastDay) = btcService.GetOptBuySellDays(marketData.Prices);

                // Taking min and max from price and volume
                var minPrice = marketData.Prices.MinBy(p => p[1]);
                var maxPrice = marketData.Prices.MaxBy(p => p[1]);
                var minVolume = marketData.TotalVolumes.MinBy(v => v[1]);
                var maxVolume = marketData.TotalVolumes.MaxBy(v => v[1]);

                // Rounding up prices and volumes
                var roundMinP = Math.Round(minPrice[1], 0);
                var roundMaxP = Math.Round(maxPrice[1], 0);
                var roundMinV = Math.Round(minVolume[1], 0);
                var roundMaxV = Math.Round(maxVolume[1], 0);

                // Updating labels
                labelPLowest.Text = $"Lowest: {roundMinP}€ on {btcService.UnixToDateTime(minPrice[0])}";
                labelPHighest.Text = $"Highest: {roundMaxP}€ on {btcService.UnixToDateTime(maxPrice[0])}";
                labelVLowest.Text = $"Lowest: {roundMinV}€ on {btcService.UnixToDateTime(minVolume[0])}";
                labelVHighest.Text = $"Highest: {roundMaxV}€ on {btcService.UnixToDateTime(maxVolume[0])}";
                labelBearish.Text = $"Longest Bearish Trend: {bearishDays} days";
                labelBullish.Text = $"Longest Bullish Trend: {bullishDays} days";
                labelBTS.Text = $"Buy on {buyFirstDay.ToShortDateString()} first, Sell on {sellLastDay.ToShortDateString()}";
                labelSTB.Text = $"Sell on {sellFirstDay.ToShortDateString()} first, Buy on {buyLastDay.ToShortDateString()}";

                InitializeChart(marketData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void InitializeChart(MarketData marketData)
        {
            chart1.Series.Clear(); // Clear any previous data from the chart
            double? previousPrice = null; // Variable for tracking changing colors from black and red
            var dailyPrices = new Dictionary<DateTime, double>(); // Dictionary to track the price at the end of each day

            // Create a new series for the line chart
            Series priceSeries = new Series
            {
                Name = "Bitcoin Price",
                Color = Color.Black,
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Line,
                BorderWidth = 5
            };

            foreach (var price in marketData.Prices)
            {
                // Convert Unix timestamp from milliseconds to DateTime
                DateTime date = DateTimeOffset.FromUnixTimeMilliseconds((long)price[0]).DateTime;

                DateTime dateOnly = date.Date;

                dailyPrices[dateOnly] = price[1]; // Update the price for the current day
            }

            // Add the data points for the last price of each day to the series
            foreach (var entry in dailyPrices.OrderBy(e => e.Key))
            {
                DateTime date = entry.Key;
                double price = entry.Value;

                priceSeries.Points.AddXY(date, price);

                // Change colors of the line depending on if price is going up/down
                if (previousPrice.HasValue)
                {
                    if (price > previousPrice.Value)
                        priceSeries.Points[priceSeries.Points.Count - 1].Color = Color.Black;  // Up (black)
                    else
                        priceSeries.Points[priceSeries.Points.Count - 1].Color = Color.Red;    // Down (red)
                }

                previousPrice = price;
            }

            // Add the series to the chart
            chart1.Series.Add(priceSeries);
        }
        private async void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var btcService = new BitcoinService();

            try
            {
                string response = await btcService.TestApi();

                MessageBox.Show(response, "Ping Response", MessageBoxButtons.OK, MessageBoxIcon.Information); // Shows API Ping information from ApiHelper.cs on a messagebox 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Catch an error if there is one
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Closes the app
        }
    }
}