using Newtonsoft.Json;

namespace GeoJSONConverter
{
    public class AzureDataCenterMetadata
    {
        //  "metadata": {
        //    "geographyGroup": "US",
        //    "latitude": "37.3719",
        //    "longitude": "-79.8164",
        //    "pairedRegion": [
        //      {
        //        "id": "/subscriptions/e12d1499-8efc-4d05-805e-33d94cc9b155/locations/westus",
        //        "name": "westus",
        //        "subscriptionId": null
        //      }
        //    ],
        //    "physicalLocation": "Virginia",
        //    "regionCategory": "Recommended",
        //    "regionType": "Physical"
        //  },
        [JsonProperty("geographyGroup")]
        public string GeographyGroup { get; set; }

        [JsonProperty("latitude")]
        public float? Latitude { get; set; }

        [JsonProperty("longitude")]
        public float? Longitude { get; set; }

        [JsonProperty("pairedRegion")]
        public List<AzurePairedRegion> PairedRegion { get; set; }

        [JsonProperty("physicalLocation")]
        public string PhysicalLocation { get; set; }

        [JsonProperty("regionCategory")]
        public string RegionCategory { get; set; }

        [JsonProperty("regionType")]
        public string RegionType { get; set; }

    }
}
