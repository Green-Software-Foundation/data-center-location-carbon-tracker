using Newtonsoft.Json;

namespace GeoJSONConverter
{
    public class AzurePairedRegion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }
    }
}
