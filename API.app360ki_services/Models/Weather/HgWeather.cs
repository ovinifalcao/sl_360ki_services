using Newtonsoft.Json;

namespace API.app360ki_services.Models.Weather
{
    public class HgWeather
    {
        [JsonProperty("by")]
        public string by { get; set; }
        [JsonProperty("valid_key")]
        public bool valid_key { get; set; }
        [JsonProperty("results")]
        public HgWeatherResults results { get; set; }
        [JsonProperty("execution_time")]
        public float execution_time { get; set; }
        [JsonProperty("from_cache")]
        public bool from_cache { get; set; }
    }
}
