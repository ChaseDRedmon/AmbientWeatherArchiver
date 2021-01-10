using System;

namespace Weathered.Data.Models.Core
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<UserDevice>(myJsonResponse);
    public class Info
    {
        /// <summary>
        /// The name of the weather station configured in the AmbientWeather dashboard
        /// </summary>
        public string? Name { get; set; } 

        /// <summary>
        /// City Location
        /// </summary>
        public string? Location { get; set; } 
    }

    public class LastData
    {
        /// <summary>
        /// Epoch time from 1/1/1970 (measured in milliseconds according to ambient weather docs)
        /// </summary>
        public long? EpochMilliseconds { get; set; } 

        /// <summary>
        /// DateTime version of <see cref="EpochMilliseconds"/>
        /// </summary>
        public DateTimeOffset? UtcDate { get; set; } 

        /// <summary>
        /// Wind Direction 
        /// </summary>
        public int? WindDirection { get; set; } 

        /// <summary>
        /// Wind Speed in Miles Per Hour
        /// </summary>
        public float? WindSpeedMph { get; set; } 

        /// <summary>
        /// Wind Gust in Miles Per Hour
        /// </summary>
        public float? WindGustMph { get; set; } 

        /// <summary>
        /// The maximum windspeed from a wind gust for that day
        /// </summary>
        public float? MaxDailyGust { get; set; } 

        /// <summary>
        /// The direction of the wind gust
        /// See <see cref="MaxDailyGust"/>>
        /// </summary>
        public int? WindGustDir { get; set; } 
        
        /// <summary>
        /// The average wind speed over a 2 minute period in miles per hour
        /// </summary>
        public float? WindSpeedMph2MinuteAverage { get; set; } 

        /// <summary>
        /// The average wind direction over a 2 minute period
        /// </summary>
        public int? WindDirection2MinuteAverage { get; set; }
        
        /// <summary>
        /// The average wind speed over a 10 minute period in miles per hour
        /// </summary>
        public float? WindSpeedMph10MinuteAverage { get; set; } 

        /// <summary>
        /// The average wind direction over a 10 minute period
        /// </summary>
        public int? WindDirection10MinuteAverage { get; set; } 

        /// <summary>
        /// Outdoor Temperature in Fahrenheit
        /// </summary>
        public float? OutdoorTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// The outdoor humidity
        /// </summary>
        public int? OutdoorHumidity { get; set; } 

        /// <summary>
        /// Relative Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        public float? RelativeBarometricPressure { get; set; } 

        /// <summary>
        /// Absolute Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        public float? AbsoluteBarometricPressure { get; set; } 

        /// <summary>
        /// Indoor Temperature in Fahrenheit
        /// </summary>
        public float? IndoorTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// Indoor Humidity
        /// </summary>
        public int? IndoorHumidity { get; set; } 

        /// <summary>
        /// Hourly Rainfall in Inches
        /// </summary>
        public int? HourlyRainfall { get; set; } 

        /// <summary>
        /// Daily Rainfall in Inches
        /// </summary>
        public int? DailyRainfall { get; set; } 

        /// <summary>
        /// Monthly rainfall in inches
        /// </summary>
        public int? MonthlyRainfall { get; set; } 

        /// <summary>
        /// Yearly rainfall in inches
        /// </summary>
        public int? YearlyRainfall { get; set; } 

        /// <summary>
        /// Feels Like Temperature
        /// if < 50ºF => Wind Chill,
        /// if > 68ºF => Heat Index (calculated on server)
        /// </summary>
        public float? OutdoorFeelsLikeTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// Dew Point Temperature in Fahrenheit
        /// </summary>
        public float? DewPointFahrenheit { get; set; } 
    }

    public class UserDevice
    {
        /// <summary>
        /// Weather Station Mac Address
        /// </summary>
        public string? MacAddress { get; set; } 

        /// <summary>
        /// Instance of <see cref="Info"/> class
        /// </summary>
        public Info Info { get; set; } 

        /// <summary>
        /// Instance of <see cref="LastData"/> class
        /// </summary>
        public LastData LastData { get; set; } 
    }
}