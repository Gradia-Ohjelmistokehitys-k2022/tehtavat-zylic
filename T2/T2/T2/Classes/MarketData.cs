using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace T2.Classes
{
    public class MarketData
    {
        [JsonProperty("prices")]
        public List<List<double>> Prices { get; set; }
        [JsonProperty("total_volumes")]
        public List<List<double>> TotalVolumes { get; set; }
    }
}
