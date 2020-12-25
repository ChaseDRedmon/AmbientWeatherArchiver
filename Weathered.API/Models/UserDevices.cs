using System;
using System.Text.Json.Serialization;

namespace Weathered.API.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Info
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } 

        [JsonPropertyName("location")]
        public string Location { get; set; } 
    }

    public class LastData
    {
        [JsonPropertyName("dateutc")]
        public long EpochMilliseconds { get; set; } 

        [JsonPropertyName("date")]
        public DateTime Date { get; set; } 

        [JsonPropertyName("winddir")]
        public int WindDirection { get; set; } 

        [JsonPropertyName("windspeedmph")]
        public double WindSpeedMph { get; set; } 

        [JsonPropertyName("windgustmph")]
        public double WindGustMph { get; set; } 

        [JsonPropertyName("maxdailygust")]
        public double MaxDailyGust { get; set; } 

        [JsonPropertyName("windgustdir")]
        public int WindGustDir { get; set; } 
        
        [JsonPropertyName("windspdmph_avg2m")]
        public double WindSpeedMph2MinuteAverage { get; set; } 

        [JsonPropertyName("winddir_avg2m")]
        public int WindDirection2MinuteAverage { get; set; }
        
        [JsonPropertyName("windspdmph_avg10m")]
        public double WindSpeedMph10MinuteAverage { get; set; } 

        [JsonPropertyName("winddir_avg10m")]
        public int WindDirection10MinuteAverage { get; set; } 

        [JsonPropertyName("tempf")]
        public double OutdoorTemperatureFahrenheit { get; set; } 

        [JsonPropertyName("humidity")]
        public int OutdoorHumidity { get; set; } 

        [JsonPropertyName("baromrelin")]
        public double RelativeBarometricPressure { get; set; } 

        [JsonPropertyName("baromabsin")]
        public double AbsoluteBarometricPressure { get; set; } 

        [JsonPropertyName("tempinf")]
        public double IndoorTemperatureFahrenheit { get; set; } 

        [JsonPropertyName("humidityin")]
        public int IndoorHumidity { get; set; } 

        [JsonPropertyName("hourlyrainin")]
        public int HourlyRainfall { get; set; } 

        [JsonPropertyName("dailyrainin")]
        public int DailyRainfall { get; set; } 

        [JsonPropertyName("monthlyrainin")]
        public int MonthlyRainfall { get; set; } 

        [JsonPropertyName("yearlyrainin")]
        public int YearlyRainfall { get; set; } 

        [JsonPropertyName("feelsLike")]
        public double FeelsLike { get; set; } 

        [JsonPropertyName("dewPoint")]
        public double DewPoint { get; set; } 
    }

    public class UserDevice
    {
        [JsonPropertyName("macAddress")]
        public string MacAddress { get; set; } 

        [JsonPropertyName("info")]
        public Info Info { get; set; } 

        [JsonPropertyName("lastData")]
        public LastData LastData { get; set; } 
    }
}