using System;
using Newtonsoft.Json;

namespace Weathered.API.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Info
    {
        [JsonProperty("name")]
        public string? Name { get; set; } 

        [JsonProperty("location")]
        public string? Location { get; set; } 
    }

    public class LastData
    {
        [JsonProperty("dateutc")]
        public long? EpochMilliseconds { get; set; } 

        [JsonProperty("date")]
        public DateTimeOffset? UtcDate { get; set; } 

        [JsonProperty("winddir")]
        public int? WindDirection { get; set; } 

        [JsonProperty("windspeedmph")]
        public float? WindSpeedMph { get; set; } 

        [JsonProperty("windgustmph")]
        public float? WindGustMph { get; set; } 

        [JsonProperty("maxdailygust")]
        public float? MaxDailyGust { get; set; } 

        [JsonProperty("windgustdir")]
        public int? WindGustDir { get; set; } 
        
        [JsonProperty("windspdmph_avg2m")]
        public float? WindSpeedMph2MinuteAverage { get; set; } 

        [JsonProperty("winddir_avg2m")]
        public int? WindDirection2MinuteAverage { get; set; }
        
        [JsonProperty("windspdmph_avg10m")]
        public float? WindSpeedMph10MinuteAverage { get; set; } 

        [JsonProperty("winddir_avg10m")]
        public int? WindDirection10MinuteAverage { get; set; } 

        [JsonProperty("tempf")]
        public float? OutdoorTemperatureFahrenheit { get; set; } 

        [JsonProperty("humidity")]
        public int? OutdoorHumidity { get; set; } 

        [JsonProperty("baromrelin")]
        public float? RelativeBarometricPressure { get; set; } 

        [JsonProperty("baromabsin")]
        public float? AbsoluteBarometricPressure { get; set; } 

        [JsonProperty("tempinf")]
        public float? IndoorTemperatureFahrenheit { get; set; } 

        [JsonProperty("humidityin")]
        public int? IndoorHumidity { get; set; } 

        [JsonProperty("hourlyrainin")]
        public int? HourlyRainfall { get; set; } 

        [JsonProperty("dailyrainin")]
        public int? DailyRainfall { get; set; } 

        [JsonProperty("monthlyrainin")]
        public int? MonthlyRainfall { get; set; } 

        [JsonProperty("yearlyrainin")]
        public int? YearlyRainfall { get; set; } 

        [JsonProperty("feelsLike")]
        public float? OutdoorFeelsLikeTemperatureFahrenheit { get; set; } 

        [JsonProperty("dewPoint")]
        public float? DewPointFahrenheit { get; set; } 
    }

    public class UserDevice
    {
        [JsonProperty("macAddress")]
        public string? MacAddress { get; set; } 

        [JsonProperty("info")]
        public Info Info { get; set; } 

        [JsonProperty("lastData")]
        public LastData LastData { get; set; } 
    }
}