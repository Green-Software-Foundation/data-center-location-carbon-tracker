using Newtonsoft.Json;
using System.Text;

namespace WattTime
{
    public class Region
    {

        //        {
        //    "ba": "CAISO_NORTH",
        //    "name": "California ISO Northern",
        //    "access": "True",
        //    "datatype": "MOER"
        //}

        [JsonProperty("ba")]
        public string RegionCode { get; set; }


        [JsonProperty("name")]
        public string RegionName { get; set; }


        [JsonProperty("access")]
        public bool Access { get; set; }


        [JsonProperty("datatype")]
        public string DataType { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var props = typeof(Region).GetProperties();
            foreach (var prop in props)
            {
                stringBuilder.Append($"{prop.Name}:{prop.GetValue(this)},");
            }

            return stringBuilder.ToString();
        }

    }

}
