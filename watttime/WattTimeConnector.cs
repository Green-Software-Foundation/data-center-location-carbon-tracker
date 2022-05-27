
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace WattTime
{
    public class WattTimeConnector
    {
        private const string s_Url = @"https://api2.watttime.org/v2";

        private HttpClient _client;
        public WattTimeConnector()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(s_Url);
        }

       
        public async Task<string> Register(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(s_Url + "/register", data);
            return response.Content.ReadAsStringAsync().Result;
        }

       
        public async Task<string> Login(string username, string password)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{username}:{password}")));

            var result = await _client.GetAsync(s_Url + "/login");
            return result.Content.ReadAsStringAsync().Result;
        }

        public async Task<EmissionDataShort> GetRealTimeData(string token, Region region)
        {
            var tokenObj = JsonConvert.DeserializeObject<Token>(token);
            if (tokenObj == null)
                return new EmissionDataShort();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenObj.Key);
            var url = new UriBuilder(s_Url + "/index");
            url.Query = $"ba={region.RegionCode}";

            var result = await _client.GetAsync(url.ToString());

            return JsonConvert.DeserializeObject<EmissionDataShort>(result.Content.ReadAsStringAsync().Result);

        }

        public async Task<List<EmissionData>> GetEmissionData(string token, string ba, string start, string end)
        {
            var tokenObj = JsonConvert.DeserializeObject<Token>(token);
            if (tokenObj == null)
                return new List<EmissionData>();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenObj.Key);
            var url = new UriBuilder(s_Url + "/data");
            url.Query = $"ba={ba}&starttime={start}&endtime={end}"; 

            var result = await _client.GetAsync(url.ToString());

            return JsonConvert.DeserializeObject<List<EmissionData>>(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<Forecasting> GetForecastData(string token, string ba)
        {
            var tokenObj = JsonConvert.DeserializeObject<Token>(token);
            if (tokenObj == null)
                return new Forecasting();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenObj.Key);
            var url = new UriBuilder(s_Url + "/forecast");
            url.Query = $"ba={ba}";

            var result = await _client.GetAsync(url.ToString());

            return JsonConvert.DeserializeObject<Forecasting>(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<Stream?> GetHistoryData(string token, string ba)
        {
            var tokenObj = JsonConvert.DeserializeObject<Token>(token);
            if (tokenObj == null)
                return null;

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenObj.Key);
            var url = new UriBuilder(s_Url + "/historical");
            url.Query = $"ba={ba}";

            var result = await _client.GetAsync(url.ToString());
            return result.Content.ReadAsStreamAsync().Result;
        }

        public async Task<Stream?> GetMap(string token)
        {
            var tokenObj = JsonConvert.DeserializeObject<Token>(token);
            if (tokenObj == null)
                return null;

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenObj.Key);
            var url = new UriBuilder(s_Url + "/maps");
            var result = await _client.GetAsync(url.ToString());
            return result.Content.ReadAsStreamAsync().Result;
        }

        public async Task<List<Region>> GetRegions(string token)
        {
            var tokenObj = JsonConvert.DeserializeObject<Token>(token);
            if (tokenObj == null)
                return null;

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenObj.Key);
            var url = new UriBuilder(s_Url + "/ba-access");
            var result = await _client.GetAsync(url.ToString());
           
            return JsonConvert.DeserializeObject<List<Region>>(result.Content.ReadAsStringAsync().Result);
        }
    }
}