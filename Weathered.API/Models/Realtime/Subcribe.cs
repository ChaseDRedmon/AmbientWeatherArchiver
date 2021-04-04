using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Weathered.API.Models.Realtime
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class LastData
    {
        // These fields below are fields that I have personally retrieved from my Ambient Weather Station (WS-2902A)

        /// <summary>
        /// Epoch time from 1/1/1970 (measured in milliseconds according to ambient weather docs)
        /// </summary>
        [JsonProperty("dateutc")]
        public long? EpochMilliseconds { get; set; }
        
        /// <summary>
        /// Indoor Temperature in Fahrenheit
        /// </summary>
        [JsonProperty("tempinf")]
        public double? IndoorTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// Indoor Humidity
        /// </summary>
        [JsonProperty("humidityin")]
        public int? IndoorHumidity { get; set; }
        
        /// <summary>
        /// Relative Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        [JsonProperty("baromrelin")]
        public double? RelativeBarometricPressure { get; set; }
        
        /// <summary>
        /// Absolute Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        [JsonProperty("baromabsin")]
        public double? AbsoluteBarometricPressure { get; set; }
        
        /// <summary>
        /// Outdoor Temperature in Fahrenheit
        /// </summary>
        [JsonProperty("tempf")]
        public double? OutdoorTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// A battery indicator 
        /// A value of 1 represents an 'OK' battery level
        /// A value of 0 represents a 'low' battery level
        /// 
        /// For Meteobridge Users: the above value are flipped. See below.
        /// A value of 0 represents an 'OK' battery level
        /// A value of 1 represents a 'low' battery level
        /// </summary>
        [JsonProperty("battout")]
        public int? BatteryLowIndicator { get; set; }
        
        /// <summary>
        /// The outdoor humidity
        /// </summary>
        [JsonProperty("humidity")]
        public int? OutdoorHumidity { get; set; }
        
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
        /// Hourly Rainfall in Inches
        /// </summary>
        [JsonProperty("hourlyrainin")]
        public double? HourlyRainfall { get; set; }
        
        /// <summary>
        /// Current event's rainfall in inches
        /// </summary>
        [JsonProperty("eventrainin")]
        public double? EventRainfall { get; set; }
        
        /// <summary>
        /// Daily Rainfall in Inches
        /// </summary>
        [JsonProperty("dailyrainin")]
        public double? DailyRainfall { get; set; }
        
        /// <summary>
        /// Weekly rainfall in inches
        /// </summary>
        [JsonProperty("weeklyrainin")]
        public double? WeeklyRainfall { get; set; }
        
        /// <summary>
        /// Monthly rainfall in inches
        /// </summary>
        [JsonProperty("monthlyrainin")]
        public double? MonthlyRainfall { get; set; }
        
        /// <summary>
        /// Total rainfall recorded by sensor in inches
        /// </summary>
        [JsonProperty("totalrainin")]
        public double? TotalRainfall { get; set; }
        
        /// <summary>
        /// Solar Radiation measured in Watts Per Meter^2 (W/m^2)
        /// </summary>
        [JsonProperty("solarradiation")]
        public double? SolarRadiation { get; set; }
        
        /// <summary>
        /// Ultra-violet radiation index
        /// </summary>
        [JsonProperty("uv")]
        public int? UltravioletRadiationIndex { get; set; }
        
        /// <summary>
        /// Feels Like Temperature
        /// if < 50ºF => Wind Chill,
        /// if > 68ºF => Heat Index (calculated on server)
        /// </summary>
        [JsonProperty("feelsLike")]
        public double? OutdoorFeelsLikeTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// Dew Point Temperature in Fahrenheit
        /// </summary>
        [JsonProperty("dewPoint")]
        public double? DewPointFahrenheit { get; set; }
        
        /// <summary>
        /// Indoor Feels Like Temperature in Fahrenheit
        /// </summary>
        [JsonProperty("feelsLikein")]
        public double? IndoorFeelsLikeTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// Indoor Dew Point Temperature in Fahrenheit
        /// </summary>
        [JsonProperty("dewPointin")]
        public double? IndoorDewPointTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// Last Date recorded where <see cref="HourlyRainfall"/> > 0 inches
        /// </summary>
        [JsonProperty("lastRain")]
        public DateTimeOffset? LastRain { get; set; }
        
        /// <summary>
        /// I have no idea. ¯\_(ツ)_/¯
        /// </summary>
        [JsonProperty("deviceId")]
        public string? deviceId { get; set; }
        
        /// <summary>
        /// IANA TimeZone
        /// </summary>
        [JsonProperty("tz")]
        public string? IANATimeZone { get; set; }
        
        /// <summary>
        /// DateTime version of <see cref="EpochMilliseconds"/>
        /// </summary>
        [JsonProperty("date")]
        public DateTimeOffset? UtcDate { get; set; }
    }

    public class Coords2
    {
        /// <summary>
        /// Latitude of the weather station
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        
        /// <summary>
        /// Longitude of the weather station
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }

    public class Coords
    {
        public Coords2 Coord2 { get; set; }
        
        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        
        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }
        
        /// <summary>
        /// Elevation above sea-level in meters
        /// </summary>
        [JsonProperty("elevation")]
        public double Elevation { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Geo geo { get; set; }
    }

    public class Info
    {
        /// <summary>
        /// The Nickname of the Weather Station
        /// </summary>
        public string name { get; set; }
        public Coords coords { get; set; }
    }

    public class Geo
    {
        /// <summary>
        /// The Type of Geo Coordinates. i.e. "Point"
        /// </summary>
        public string type { get; set; }
        
        /// <summary>
        /// A list of doubles containing the lat/lon coordinates
        /// coordinates[0] is longitude
        /// coordinates[1] is latitude
        /// </summary>
        public List<double> coordinates { get; set; }
    }

    public class Device
    {
        /// <summary>
        /// Weather Station Mac Address
        /// </summary>
        [JsonProperty("macAddress")]
        public string? MacAddress { get; set; }
        
        /// <summary>
        /// The Last Data that was received from the weather station
        /// </summary>
        public LastData lastData { get; set; }
        public Info info { get; set; }
        
        /// <summary>
        /// The API Key used for the subcribe command
        /// </summary>
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// List of devices belonging to the user
        /// </summary>
        public List<Device> devices { get; set; }
        
        /// <summary>
        /// The returned event type
        /// </summary>
        public string method { get; set; }
    }
}