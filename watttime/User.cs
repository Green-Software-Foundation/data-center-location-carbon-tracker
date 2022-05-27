using Newtonsoft.Json;

namespace WattTime
{
    public class User
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("org")]
        public string Organization { get; set; }

    }
}
