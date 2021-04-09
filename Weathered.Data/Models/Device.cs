// Root myDeserializedClass = JsonSerializer.Deserialize<Device>(myJsonResponse);

using System;
using System.ComponentModel.DataAnnotations;

namespace Weathered.Data.Models
{
    public class Device
    {
        // These fields below are fields that I have personally retrieved from my Ambient Weather Station (WS-2902A)

        /// <summary>
        ///     Epoch (Unix) time from 1/1/1970 (measured in milliseconds according to ambient weather docs)
        /// </summary>

        public long? EpochMilliseconds { get; set; }

        /// <summary>
        ///     Indoor Temperature in Fahrenheit reported by the Base Station
        /// </summary>

        public double? IndoorTemperatureFahrenheit { get; set; }

        /// <summary>
        ///     Indoor Humidity reported by the Base Station
        /// </summary>

        public int? IndoorHumidity { get; set; }

        /// <summary>
        ///     Relative Barometric Pressure in inches of mercury (in-HG) reported by the Outdoor Sensor Array
        /// </summary>

        public double? RelativeBarometricPressure { get; set; }

        /// <summary>
        ///     Absolute Barometric Pressure in inches of mercury (in-HG) reported by the Outdoor Sensor Array
        /// </summary>

        public double? AbsoluteBarometricPressure { get; set; }

        /// <summary>
        ///     Outdoor Temperature in Fahrenheit reported by the Outdoor Sensor Array
        /// </summary>

        public double? OutdoorTemperatureFahrenheit { get; set; }

        /// <summary>
        ///     A battery indicator reported by the Outdoor Sensor Array
        ///     A value of 1 represents an 'OK' battery level
        ///     A value of 0 represents a 'low' battery level
        ///     For Meteobridge Users: the above value are flipped. See below.
        ///     A value of 0 represents an 'OK' battery level
        ///     A value of 1 represents a 'low' battery level
        /// </summary>

        public int? BatteryLowIndicator { get; set; }

        /// <summary>
        ///     The outdoor humidity reported by the Outdoor Sensor Array
        /// </summary>

        public int? OutdoorHumidity { get; set; }

        /// <summary>
        ///     Wind Direction reported by the Outdoor Sensor Array
        /// </summary>

        public int? WindDirection { get; set; }

        /// <summary>
        ///     Wind Speed in Miles Per Hour reported by the Outdoor Sensor Array
        /// </summary>

        public double? WindSpeedMph { get; set; }

        /// <summary>
        ///     Wind Gust in Miles Per Hour reported by the Outdoor Sensor Array
        /// </summary>

        public double? WindGustMph { get; set; }

        /// <summary>
        ///     The maximum windspeed from a wind gust for that day
        /// </summary>

        public double? MaxDailyGust { get; set; }

        /// <summary>
        ///     Hourly Rainfall in Inches
        /// </summary>

        public double? HourlyRainfall { get; set; }

        /// <summary>
        ///     Current event's rainfall in inches
        /// </summary>

        public double? EventRainfall { get; set; }

        /// <summary>
        ///     Daily Rainfall in Inches
        /// </summary>

        public double? DailyRainfall { get; set; }

        /// <summary>
        ///     Weekly rainfall in inches
        /// </summary>

        public double? WeeklyRainfall { get; set; }

        /// <summary>
        ///     Monthly rainfall in inches
        /// </summary>

        public double? MonthlyRainfall { get; set; }

        /// <summary>
        ///     Yearly rainfall in inches
        /// </summary>

        public double? YearlyRainfall { get; set; }

        /// <summary>
        ///     Total rainfall recorded by sensor in inches
        /// </summary>

        public double? TotalRainfall { get; set; }

        /// <summary>
        ///     Solar Radiation measured in Watts Per Meter^2 (W/m^2) reported by the Outdoor Sensor Array
        /// </summary>

        public double? SolarRadiation { get; set; }

        /// <summary>
        ///     Ultra-violet radiation index reported by the Outdoor Sensor Array
        /// </summary>

        public int? UltravioletRadiationIndex { get; set; }

        /// <summary>
        ///     Feels Like Temperature
        ///     if
        ///     < 50ºF =>
        ///         Wind Chill,
        ///         if > 68ºF => Heat Index (calculated on server)
        /// </summary>

        public double? OutdoorFeelsLikeTemperatureFahrenheit { get; set; }

        /// <summary>
        ///     Dew Point Temperature in Fahrenheit
        /// </summary>

        public double? DewPointFahrenheit { get; set; }

        /// <summary>
        ///     Indoor Feels Like Temperature in Fahrenheit reported by the Base Station
        /// </summary>

        public double? IndoorFeelsLikeTemperatureFahrenheit { get; set; }

        /// <summary>
        ///     Indoor Dew Point Temperature in Fahrenheit reported by the Base Station
        /// </summary>

