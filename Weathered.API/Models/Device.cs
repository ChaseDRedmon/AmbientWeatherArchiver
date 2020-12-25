﻿// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

using System;
using System.Text.Json.Serialization;

namespace Weathered.API.Models
{
    public class Device
    {
        /// <summary>
        /// Wind Direction 
        /// </summary>
        [JsonPropertyName("winddir")]
        public int WindDirection { get; set; } 

        /// <summary>
        /// Wind Speed in Miles Per Hour
        /// </summary>
        [JsonPropertyName("windspeedmph")]
        public double WindSpeedMph { get; set; } 

        /// <summary>
        /// Wind Gust in Miles Per Hour
        /// </summary>
        [JsonPropertyName("windgustmph")]
        public double WindGustMph { get; set; } 

        /// <summary>
        /// The maximum windspeed from a wind gust for that day
        /// </summary>
        [JsonPropertyName("maxdailygust")]
        public double MaxDailyGust { get; set; }
    
        /// <summary>
        /// The direction of the wind gust
        /// See <see cref="MaxDailyGust"/>>
        /// </summary>
        [JsonPropertyName("windgustdir")]
        public double WindGustDir { get; set; } 
    
        /// <summary>
        /// The average wind speed over a 2 minute period in miles per hour
        /// </summary>
        [JsonPropertyName("windspdmph_avg2m")]
        public double WindSpeedMph2MinuteAverage { get; set; }
    
        /// <summary>
        /// The average wind direction over a 2 minute period
        /// </summary>
        [JsonPropertyName("winddir_avg2m")]
        public int WindDirection2MinuteAverage { get; set; }
    
        /// <summary>
        /// The average wind speed over a 10 minute period in miles per hour
        /// </summary>
        [JsonPropertyName("windspdmph_avg10m")]
        public double WindSpeedMph10MinuteAverage { get; set; }
    
        /// <summary>
        /// The average wind direction over a 10 minute period
        /// </summary>
        [JsonPropertyName("winddir_avg10m")]
        public int WindDirection10MinuteAverage { get; set; }
    
        /// <summary>
        /// The outdoor humidity
        /// </summary>
        [JsonPropertyName("humidity")]
        public int OutdoorHumidity { get; set; } 
    
        /// <summary>
        /// Outdoor Humidity Sensor 1
        /// </summary>
        [JsonPropertyName("humidity1")]
        public double OutdoorHumiditySensor1 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 2
        /// </summary>
        [JsonPropertyName("humidity2")]
        public double OutdoorHumiditySensor2 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 3
        /// </summary>
        [JsonPropertyName("humidity3")]
        public double OutdoorHumiditySensor3 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 4
        /// </summary>
        [JsonPropertyName("humidity4")]
        public double OutdoorHumiditySensor4 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 5
        /// </summary>
        [JsonPropertyName("humidity5")]
        public double OutdoorHumiditySensor5 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 6
        /// </summary>
        [JsonPropertyName("humidity6")]
        public double OutdoorHumiditySensor6 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 7
        /// </summary>
        [JsonPropertyName("humidity7")]
        public double OutdoorHumiditySensor7 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 8
        /// </summary>
        [JsonPropertyName("humidity8")]
        public double OutdoorHumiditySensor8 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 9
        /// </summary>
        [JsonPropertyName("humidity9")]
        public double OutdoorHumiditySensor9 { get; set; }
    
        /// <summary>
        /// Outdoor Humidity Sensor 10
        /// </summary>
        [JsonPropertyName("humidity10")]
        public double OutdoorHumiditySensor10 { get; set; }
    
        /// <summary>
        /// Indoor Humidity
        /// </summary>
        [JsonPropertyName("humidityin")]
        public int IndoorHumidity { get; set; }
    
        /// <summary>
        /// Outdoor Temperature in Fahrenheit
        /// </summary>
        [JsonPropertyName("tempf")]
        public double OutdoorTemperatureFahrenheit { get; set; }
    
