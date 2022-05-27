using Newtonsoft.Json;
using System.Text;

namespace WattTime
{
    //"point_time": "2021-03-01T00:45:00.000Z", 
    //"value": 941.0, 
    //"frequency": 300, 
    //"market": "RTM", 
    //"ba": "CAISO_NORTH", 
    //"datatype": "MOER", 
    //"version": "3.0"
    public class EmissionData
    {
        [JsonProperty("point_time")]
        public string Time { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }

        [JsonProperty("frequency")]
        public int Frequency {  get; set; }  
        
        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("ba")]
        public string Region { get; set; }

        [JsonProperty("datatype")]
        public string DataType { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var props = typeof(EmissionData).GetProperties();
            foreach (var prop in props)
            {
                stringBuilder.Append($"{prop.Name}:{prop.GetValue(this)},");
            }

            return stringBuilder.ToString();
        }
    }
}
