using Newtonsoft.Json;

namespace API.app360ki_services.Models.Weather
{
    public class HgWeatherForecast
    {
        [JsonProperty("date")]
		public string date { get; set; }
		[JsonProperty("weekday")]
		public string weekday { get; set; }
		[JsonProperty("max")]
		public int max { get; set; }
		[JsonProperty("min")]
		public int min { get; set; }
		[JsonProperty("description")]
		public string description { get; set; }
		[JsonProperty("condition")]
		public string condition { get; set; }
	}
}