        /// <summary>
        /// Outdoor Temperature Sensor 1 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp1f")]
        public double OutdoorTemperatureSensor1 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 2 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp2f")]
        public double OutdoorTemperatureSensor2 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 3 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp3f")]
        public double OutdoorTemperatureSensor3 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 4 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp4f")]
        public double OutdoorTemperatureSensor4 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 5 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp5f")]
        public double OutdoorTemperatureSensor5 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 6 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp6f")]
        public double OutdoorTemperatureSensor6 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 7 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp7f")]
        public double OutdoorTemperatureSensor7 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 8 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp8f")]
        public double OutdoorTemperatureSensor8 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 9 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp9f")]
        public double OutdoorTemperatureSensor9 { get; set; }

        /// <summary>
        /// Outdoor Temperature Sensor 10 in Fahrenheit
        /// </summary>
        [JsonPropertyName("temp10f")]
        public double OutdoorTemperatureSensor10 { get; set; }
    
        /// <summary>
        /// Soil Temperature Sensor 1 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp1f")]
        public double SoilTemperatureSensor1 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 2 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp2f")]
        public double SoilTemperatureSensor2 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 3 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp3f")]
        public double SoilTemperatureSensor3 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 4 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp4f")]
        public double SoilTemperatureSensor4 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 5 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp5f")]
        public double SoilTemperatureSensor5 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 6 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp6f")]
        public double SoilTemperatureSensor6 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 7 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp7f")]
        public double SoilTemperatureSensor7 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 8 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp8f")]
        public double SoilTemperatureSensor8 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 9 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp9f")]
        public double SoilTemperatureSensor9 { get; set; }

        /// <summary>
        /// Soil Temperature Sensor 10 in Fahrenheit
        /// </summary>
        [JsonPropertyName("soiltemp10f")]
        public double SoilTemperatureSensor10 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 1
        /// </summary>
        [JsonPropertyName("soilhum1")]
        public double SoilHumiditySensor1 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 2
        /// </summary>
        [JsonPropertyName("soilhum2")]
        public double SoilHumiditySensor2 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 3
        /// </summary>
        [JsonPropertyName("soilhum3")]
        public double SoilHumiditySensor3 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 4
        /// </summary>
        [JsonPropertyName("soilhum4")]
        public double SoilHumiditySensor4 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 5
        /// </summary>
        [JsonPropertyName("soilhum5")]
        public double SoilHumiditySensor5 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 6
        /// </summary>
        [JsonPropertyName("soilhum6")]
        public double SoilHumiditySensor6 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 7
        /// </summary>
        [JsonPropertyName("soilhum7")]
        public double SoilHumiditySensor7 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 8
        /// </summary>
        [JsonPropertyName("soilhum8")]
        public double SoilHumiditySensor8 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 9
        /// </summary>
        [JsonPropertyName("soilhum9")]
        public double SoilHumiditySensor9 { get; set; }

        /// <summary>
        /// Soil Humidity Sensor 10
        /// </summary>
        [JsonPropertyName("soilhum10")]
        public double SoilHumiditySensor10 { get; set; }
    
        /// <summary>
        /// Indoor Temperature in Fahrenheit
        /// </summary>
        [JsonPropertyName("tempinf")]
        public double IndoorTemperatureFahrenheit { get; set; }
    
        /// <summary>
        /// A battery indicator 
        /// A value of 1 represents an 'OK' battery level
        /// A value of 0 represents a 'low' battery level
        /// 
        /// For Meteobridge Users: the above value are flipped. See below.
        /// A value of 0 represents an 'OK' battery level
        /// A value of 1 represents a 'low' battery level
        /// </summary>
        [JsonPropertyName("battout")]
        public int BatteryLowIndicator { get; set; }
    
        /// <summary>
        /// A battery indicator for sensor 1
        /// A value of 1 represents an 'OK' battery level
        /// A value of 0 represents a 'low' battery level
        /// 
        /// For Meteobridge Users: the above value are flipped. See below.
        /// A value of 0 represents an 'OK' battery level
        /// A value of 1 represents a 'low' battery level
        /// </summary>
        [JsonPropertyName("batt1")]
        public int BatteryLowIndicator1 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 2
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt2")]
        public int BatteryLowIndicator2 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 3
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt3")]
        public int BatteryLowIndicator3 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 4
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt4")]
        public int BatteryLowIndicator4 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 5
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt5")]
        public int BatteryLowIndicator5 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 6
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt6")]
        public int BatteryLowIndicator6 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 7
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt7")]
        public int BatteryLowIndicator7 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 8
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt8")]
        public int BatteryLowIndicator8 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 9
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt9")]
        public int BatteryLowIndicator9 { get; set; }

