// Root myDeserializedClass = JsonSerializer.Deserialize<Device>(myJsonResponse);

using System;

namespace Weathered.Data.Models.Core
{
    public class Device
    {
        // These fields below are fields that I have personally retrieved from my Ambient Weather Station (WS-2902A)
        
        /// <summary>
        /// Epoch time from 1/1/1970 (measured in milliseconds according to ambient weather docs)
        /// </summary>
        public long? EpochMilliseconds { get; set; }
        
        /// <summary>
        /// Indoor Temperature in Fahrenheit
        /// </summary>
        public double? IndoorTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// Indoor Humidity
        /// </summary>
        public int? IndoorHumidity { get; set; }
        
        /// <summary>
        /// Relative Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        public double? RelativeBarometricPressure { get; set; } 
        
        /// <summary>
        /// Absolute Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        public double? AbsoluteBarometricPressure { get; set; } 
        
        /// <summary>
        /// Outdoor Temperature in Fahrenheit
        /// </summary>
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
        public int? BatteryLowIndicator { get; set; }
        
        /// <summary>
        /// The outdoor humidity
        /// </summary>
        public int? OutdoorHumidity { get; set; }

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
        /// Hourly Rainfall in Inches
        /// </summary>
        public double? HourlyRainfall { get; set; } 
        
        /// <summary>
        /// Current event's rainfall in inches
        /// </summary>
        public double? EventRainfall { get; set; } 
        
        /// <summary>
        /// Daily Rainfall in Inches
        /// </summary>
        public double? DailyRainfall { get; set; }
        
        /// <summary>
        /// Weekly rainfall in inches
        /// </summary>
        public double? WeeklyRainfall { get; set; }
        
        /// <summary>
        /// Monthly rainfall in inches
        /// </summary>
        public double? MonthlyRainfall { get; set; } 
        
        /// <summary>
        /// Total rainfall recorded by sensor in inches
        /// </summary>
        public double? TotalRainfall { get; set; }
        
        /// <summary>
        /// Solar Radiation measured in Watts Per Meter^2 (W/m^2)
        /// </summary>
        public double? SolarRadiation { get; set; }
        
        /// <summary>
        /// Ultra-violet radiation index
        /// </summary>
        public int? UltravioletRadiationIndex { get; set; } 
        
        /// <summary>
        /// Feels Like Temperature
        /// if < 50ºF => Wind Chill,
        /// if > 68ºF => Heat Index (calculated on server)
        /// </summary>
        public double? OutdoorFeelsLikeTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// Dew Point Temperature in Fahrenheit
        /// </summary>
        public double? DewPointFahrenheit { get; set; } 
        
        /// <summary>
        /// Indoor Feels Like Temperature in Fahrenheit
        /// </summary>
        public double? IndoorFeelsLikeTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// Indoor Dew Point Temperature in Fahrenheit
        /// </summary>
        public double? IndoorDewPointTemperatureFahrenheit { get; set; }
        
        /// <summary>
        /// Last Date recorded where <see cref="HourlyRainfall"/> > 0 inches
        /// </summary>
        public DateTimeOffset LastRain { get; set; } 
        
        /// <summary>
        /// Unknown value? Probably something to do with Ambient Weathers Databases/Servers?
        /// </summary>
        public string? Loc { get; set; } 
        
        /// <summary>
        /// DateTime version of <see cref="EpochMilliseconds"/>
        /// </summary>
        public DateTimeOffset? UtcDate { get; set; } 
        
        // Fields Below Here are not returned by my WS-2902A Weather Station.
        // These fields attempt to follow the specification as closely as possible

        /// <summary>
        /// The direction of the wind gust
        /// See <see cref="MaxDailyGust"/>>
        /// </summary>
        public float? WindGustDir { get; set; } 
    
        /// <summary>
        /// The average wind speed over a 2 minute period in miles per hour
        /// </summary>
        public double? WindSpeedMph2MinuteAverage { get; set; }
    
        /// <summary>
        /// The average wind direction over a 2 minute period
        /// </summary>
        public int? WindDirection2MinuteAverage { get; set; }
    
        /// <summary>
        /// The average wind speed over a 10 minute period in miles per hour
        /// </summary>
        public double? WindSpeedMph10MinuteAverage { get; set; }
    
