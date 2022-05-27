using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;

namespace GeoJSONConverter
{
    public static class AzureDataCenterConverter
    {
        public static ICollection<AzureDataCenter> ConvertToDataCenters(string azureDataCenterText)
        {
            return JsonConvert.DeserializeObject<List<AzureDataCenter>>(azureDataCenterText); 
        }

        public static string ConvertToGeoJson(string azureDataCenterText)
        {
            var azureDataCenters = ConvertToDataCenters(azureDataCenterText);

            FeatureCollection featureCollection = new FeatureCollection();
            foreach(var azureDataCenter in azureDataCenters)
            {
                if (azureDataCenter.Metadata.Latitude == null || azureDataCenter.Metadata.Longitude == null)
                    continue;

                var geometry = new Point(new Position(azureDataCenter.Metadata.Latitude.Value, azureDataCenter.Metadata.Longitude.Value));
                var properties = new Dictionary<string, object>();
                properties["Data Center"] = "Azure";
                properties["Name"] = azureDataCenter.DisplayName;
                properties["location"] = azureDataCenter.Metadata.PhysicalLocation;
                properties["latitude"] = azureDataCenter.Metadata.Latitude;
                properties["longitude"] = azureDataCenter.Metadata.Longitude;
                var feature = new Feature(geometry, properties);
                featureCollection.Features.Add(feature);
            }

            return JsonConvert.SerializeObject(featureCollection);
        }
    }
}
