using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.app360ki_services.Models.Weather
{
    public class HgWeatherResults
    {
		[JsonProperty("temp")]
		public int temp { get; set; }
		[JsonProperty("date")]
		public string date { get; set; }
		[JsonProperty("time")]
		public string time { get; set; }
		[JsonProperty("condition_code")]
		public string condition_code { get; set; }
		[JsonProperty("description")]
		public string description { get; set; }
		[JsonProperty("currently")]
		public string currently { get; set; }
		[JsonProperty("cid")]
		public string cid { get; set; }
		[JsonProperty("city")]
		public string city { get; set; }
		[JsonProperty("img_id")]
		public string img_id { get; set; }
		[JsonProperty("humidity")]
		public int humidity { get; set; }
		[JsonProperty("wind_speedy")]
		public string wind_speedy { get; set; }
		[JsonProperty("sunrise")]
		public string sunrise { get; set; }
		[JsonProperty("sunset")]
		public string sunset { get; set; }
		[JsonProperty("condition_slug")]
		public string condition_slug { get; set; }
		[JsonProperty("city_name")]
		public string city_name { get; set; }
		[JsonProperty("forecast")]
		public IEnumerable<HgWeatherForecast> forecast { get; set; }
	}
}
