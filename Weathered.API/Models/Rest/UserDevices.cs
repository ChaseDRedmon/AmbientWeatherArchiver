using System;
using Newtonsoft.Json;

namespace Weathered.API.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<UserDevice>(myJsonResponse);
    public class Info
    {
        /// <summary>
        /// The name of the weather station configured in the AmbientWeather dashboard
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; } 

        /// <summary>
        /// City Location
        /// </summary>
        [JsonProperty("location")]
        public string? Location { get; set; } 
    }

    public class LastData
    {
        /// <summary>
        /// Epoch time from 1/1/1970 (measured in milliseconds according to ambient weather docs)
        /// </summary>
        [JsonProperty("dateutc")]
        public long? EpochMilliseconds { get; set; } 
        
        /// <summary>
        /// DateTime version of <see cref="EpochMilliseconds"/>
        /// </summary>
        [JsonProperty("date")]
        public DateTimeOffset? UtcDate { get; set; } 

        /// <summary>
        /// Wind Direction 
        /// </summary>
        [JsonProperty("winddir")]
        public int? WindDirection { get; set; } 

        /// <summary>
        /// Wind Speed in Miles Per Hour
        /// </summary>
        [JsonProperty("windspeedmph")]
        public float? WindSpeedMph { get; set; } 

        /// <summary>
        /// Wind Gust in Miles Per Hour
        /// </summary>
        [JsonProperty("windgustmph")]
        public float? WindGustMph { get; set; } 

        /// <summary>
        /// The maximum windspeed from a wind gust for that day
        /// </summary>
        [JsonProperty("maxdailygust")]
        public float? MaxDailyGust { get; set; } 

        /// <summary>
        /// The direction of the wind gust
        /// See <see cref="MaxDailyGust"/>>
        /// </summary>
        [JsonProperty("windgustdir")]
        public int? WindGustDir { get; set; } 
        
        /// <summary>
        /// The average wind speed over a 2 minute period in miles per hour
        /// </summary>
        [JsonProperty("windspdmph_avg2m")]
        public float? WindSpeedMph2MinuteAverage { get; set; } 

        /// <summary>
        /// The average wind direction over a 2 minute period
        /// </summary>
        [JsonProperty("winddir_avg2m")]
        public int? WindDirection2MinuteAverage { get; set; }
        
        /// <summary>
        /// The average wind speed over a 10 minute period in miles per hour
        /// </summary>
        [JsonProperty("windspdmph_avg10m")]
        public float? WindSpeedMph10MinuteAverage { get; set; } 

        /// <summary>
        /// The average wind direction over a 10 minute period
        /// </summary>
        [JsonProperty("winddir_avg10m")]
        public int? WindDirection10MinuteAverage { get; set; } 

        /// <summary>
        /// Outdoor Temperature in Fahrenheit
        /// </summary>
        [JsonProperty("tempf")]
        public float? OutdoorTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// The outdoor humidity
        /// </summary>
        [JsonProperty("humidity")]
        public int? OutdoorHumidity { get; set; } 

        /// <summary>
        /// Relative Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        [JsonProperty("baromrelin")]
        public float? RelativeBarometricPressure { get; set; } 

        /// <summary>
        /// Absolute Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        [JsonProperty("baromabsin")]
        public float? AbsoluteBarometricPressure { get; set; } 

        /// <summary>
        /// Indoor Temperature in Fahrenheit
        /// </summary>
        [JsonProperty("tempinf")]
        public float? IndoorTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// Indoor Humidity
        /// </summary>
        [JsonProperty("humidityin")]
        public int? IndoorHumidity { get; set; } 

        /// <summary>
        /// Hourly Rainfall in Inches
        /// </summary>
        [JsonProperty("hourlyrainin")]
        public int? HourlyRainfall { get; set; } 

        /// <summary>
        /// Daily Rainfall in Inches
        /// </summary>
        [JsonProperty("dailyrainin")]
        public int? DailyRainfall { get; set; } 

        /// <summary>
        /// Monthly rainfall in inches
        /// </summary>
        [JsonProperty("monthlyrainin")]
        public int? MonthlyRainfall { get; set; } 

        /// <summary>
        /// Yearly rainfall in inches
        /// </summary>
        [JsonProperty("yearlyrainin")]
        public int? YearlyRainfall { get; set; } 

        /// <summary>
        /// Feels Like Temperature
        /// if < 50ºF => Wind Chill,
        /// if > 68ºF => Heat Index (calculated on server)
        /// </summary>
        [JsonProperty("feelsLike")]
        public float? OutdoorFeelsLikeTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// Dew Point Temperature in Fahrenheit
        /// </summary>
        [JsonProperty("dewPoint")]
        public float? DewPointFahrenheit { get; set; } 
    }

    public class UserDevice
    {
        /// <summary>
        /// Weather Station Mac Address
        /// </summary>
        [JsonProperty("macAddress")]
        public string? MacAddress { get; set; } 

        /// <summary>
        /// Instance of <see cref="Info"/> class
        /// </summary>
        [JsonProperty("info")]
        public Info Info { get; set; } 

        /// <summary>
        /// Instance of <see cref="LastData"/> class
        /// </summary>
        [JsonProperty("lastData")]
        public LastData LastData { get; set; } 
    }
}