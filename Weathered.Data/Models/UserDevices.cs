using System;
using System.Collections.Generic;

namespace Weathered.Data.Models.Core
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<UserDevice>(myJsonResponse);
    public class Geo
    {
        /// <summary>
        /// The Type of Geo Coordinates. i.e. "Point"
        /// </summary>
        
        public string Type { get; set; }
        
        /// <summary>
        /// A list of doubles containing the lat/lon coordinates
        /// coordinates[0] is longitude
        /// coordinates[1] is latitude
        /// </summary>
        
        public List<double> Coordinates { get; set; }
    }
    
    public class Coords2
    {
        /// <summary>
        /// Latitude of the weather station
        /// </summary>
        
        public double Latitude { get; set; }
        
        /// <summary>
        /// Longitude of the weather station
        /// </summary>
        
        public double Longitude { get; set; }
    }
    
    public class Coords
    {
        /// <summary>
        /// Geographic coordinates of the weather station
        /// </summary>
        public Coords2 Coord2 { get; set; }
        
        /// <summary>
        /// Address
        /// </summary>
        
        public string Address { get; set; }
        
        /// <summary>
        /// City
        /// </summary>
        
        public string Location { get; set; }
        
        /// <summary>
        /// Elevation above sea-level in meters
        /// </summary>
        
        public double Elevation { get; set; }
        
        /// <summary>
        /// Geographic coordinates of the station
        /// </summary>
        
        public Geo Geo { get; set; }
    }
    
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
        
        public Coords Coords { get; set; }
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
        /// Instance of <see cref="Device"/> class
        /// </summary>
        
        public Device LastData { get; set; } 
        
        /// <summary>
        /// The API Key used for the subcribe command
        /// </summary>
        
        public string ApiKey { get; set; }
    }
    
    public class Root
    {
        /// <summary>
        /// List of devices belonging to the user
        /// </summary>
        
        public List<UserDevice> Devices { get; set; }
        
        /// <summary>
        /// List of invalid API keys
        /// After sending the 'unsubscribe' command, ambient weather returns a list of invalid API keys
        /// </summary>
        
        public List<string> InvalidAPIKeys { get; set; }
        
        /// <summary>
        /// The returned event type
        /// </summary>
        
        public string Method { get; set; }
    }
}