        public double? IndoorDewPointTemperatureFahrenheit { get; set; }

        /// <summary>
        ///     Last DateTime recorded where <see cref="HourlyRainfall" /> was > 0 inches
        /// </summary>

        public DateTimeOffset LastRain { get; set; }

        /// <summary>
        ///     Unknown value? Probably something to do with Ambient Weathers Databases/Servers?
        /// </summary>
        /// `

        public string? Loc { get; set; }

        /// <summary>
        ///     DateTime version of <see cref="EpochMilliseconds" />
        /// </summary>

        public DateTimeOffset? UtcDate { get; set; }

        // Fields Below Here are not returned by my WS-2902A Weather Station.
        // These fields attempt to follow the specification as closely as possible

        /// <summary>
        ///     The direction of the wind gust
        ///     See <see cref="MaxDailyGust" />>
        /// </summary>

        public float? WindGustDir { get; set; }

        /// <summary>
        ///     The average wind speed over a 2 minute period in miles per hour
        /// </summary>

        public double? WindSpeedMph2MinuteAverage { get; set; }

        /// <summary>
        ///     The average wind direction over a 2 minute period
        /// </summary>

        public int? WindDirection2MinuteAverage { get; set; }

        /// <summary>
        ///     The average wind speed over a 10 minute period in miles per hour
        /// </summary>

        public double? WindSpeedMph10MinuteAverage { get; set; }

        /// <summary>
        ///     The average wind direction over a 10 minute period
        /// </summary>

        public int? WindDirection10MinuteAverage { get; set; }

        /// <summary>
        ///     A battery indicator for the PM 2.5 Air Quality Sensor
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? PM25AirQualityBatteryLowIndicator { get; set; }

        /// <summary>
        ///     Previous 24 hour rainfall in inches
        /// </summary>

        public double? Previous24HourRainfall { get; set; }

        /// <summary>
        ///     Carbon Dioxide measured in Parts Per Million
        /// </summary>

        public double? CO2PPM { get; set; }

        /// <summary>
        ///     A battery indicator for the CO2 Sensor
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public string? CO2SensorBatteryLowIndicator { get; set; }

        /// <summary>
        ///     Latest Outdoor PM 2.5 Air Quality
        ///     Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>

        public double? PM25OutdoorAirQuality { get; set; }

        /// <summary>
        ///     Outdoor PM 2.5 Air Quality, 24 hour average.
        ///     Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>

        public double? PM25OutdoorAirQuality24HourAverage { get; set; }

        /// <summary>
        ///     Latest Indoor PM 2.5 Air Quality
        ///     Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>

        public double? PM25IndoorAirQuality { get; set; }

        /// <summary>
        ///     Indoor PM 2.5 Air Quality, 24 hour average.
        ///     Measured in micrograms per cubic meter of air (µg/m^3)
        /// </summary>

        public double? PM25IndoorAirQuality24HourAverage { get; set; }

        /// <summary>
        ///     Humidity Sensor 1
        /// </summary>

        public int? HumiditySensor1 { get; set; }

        /// <summary>
        ///     Humidity Sensor 2
        /// </summary>

        public int? HumiditySensor2 { get; set; }

        /// <summary>
        ///     Humidity Sensor 3
        /// </summary>

        public int? HumiditySensor3 { get; set; }

        /// <summary>
        ///     Humidity Sensor 4
        /// </summary>

        public int? HumiditySensor4 { get; set; }

        /// <summary>
        ///     Humidity Sensor 5
        /// </summary>

        public int? HumiditySensor5 { get; set; }

        /// <summary>
        ///     Humidity Sensor 6
        /// </summary>

        public int? HumiditySensor6 { get; set; }

        /// <summary>
        ///     Humidity Sensor 7
        /// </summary>

        public int? HumiditySensor7 { get; set; }

        /// <summary>
        ///     Humidity Sensor 8
        /// </summary>

        public int? HumiditySensor8 { get; set; }

        /// <summary>
        ///     Humidity Sensor 9
        /// </summary>

        public int? HumiditySensor9 { get; set; }

        /// <summary>
        ///     Humidity Sensor 10
        /// </summary>

        public int? HumiditySensor10 { get; set; }

        /// <summary>
        ///     Temperature Sensor 1 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor1 { get; set; }

        /// <summary>
        ///     Temperature Sensor 2 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor2 { get; set; }

        /// <summary>
        ///     Temperature Sensor 3 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor3 { get; set; }

        /// <summary>
        ///     Temperature Sensor 4 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor4 { get; set; }

        /// <summary>
        ///     Temperature Sensor 5 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor5 { get; set; }

        /// <summary>
        ///     Temperature Sensor 6 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor6 { get; set; }

