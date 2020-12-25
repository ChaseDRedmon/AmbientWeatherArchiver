using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Weathered.API.Models;

namespace Weathered.API
{
    public interface IAmbientWeatherRestService
    {
        /// <summary>
        /// Fetch Recorded Weather Data based on a Weather Station's MAC Address from the Ambient Weather API
        /// </summary>
        /// <param name="macAddress">Weather Stations MAC Address. Found Here: https://ambientweather.net/devices</param>
        /// <param name="applicationKey">Account Application Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="apiKey">Account API Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="endDate">Date for Last Data Entry. Results will end here and cascade backwards through time.</param>
        /// <param name="limit">The amount of items to return. Default is 288. Items are in 5 minute increments, meaning 288 items is 1 day's worth of data.</param>
        /// <returns>Returns a <see cref="Device"/> object.</returns>
        Task<Device> FetchDeviceDataAsync(string macAddress, string apiKey, string applicationKey, DateTimeOffset? endDate, int limit = 288);
        
        /// <summary>
        /// Fetch a list of devices under the user's account and the most recent weather data
        /// </summary>
        /// <param name="applicationKey">Account Application Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="apiKey">Account API Key. Found Here: https://ambientweather.net/account</param>
        /// <returns>Returns a <see cref="Device"/> object.</returns>
        Task<UserDevice> FetchUserDevicesAsync(string apiKey, string applicationKey);
    }

    public class AmbientWeatherRestService : IAmbientWeatherRestService
    {
        private readonly HttpClient _client = new HttpClient();
        private Uri _baseAddress { get; set; }

        /// <summary>
        /// Creates a new <see cref="AmbientWeatherRestService"/> and initializes the base address for the Ambient Weather API
        /// </summary>
        private AmbientWeatherRestService()
        {
            // Base Address for the Ambient Weather API
            _baseAddress = new Uri("https://api.ambientweather.net/");
        }

        /// <inheritdoc cref="FetchDeviceDataAsync"/>
        public async Task<Device> FetchDeviceDataAsync(string macAddress, string apiKey, string applicationKey,
            DateTimeOffset? endDate, int limit = 288)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(macAddress))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(macAddress));
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            if (string.IsNullOrWhiteSpace(applicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(applicationKey));

            // Build our query
            var path = $"v1/devices/{macAddress}?apiKey={apiKey}&applicationKey={applicationKey}&limit={limit}";

            // Query the Ambient Weather API
            var json = await QueryAmbientWeatherApiAsync(path);
            
            // Deserialize the JSON that's returned from the API
            var data = JsonSerializer.Deserialize<Device>(json);

            return data;
        }
        
        /// <inheritdoc cref="FetchUserDevicesAsync"/>
        public async Task<UserDevice> FetchUserDevicesAsync(string applicationKey, string apiKey)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            if (string.IsNullOrWhiteSpace(applicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(applicationKey));

            // Build our query
            var path = $"v1/devices?applicationKey={applicationKey}&apiKey={apiKey}";
            
            // Query the Ambient Weather API
            var json = await QueryAmbientWeatherApiAsync(path);
            
            // Deserialize the JSON that's returned from the API
            var data = JsonSerializer.Deserialize<UserDevice>(json);

            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task<string> QueryAmbientWeatherApiAsync(string path)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(path));

            // Build the full API Uri
            var builder = new UriBuilder
            {
                Scheme = _baseAddress.Scheme, 
                Host = _baseAddress.Host, 
                Path = path
            };

            // Get and return a JSON string from the Ambient Weather API
            var response = await _client.GetStringAsync(builder.Uri);
            return response;
        }
    }
}