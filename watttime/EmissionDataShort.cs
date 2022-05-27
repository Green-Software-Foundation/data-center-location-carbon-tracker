using Newtonsoft.Json;
using System.Text;

namespace WattTime
{
//    {
//    "freq": "300",   
//    "ba": "CAISO_NORTH",
//    "percent": "53",
//    "moer": "850.743982",
//    "point_time": "2019-01-29T14:55:00.00Z"
//}
    public class EmissionDataShort
    {
        [JsonProperty("frequency")]
        public int Frequency { get; set; }

        [JsonProperty("ba")]
        public string Region { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }

        [JsonProperty("moer")]
        public double MOER { get; set; }

        [JsonProperty("point_time")]
        public string Time { get; set; }


        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var props = typeof(EmissionDataShort).GetProperties();
            foreach (var prop in props)
            {
                stringBuilder.Append($"{prop.Name}:{prop.GetValue(this)},");
            }

            return stringBuilder.ToString();
        }

        public string CSVString()
        {
            return $"{Region},{MOER}";
        }

    }
}
