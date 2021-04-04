using System;
using Newtonsoft.Json;

namespace Weathered.API.Models.Rest
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
        /// Instance of <see cref="Device"/> class
        /// </summary>
        [JsonProperty("lastData")]
        public Device LastData { get; set; } 
    }
}