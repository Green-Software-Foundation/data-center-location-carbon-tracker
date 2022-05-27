using Newtonsoft.Json;

namespace WattTime
{
    public class Token
    {
        [JsonProperty("token")]
        public string Key { get; set; }
    }
}