        /// <summary>
        /// A battery indicator for sensor 10
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt10")]
        public int BatteryLowIndicator10 { get; set; }
    
        /// <summary>
        /// A battery indicator for the PM 2.5 Air Quality Sensor
        /// <see cref="BatteryLowIndicator1"/>
        /// </summary>
        [JsonPropertyName("batt_25")]
        public int PM25AirQualityBatteryLowIndicator { get; set; }
    
        /// <summary>
        /// Hourly Rainfall in Inches
        /// </summary>
        [JsonPropertyName("hourlyrainin")]
        public double HourlyRainfall { get; set; } 
    
        /// <summary>
        /// Daily Rainfall in Inches
        /// </summary>
        [JsonPropertyName("dailyrainin")]
        public double DailyRainfall { get; set; }
    
        /// <summary>
        /// Previous 24 hour rainfall in inches
        /// </summary>
        [JsonPropertyName("24hourrainin")]
        public double Previous24HourRainfall { get; set; }
    
        /// <summary>
        /// Weekly rainfall in inches
        /// </summary>
        [JsonPropertyName("weeklyrainin")]
        public double WeeklyRainfall { get; set; } 

        /// <summary>
        /// Monthly rainfall in inches
        /// </summary>
        [JsonPropertyName("monthlyrainin")]
        public double MonthlyRainfall { get; set; } 
    
        /// <summary>
        /// Yearly rainfall in inches
        /// </summary>
        [JsonPropertyName("yearlyrainin")]
        public double YearlyRainfall { get; set; } 
    
        /// <summary>
        /// Current event's rainfall in inches
        /// </summary>
        [JsonPropertyName("eventrainin")]
        public double EventRainfall { get; set; } 
    
        /// <summary>
        /// Total rainfall recorded by sensor in inches
        /// </summary>
        [JsonPropertyName("totalrainin")]
        public double TotalRainfall { get; set; }
    
        /// <summary>
        /// Relative Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        [JsonPropertyName("baromrelin")]
        public double RelativeBarometricPressure { get; set; } 

        /// <summary>
        /// Absolute Barometric Pressure in inches of mercury (in-HG)
        /// </summary>
        [JsonPropertyName("baromabsin")]
        public double AbsoluteBarometricPressure { get; set; } 
    
        /// <summary>
        /// Solar Radiation measured in Watts Per Meter^2 (W/m^2)
        /// </summary>
        [JsonPropertyName("solarradiation")]
        public double SolarRadiation { get; set; } 

        /// <summary>
        /// Ultra-violet radiation index
        /// </summary>
        [JsonPropertyName("uv")]
        public int UltravioletRadiationIndex { get; set; } 
    
        /// <summary>
        /// Carbon Dioxide measured in Parts Per Million
        /// </summary>
        [JsonPropertyName("co2")]
        public double CO2PPM { get; set; } 
    
        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay1")]
        public int Relay1 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay2")]
        public int Relay2 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay3")]
        public int Relay3 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay4")]
        public int Relay4 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay5")]
        public int Relay5 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay6")]
        public int Relay6 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay7")]
        public int Relay7 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay8")]
        public int Relay8 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay9")]
        public int Relay9 { get; set; }

        /// <summary>
        /// Relay Sensor 1
        /// </summary>
        [JsonPropertyName("relay10")]
        public int Relay10 { get; set; }
        
        /// <summary>
        /// Latest Outdoor PM 2.5 Air Quality
        /// Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>
        [JsonPropertyName("pm25")]
        public double PM25OutdoorAirQuality { get; set; }
        
        /// <summary>
        /// Outdoor PM 2.5 Air Quality, 24 hour average.
        /// Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>
        [JsonPropertyName("pm25_24h")]
        public double PM25OutdoorAirQuality24HourAverage { get; set; }
        
        /// <summary>
        /// Latest Indoor PM 2.5 Air Quality
        /// Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>
        [JsonPropertyName("pm25_in")]
        public double PM25IndoorAirQuality { get; set; }
        
