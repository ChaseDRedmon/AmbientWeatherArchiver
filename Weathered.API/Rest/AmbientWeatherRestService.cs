﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weathered.API.Models;

namespace Weathered.API.Rest
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
        /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken"/></param>
        /// <param name="limit">The amount of items to return. Maximum is 288. Items are in 5 minute increments, meaning 288 items is 1 day's worth of data.</param>
        /// <returns>Returns a <see cref="Device"/> object.</returns>
        Task<IEnumerable<Device>> FetchDeviceDataAsync(string macAddress, string apiKey, string applicationKey, DateTimeOffset? endDate, CancellationToken cancellationToken, int limit = 288);
        
        /// <summary>
        /// Fetch Recorded Weather Data based on a Weather Station's MAC Address from the Ambient Weather API
        /// </summary>
        /// <param name="macAddress">Weather Stations MAC Address. Found Here: https://ambientweather.net/devices</param>
        /// <param name="applicationKey">Account Application Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="apiKey">Account API Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="endDate">Date for Last Data Entry. Results will end here and cascade backwards through time.</param>
        /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken"/></param>
        /// <param name="limit">The amount of items to return. Maximum is 288. Items are in 5 minute increments, meaning 288 items is 1 day's worth of data.</param>
        /// <returns>Returns a JSON string</returns>
        Task<string> FetchDeviceDataAsJsonAsync(string macAddress, string apiKey, string applicationKey, DateTimeOffset? endDate, CancellationToken cancellationToken, int limit = 288);
        
        /// <summary>
        /// Fetch a list of devices under the user's account and the most recent weather data for each device
        /// </summary>
        /// <param name="applicationKey">Account Application Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="apiKey">Account API Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken"/></param>
        /// <returns>Returns a <see cref="Device"/> object.</returns>
        Task<IEnumerable<UserDevice>> FetchUserDevicesAsync(string apiKey, string applicationKey, CancellationToken cancellationToken);
        
        /// <summary>
        /// Fetch a list of devices under the user's account and the most recent weather data for each device
        /// </summary>
        /// <param name="applicationKey">Account Application Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="apiKey">Account API Key. Found Here: https://ambientweather.net/account</param>
        /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken"/></param>
        /// <returns>Returns a JSON string</returns>
        Task<string> FetchUserDevicesAsJsonAsync(string apiKey, string applicationKey, CancellationToken cancellationToken);
    }

    public class AmbientWeatherRestService : IAmbientWeatherRestService
    {
        private readonly HttpClient _client;
        private Uri BaseAddress { get; set; }

        /// <summary>
        /// Creates a new <see cref="AmbientWeatherRestService"/> and initializes the base address for the Ambient Weather API
        /// </summary>
        public AmbientWeatherRestService(HttpClient client)
        {
            _client = client;

            // Base Address for the Ambient Weather API
            BaseAddress = new Uri("https://api.ambientweather.net/v1/");
        }

        /// <inheritdoc cref="FetchDeviceDataAsync"/>
        public async Task<IEnumerable<Device>> FetchDeviceDataAsync(string macAddress, string apiKey, string applicationKey,
            DateTimeOffset? endDate, CancellationToken cancellationToken, int limit = 288)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(macAddress))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(macAddress));
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            if (string.IsNullOrWhiteSpace(applicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(applicationKey));

            // Fetch the JSON string
            var json = await FetchDeviceDataAsJsonAsync(macAddress, apiKey, applicationKey, endDate, cancellationToken, limit);
            
            // Deserialize the JSON that's returned from the API
            var data = JsonConvert.DeserializeObject<IEnumerable<Device>>(json);

            return data;
        }

        /// <inheritdoc cref="FetchDeviceDataAsJsonAsync"/>
        public async Task<string> FetchDeviceDataAsJsonAsync(string macAddress, string apiKey, string applicationKey, DateTimeOffset? endDate,
            CancellationToken cancellationToken, int limit = 288)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(macAddress))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(macAddress));
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            if (string.IsNullOrWhiteSpace(applicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(applicationKey));

            // Build our query
            var path = $"devices/{macAddress}";
            var query = $"?apiKey={apiKey}&applicationKey={applicationKey}";

            if (endDate.HasValue)
            {
                query += endDate.Value.ToUniversalTime().ToUnixTimeMilliseconds().ToString();
            }

            query += $"&limit={limit.ToString()}";

            // Query the Ambient Weather API
            var json = await QueryAmbientWeatherApiAsync(path, query, cancellationToken);

            return json;
        }

        /// <inheritdoc cref="FetchUserDevicesAsync"/>
        public async Task<IEnumerable<UserDevice>> FetchUserDevicesAsync(string applicationKey, string apiKey, CancellationToken cancellationToken)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            if (string.IsNullOrWhiteSpace(applicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(applicationKey));
            
            // Fetch the JSON string
            var json = await FetchUserDevicesAsJsonAsync(apiKey, applicationKey, cancellationToken);
            
            // Deserialize the JSON that's returned from the API
            var data = JsonConvert.DeserializeObject<IEnumerable<UserDevice>>(json);

            return data;
        }

        public async Task<string> FetchUserDevicesAsJsonAsync(string apiKey, string applicationKey, CancellationToken cancellationToken)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            if (string.IsNullOrWhiteSpace(applicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(applicationKey));

            // Build our query
            const string path = "devices";
            var query = $"?applicationKey={applicationKey}&apiKey={apiKey}";
            
            // Query the Ambient Weather API
            var json = await QueryAmbientWeatherApiAsync(path, query, cancellationToken);

            return json;
        }

        /// <summary>
        /// Submits a request to the Ambient Weather API
        /// </summary>
        /// <param name="path">API Path: "v1/devices"</param>
        /// <param name="query">API Query</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a JSON string</returns>
        /// Throws <exception cref="ArgumentNullException"> if path or query are null</exception>
        private async Task<string> QueryAmbientWeatherApiAsync(string path, string query, CancellationToken cancellationToken)
        {
            // Build the full API Uri
            var builder = new UriBuilder
            {
                Scheme = BaseAddress.Scheme, 
                Host = BaseAddress.Host, 
                Path = path,
                Query = query
            };

            var request = new HttpRequestMessage(HttpMethod.Get, builder.Uri);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");

            // Get and return a JSON string from the Ambient Weather API
            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);

            return await response.Content.ReadAsStringAsync();
        }
    }
}