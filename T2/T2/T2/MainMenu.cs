using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using T2.Classes;

namespace T2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void buttonFetchData_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = dtpStartDate.Value;
                DateTime end = dtpEndDate.Value;

                long startTimestamp = new DateTimeOffset(start).ToUnixTimeSeconds();
                long endTimestamp = new DateTimeOffset(end).ToUnixTimeSeconds();

                var apiHelper = new ApiHelper();
                var marketData = await apiHelper.FetchDataAsync(startTimestamp, endTimestamp);

                if (marketData.TotalVolumes == null || !marketData.TotalVolumes.Any())
                {
                    MessageBox.Show("Volume data is unavailable for the selected date range.");
                    return;
                }

                var minPrice = marketData.Prices.MinBy(p => p[1]);
                var maxPrice = marketData.Prices.MaxBy(p => p[1]);
                var minVolume = marketData.TotalVolumes.MinBy(v => v[1]);
                var maxVolume = marketData.TotalVolumes.MaxBy(v => v[1]);

                MessageBox.Show(
                    $"Lowest Price: {minPrice[1]} on {UnixToDateTime(minPrice[0])}\n" +
                    $"Highest Price: {maxPrice[1]} on {UnixToDateTime(maxPrice[0])}\n" +
                    $"Lowest Volume: {minVolume[1]} on {UnixToDateTime(minVolume[0])}\n" +
                    $"Highest Volume: {maxVolume[1]} on {UnixToDateTime(maxVolume[0])}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private DateTime UnixToDateTime(double unixTime)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds((long)unixTime).UtcDateTime;
        }

        private async void buttonPing_Click(object sender, EventArgs e)
        {
            var apiHelper = new ApiHelper();

            try
            {
                string response = await apiHelper.ApiPing();
                MessageBox.Show(response, "Ping Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
