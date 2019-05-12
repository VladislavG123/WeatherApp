using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Night
    {
        public string Condition { get; set; }
        [JsonProperty("temp_min")]
        public int TempMin { get; set; }
        [JsonProperty("temp_max")]
        public int TempMax { get; set; }
        [JsonProperty("temp_avg")]
        public int TempAvg { get; set; }
        [JsonProperty("feels_like")]
        public int FeelsLike { get; set; }
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDirrection { get; set; }
        public double Cloudness { get; set; }
    }

    public class Morning
    {
        public string Condition { get; set; }
        [JsonProperty("temp_min")]
        public int TempMin { get; set; }
        [JsonProperty("temp_max")]
        public int TempMax { get; set; }
        [JsonProperty("temp_avg")]
        public int TempAvg { get; set; }
        [JsonProperty("feels_like")]
        public int FeelsLike { get; set; }
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDirrection { get; set; }
        public double Cloudness { get; set; }
    }

    public class Day
    {
        public string Condition { get; set; }
        [JsonProperty("temp_min")]
        public int TempMin { get; set; }
        [JsonProperty("temp_max")]
        public int TempMax { get; set; }
        [JsonProperty("temp_avg")]
        public int TempAvg { get; set; }
        [JsonProperty("feels_like")]
        public int FeelsLike { get; set; }
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDirrection { get; set; }
        public double Cloudness { get; set; }
    }

    public class Evening
    {
        public string Condition { get; set; }
        [JsonProperty("temp_min")]
        public int TempMin { get; set; }
        [JsonProperty("temp_max")]
        public int TempMax { get; set; }
        [JsonProperty("temp_avg")]
        public int TempAvg { get; set; }
        [JsonProperty("feels_like")]
        public int FeelsLike { get; set; }
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDirrection { get; set; }
        public double Cloudness { get; set; }
    }
    
    public class Parts
    {
        public Night Night { get; set; }
        public Morning Morning { get; set; }
        public Day Day { get; set; }
        public Evening Evening { get; set; }
    }

    public class Forecast
    {
        public string Date { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        [JsonProperty("moon_text")]
        public string Moon { get; set; }
        public Parts Parts { get; set; }
    }

    public class Weather
    {
        [JsonProperty("now_dt")]
        public DateTime Date { get; set; }
        public List<Forecast> Forecasts { get; set; }
    }
}
