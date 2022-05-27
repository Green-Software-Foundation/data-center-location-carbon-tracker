using Newtonsoft.Json;

namespace GeoJSONConverter
{
    public class AzureDataCenter
    {
        // {
        //  "displayName": "East US",
        //  "id": "/subscriptions/e12d1499-8efc-4d05-805e-33d94cc9b155/locations/eastus",
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
        //  "name": "eastus",
        //  "regionalDisplayName": "(US) East US",
        //  "subscriptionId": null
        //}
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("metadata")]
        public AzureDataCenterMetadata Metadata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("regionalDisplayName")]
        public string RegionalDisplayName { get; set; }

        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }


    }
}