        /// <summary>
        /// Indoor PM 2.5 Air Quality, 24 hour average.
        /// Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>
        [JsonPropertyName("pm25_in_24h")]
        public double PM25IndoorAirQuality24HourAverage { get; set; }
        
        /// <summary>
        /// IANA TimeZone
        /// </summary>
        [JsonPropertyName("tz")]
        public string IANATimeZone { get; set; }
    
        /// <summary>
        /// Epoch time from 1/1/1970 (measured in milliseconds according to ambient weather docs)
        /// </summary>
        [JsonPropertyName("dateutc")]
        public long EpochMilliseconds { get; set; }
        
        /// <summary>
        /// Last Date recorded where <see cref="HourlyRainfall"/> > 0 inches
        /// </summary>
        [JsonPropertyName("lastRain")]
        public DateTimeOffset LastRain { get; set; } 

        /// <summary>
        /// Feels Like Temperature
        /// if < 50ºF => Wind Chill,
        /// if > 68ºF => Heat Index (calculated on server)
        /// </summary>
        [JsonPropertyName("feelsLike")]
        public double OutdoorFeelsLikeTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// Dew Point Temperature in Fahrenheit
        /// </summary>
        [JsonPropertyName("dewPoint")]
        public double DewPointFahrenheit { get; set; } 
        
        /// <summary>
        /// DateTime version of <see cref="EpochMilliseconds"/>
        /// </summary>
        [JsonPropertyName("date")]
        public DateTimeOffset UtcDate { get; set; } 
        
        /// <summary>
        /// Feels Like Temperature Sensor 1
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike1")]
        public int OutdoorFeelsLikeTemperatureFahrenheit1 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 2
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike2")]
        public int OutdoorFeelsLikeTemperatureFahrenheit2 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 3
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike3")]
        public int OutdoorFeelsLikeTemperatureFahrenheit3 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 4
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike4")]
        public int OutdoorFeelsLikeTemperatureFahrenheit4 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 5
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike5")]
        public int OutdoorFeelsLikeTemperatureFahrenheit5 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 6
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike6")]
        public int OutdoorFeelsLikeTemperatureFahrenheit6 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 7
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike7")]
        public int OutdoorFeelsLikeTemperatureFahrenheit7 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 8
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike8")]
        public int OutdoorFeelsLikeTemperatureFahrenheit8 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 9
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike9")]
        public int OutdoorFeelsLikeTemperatureFahrenheit9 { get; set; }

        /// <summary>
        /// Feels Like Temperature Sensor 10
        /// <see cref="OutdoorFeelsLikeTemperatureFahrenheit"/>
        /// </summary>
        [JsonPropertyName("feelsLike10")]
        public int OutdoorFeelsLikeTemperatureFahrenheit10 { get; set; }
        
        /// <summary>
        /// Dew Point Temperature for Sensor 1
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint1")]
        public double DewPointFahrenheit1 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 2
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint2")]
        public double DewPointFahrenheit2 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 3
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint3")]
        public double DewPointFahrenheit3 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 4
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint4")]
        public double DewPointFahrenheit4 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 5
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint5")]
        public double DewPointFahrenheit5 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 6
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint6")]
        public double DewPointFahrenheit6 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 7
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint7")]
        public double DewPointFahrenheit7 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 8
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint8")]
        public double DewPointFahrenheit8 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 9
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint9")]
        public double DewPointFahrenheit9 { get; set; }

        /// <summary>
        /// Dew Point Temperature for Sensor 10
        /// <see cref="DewPointFahrenheit"/>
        /// </summary>
        [JsonPropertyName("dewPoint10")]
        public double DewPointFahrenheit10 { get; set; }

        /// <summary>
        /// Indoor Feels Like Temperature in Fahrenheit
        /// </summary>
        [JsonPropertyName("feelsLikein")]
        public double IndoorFeelsLikeTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// Indoor Dew Point Temperature in Fahrenheit
        /// </summary>
        [JsonPropertyName("dewPointin")]
        public double IndoorDewPointTemperatureFahrenheit { get; set; } 

        /// <summary>
        /// Unknown value? Probably something to do with Ambient Weathers Databases/Servers?
        /// </summary>
        [JsonPropertyName("loc")]
        public string Loc { get; set; } 
    }
}
