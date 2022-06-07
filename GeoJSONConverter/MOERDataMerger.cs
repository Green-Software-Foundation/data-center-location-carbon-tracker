using GeoJSON.Net.Feature;
using Newtonsoft.Json;

namespace GeoJSONConverter
{
    public static class MOERDataMerger
    {
        public static string Merge(string gridMapGeojsonText, Dictionary<string, double> moerData)
        {
            var gridFeatureCollection = JsonConvert.DeserializeObject<FeatureCollection>(gridMapGeojsonText);
            foreach (var feature in gridFeatureCollection.Features)
            {
                if (feature.Properties["abbrev"] is string regionCode && moerData.ContainsKey(regionCode))
                {
                    feature.Properties["MOER"] = moerData[regionCode];
                }
            }

            return JsonConvert.SerializeObject(gridFeatureCollection);
        }
    }
}
