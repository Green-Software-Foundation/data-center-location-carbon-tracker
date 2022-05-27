using Newtonsoft.Json;

namespace WattTime
{
    public class Forecasting
    {
        [JsonProperty("generated_at")]
        public string GenerateTimestamp { get; set; }

        [JsonProperty("forecast")]
        public List<EmissionData> Forecast { get; set; }
    }
}
