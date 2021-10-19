using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.app360ki_services.Models.AirQuality
{

    public partial class AqicnData
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("aqi")]
        public long Aqi { get; set; }

        [JsonProperty("idx")]
        public long Idx { get; set; }

        [JsonProperty("attributions")]
        public IEnumerable<Attribution> Attributions { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("dominentpol")]
        public string Dominentpol { get; set; }

        [JsonProperty("iaqi")]
        public Iaqi Iaqi { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }

        [JsonProperty("debug")]
        public Debug Debug { get; set; }
    }

    public partial class Attribution
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo", NullValueHandling = NullValueHandling.Ignore)]
        public string Logo { get; set; }
    }

    public partial class City
    {
        [JsonProperty("geo")]
        public IEnumerable<double> Geo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Debug
    {
        [JsonProperty("sync")]
        public string Sync { get; set; }
    }

    public partial class Forecast
    {
        [JsonProperty("daily")]
        public Daily Daily { get; set; }
    }

    public partial class Daily
    {
        [JsonProperty("o3")]
        public IEnumerable<DailuyForecast> O3 { get; set; }

        [JsonProperty("pm10")]
        public IEnumerable<DailuyForecast> Pm10 { get; set; }

        [JsonProperty("pm25")]
        public IEnumerable<DailuyForecast> Pm25 { get; set; }

        [JsonProperty("uvi")]
        public IEnumerable<DailuyForecast> Uvi { get; set; }
    }

    public partial class DailuyForecast
    {
        [JsonProperty("avg")]
        public long Avg { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }

        [JsonProperty("min")]
        public long Min { get; set; }
    }

    public partial class ParticleValue
    {
        [JsonProperty("v")]
        public double V { get; set; }
    }

    public partial class Iaqi
    {
        [JsonProperty("co")]
        public ParticleValue Co { get; set; }

        [JsonProperty("h")]
        public ParticleValue H { get; set; }

        [JsonProperty("no2")]
        public ParticleValue No2 { get; set; }

        [JsonProperty("o3")]
        public ParticleValue O3 { get; set; }

        [JsonProperty("p")]
        public ParticleValue P { get; set; }

        [JsonProperty("pm10")]
        public ParticleValue Pm10 { get; set; }

        [JsonProperty("pm25")]
        public ParticleValue Pm25 { get; set; }

        [JsonProperty("t")]
        public ParticleValue T { get; set; }

        [JsonProperty("w")]
        public ParticleValue W { get; set; }

        [JsonProperty("wg")]
        public ParticleValue Wg { get; set; }
    }


    public partial class Time
    {
        [JsonProperty("s")]
        public string S { get; set; }

        [JsonProperty("tz")]
        public string Tz { get; set; }

        [JsonProperty("v")]
        public long V { get; set; }

        [JsonProperty("iso")]
        public string Iso { get; set; }
    }


}