        /// <summary>
        /// The average wind direction over a 10 minute period
        /// </summary>
        public int? WindDirection10MinuteAverage { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 1
        /// </summary>
        public double? OutdoorHumiditySensor1 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 2
        /// </summary>
        public double? OutdoorHumiditySensor2 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 3
        /// </summary>
        public double? OutdoorHumiditySensor3 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 4
        /// </summary>
        public double? OutdoorHumiditySensor4 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 5
        /// </summary>
        public double? OutdoorHumiditySensor5 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 6
        /// </summary>
        public double? OutdoorHumiditySensor6 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 7
        /// </summary>
        public double? OutdoorHumiditySensor7 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 8
        /// </summary>
        public double? OutdoorHumiditySensor8 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 9
        /// </summary>
        public double? OutdoorHumiditySensor9 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 10
        /// </summary>
        public double? OutdoorHumiditySensor10 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 1 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor1 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 2 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor2 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 3 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor3 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 4 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor4 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 5 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor5 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 6 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor6 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 7 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor7 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 8 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor8 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 9 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor9 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 10 in Fahrenheit
        /// </summary>
        public double? OutdoorTemperatureSensor10 { get; set; }
    
        /// <summary>
        /// Soil Temperature Sensor 1 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor1 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 2 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor2 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 3 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor3 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 4 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor4 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 5 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor5 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 6 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor6 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 7 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor7 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 8 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor8 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 9 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor9 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 10 in Fahrenheit
        /// </summary>
        public double? SoilTemperatureSensor10 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 1
        /// </summary>
        public double? SoilHumiditySensor1 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 2
        /// </summary>
        public double? SoilHumiditySensor2 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 3
        /// </summary>
        public double? SoilHumiditySensor3 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 4
        /// </summary>
        public double? SoilHumiditySensor4 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 5
        /// </summary>
        public double? SoilHumiditySensor5 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 6
        /// </summary>
        public double? SoilHumiditySensor6 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 7
        /// </summary>
        public double? SoilHumiditySensor7 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 8
        /// </summary>
        public double? SoilHumiditySensor8 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 9
        /// </summary>
        public double? SoilHumiditySensor9 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 10
        /// </summary>
        public double? SoilHumiditySensor10 { get; set; }
    
        /// <summary>
        /// A battery indicator for sensor 1
        /// A value of 1 represents an 'OK' battery level
        /// A value of 0 represents a 'low' battery level
        /// 
        /// For Meteobridge Users: the above value are flipped. See below.
        /// A value of 0 represents an 'OK' battery level
        /// A value of 1 represents a 'low' battery level
        /// </summary>
        public int? BatteryLowIndicator1 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 2
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator2 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 3
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator3 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 4
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator4 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 5
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator5 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 6
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator6 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 7
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator7 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 8
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator8 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 9
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator9 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 10
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? BatteryLowIndicator10 { get; set; }
    
        /// <summary>
        /// A battery indicator for the PM 2.5 Air Quality Sensor
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        public int? PM25AirQualityBatteryLowIndicator { get; set; }
    
        /// <summary>
        /// Previous 24 hour rainfall in inches
        /// </summary>
        public double? Previous24HourRainfall { get; set; }
    
        /// <summary>
        /// Yearly rainfall in inches
        /// </summary>
        public double? YearlyRainfall { get; set; } 
    
        /// <summary>
        /// Carbon Dioxide measured in Parts Per Million
        /// </summary>
        public double? CO2PPM { get; set; } 
    
        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay1 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay2 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay3 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay4 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay5 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay6 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay7 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay8 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay9 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        public int? Relay10 { get; set; }
        
        /// <summary>
        /// Latest Outdoor PM 2.5 Air Quality
        /// Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>
        public double? PM25OutdoorAirQuality { get; set; }
        
        /// <summary>
        /// Outdoor PM 2.5 Air Quality, 24 hour average.
        /// Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>
        public double? PM25OutdoorAirQuality24HourAverage { get; set; }
        
        /// <summary>
        /// Latest Indoor PM 2.5 Air Quality
        /// Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>
        public double? PM25IndoorAirQuality { get; set; }
        
        /// <summary>
        /// Indoor PM 2.5 Air Quality, 24 hour average.
        /// Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>
        public double? PM25IndoorAirQuality24HourAverage { get; set; }
        
        /// <summary>
        /// IANA TimeZone
        /// </summary>
        public string? IANATimeZone { get; set; }
        
        /// <summary>
        /// Feels Like Temperature Sensor 1
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int?OutdoorFeelsLikeTemperatureFahrenheit1 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 2
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit2 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 3
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit3 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 4
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit4 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 5
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit5 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 6
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit6 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 7
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit7 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 8
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit8 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 9
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit9 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 10
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        public int? OutdoorFeelsLikeTemperatureFahrenheit10 { get; set; }
        
        /// <summary>
        /// Dew Point Temperature for Sensor 1
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit1 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 2
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit2 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 3
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit3 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 4
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit4 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 5
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit5 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 6
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit6 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 7
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit7 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 8
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit8 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 9
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit9 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 10
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        public double? DewPointFahrenheit10 { get; set; }
    }
}