        /// <summary>
        ///     Temperature Sensor 7 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor7 { get; set; }

        /// <summary>
        ///     Temperature Sensor 8 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor8 { get; set; }

        /// <summary>
        ///     Temperature Sensor 9 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor9 { get; set; }

        /// <summary>
        ///     Temperature Sensor 10 in Fahrenheit
        /// </summary>

        public double? TemperatureSensor10 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 1 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor1 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 2 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor2 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 3 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor3 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 4 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor4 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 5 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor5 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 6 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor6 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 7 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor7 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 8 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor8 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 9 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor9 { get; set; }

        /// <summary>
        ///     Soil Temperature Sensor 10 in Fahrenheit
        /// </summary>

        public double? SoilTemperatureSensor10 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 1
        /// </summary>

        public int? SoilHumiditySensor1 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 2
        /// </summary>

        public int? SoilHumiditySensor2 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 3
        /// </summary>

        public int? SoilHumiditySensor3 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 4
        /// </summary>

        public int? SoilHumiditySensor4 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 5
        /// </summary>

        public int? SoilHumiditySensor5 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 6
        /// </summary>

        public int? SoilHumiditySensor6 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 7
        /// </summary>

        public int? SoilHumiditySensor7 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 8
        /// </summary>

        public int? SoilHumiditySensor8 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 9
        /// </summary>

        public int? SoilHumiditySensor9 { get; set; }

        /// <summary>
        ///     Soil Humidity Sensor 10
        /// </summary>

        public int? SoilHumiditySensor10 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 1
        ///     A value of 1 represents an 'OK' battery level
        ///     A value of 0 represents a 'low' battery level
        ///     For Meteobridge Users: the above value are flipped. See below.
        ///     A value of 0 represents an 'OK' battery level
        ///     A value of 1 represents a 'low' battery level
        /// </summary>

        public int? BatteryLowIndicator1 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 2
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator2 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 3
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator3 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 4
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator4 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 5
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator5 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 6
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator6 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 7
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator7 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 8
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator8 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 9
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator9 { get; set; }

        /// <summary>
        ///     A battery indicator for sensor 10
        ///     <see cref="BatteryLowIndicator1" />
        /// </summary>

        public int? BatteryLowIndicator10 { get; set; }

        /// <summary>
        ///     Relay Sensor 1 - Value: 0 or 1
        /// </summary>

        public int? Relay1 { get; set; }

        /// <summary>
        ///     Relay Sensor 2 - Value: 0 or 1
        /// </summary>

        public int? Relay2 { get; set; }

        /// <summary>
        ///     Relay Sensor 3 - Value: 0 or 1
        /// </summary>

        public int? Relay3 { get; set; }

        /// <summary>
        ///     Relay Sensor 4 - Value: 0 or 1
        /// </summary>

        public int? Relay4 { get; set; }

        /// <summary>
        ///     Relay Sensor 5 - Value: 0 or 1
        /// </summary>

        public int? Relay5 { get; set; }

        /// <summary>
        ///     Relay Sensor 6 - Value: 0 or 1
        /// </summary>

        public int? Relay6 { get; set; }

        /// <summary>
        ///     Relay Sensor 7 - Value: 0 or 1
        /// </summary>

        public int? Relay7 { get; set; }

        /// <summary>
        ///     Relay Sensor 8 - Value: 0 or 1
        /// </summary>

        public int? Relay8 { get; set; }

        /// <summary>
        ///     Relay Sensor 9 - Value: 0 or 1
        /// </summary>

        public int? Relay9 { get; set; }

        /// <summary>
        ///     Relay Sensor 10 - Value: 0 or 1
        /// </summary>

        public int? Relay10 { get; set; }

        /// <summary>
        ///     IANA TimeZone
        /// </summary>

        public string? IANATimeZone { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 1
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit1 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 2
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit2 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 3
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit3 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 4
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit4 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 5
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit5 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 6
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit6 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 7
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit7 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 8
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit8 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 9
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit9 { get; set; }

        /// <summary>
        ///     Feels Like Temperature Sensor 10
        ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />
        /// </summary>

        public double? FeelsLikeTemperatureFahrenheit10 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 1
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit1 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 2
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit2 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 3
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit3 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 4
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit4 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 5
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit5 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 6
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit6 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 7
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit7 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 8
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit8 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 9
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit9 { get; set; }

        /// <summary>
        ///     Dew Point Temperature for Sensor 10
        ///     <see cref="DewPointFahrenheit" />
        /// </summary>

        public double? DewPointFahrenheit10 { get; set; }

        /// <summary>
        ///     Weather Station Mac Address
        ///     This value is always null when querying the REST API
        ///     This value is always populated when receiving events from the Websocket (Realtime) API
        /// </summary>
        public string? MacAddress { get; set; }
    }
}