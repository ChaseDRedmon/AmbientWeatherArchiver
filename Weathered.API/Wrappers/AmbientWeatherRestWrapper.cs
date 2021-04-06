using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using Weathered.API.Models;
using Weathered.API.Models.Rest;

namespace Weathered.API.Rest
{
    public interface IAmbientWeatherRestWrapper
    {
        /// <summary>
        /// Weather Stations MAC Address. Found Here: https://ambientweather.net/devices
        /// </summary>
        string MacAddress { get; set; }
        
        /// <summary>
        /// Account API Key. Found Here: https://ambientweather.net/account
        /// </summary>
        string ApiKey { get; set; }
        
        /// <summary>
        /// Account Application Key. Found Here: https://ambientweather.net/account
        /// </summary>
        string ApplicationKey { get; set; }

        /// <summary>
        ///     Fetch Recorded Weather Data based on a Weather Station's MAC Address from the Ambient Weather API
        /// </summary>
        /// <param name="endDate">Date for Last Data Entry. Results will end here and cascade backwards through time.</param>
        /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" /></param>
        /// <param name="limit">
        ///     The amount of items to return. Maximum is 288. Items are in 5 minute increments, meaning 288 items
        ///     is 1 day's worth of data.
        /// </param>
        /// <returns>Returns a <see cref="Device" /> object.</returns>
        Task<IEnumerable<Device>> FetchDeviceDataAsync(DateTimeOffset? endDate, CancellationToken cancellationToken, int limit = 288);

        /// <summary>
        ///     Fetch Recorded Weather Data based on a Weather Station's MAC Address from the Ambient Weather API
        /// </summary>
        /// <param name="endDate">Date for Last Data Entry. Results will end here and cascade backwards through time.</param>
        /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" /></param>
        /// <param name="limit">
        ///     The amount of items to return. Maximum is 288. Items are in 5 minute increments, meaning 288 items
        ///     is 1 day's worth of data.
        /// </param>
        /// <returns>Returns a JSON string</returns>
        Task<string> FetchDeviceDataAsJsonAsync(DateTimeOffset? endDate, CancellationToken cancellationToken, int limit = 288);

        /// <summary>
        ///     Fetch a list of devices under the user's account and the most recent weather data for each device
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" /></param>
        /// <returns>Returns a <see cref="Device" /> object.</returns>
        Task<IEnumerable<UserDevice>> FetchUserDevicesAsync(CancellationToken cancellationToken);

        /// <summary>
        ///     Fetch a list of devices under the user's account and the most recent weather data for each device
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" /></param>
        /// <returns>Returns a JSON string</returns>
        Task<string> FetchUserDevicesAsJsonAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Checks to see if there is data for the specified day
        /// </summary>
        /// <param name="dateToCheck">The date to check to see if we have data for</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DoesDeviceDataExist(DateTimeOffset? dateToCheck, CancellationToken cancellationToken);
    }

    public class AmbientWeatherRestWrapper : IAmbientWeatherRestWrapper
    {
        private static readonly HttpClient Client = new HttpClient();

        private static Uri BaseAddress { get; } = new Uri("https://api.ambientweather.net/");

        private readonly ILogger? _log;

        /// <summary>
        ///     Creates a new <see cref="AmbientWeatherRestWrapper" /> and initializes the base address for the Ambient Weather API
        /// </summary>
        public AmbientWeatherRestWrapper(string macAddress, string apiKey, string applicationKey, ILogger logger): this(macAddress, apiKey, applicationKey)
        {
            _log = logger.ForContext<AmbientWeatherRestWrapper>();
        }
        
        public AmbientWeatherRestWrapper(string macAddress, string apiKey, string applicationKey)
        {
            MacAddress = macAddress;
            ApiKey = apiKey;
            ApplicationKey = applicationKey;
        }

        /// <inheritdoc cref="FetchDeviceDataAsync" />
        public async Task<IEnumerable<Device>> FetchDeviceDataAsync(DateTimeOffset? endDate, CancellationToken cancellationToken, int limit = 288)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(MacAddress))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(MacAddress));
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ApiKey));
            if (string.IsNullOrWhiteSpace(ApplicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ApplicationKey));
            if (limit <= 0)
                return Enumerable.Empty<Device>();
            
            // Fetch the JSON string
            var json = await FetchDeviceDataAsJsonAsync(endDate, cancellationToken, limit);

            var data = JsonConvert.DeserializeObject<IEnumerable<Device>>(json);
            return data;
        }

        /// <inheritdoc cref="FetchDeviceDataAsJsonAsync" />
        public async Task<string> FetchDeviceDataAsJsonAsync(DateTimeOffset? endDate, CancellationToken cancellationToken, int limit = 288)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(MacAddress))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(MacAddress));
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ApiKey));
            if (string.IsNullOrWhiteSpace(ApplicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ApplicationKey));
            if (limit <= 0)
                return string.Empty;
            
            // Build our query
            var path = $"v1/devices/{MacAddress}";
            var query = $"?apiKey={ApiKey}&applicationKey={ApplicationKey}";

            query += $"&endDate={endDate?.ToUniversalTime().ToUnixTimeMilliseconds().ToString()}";
            query += $"&limit={limit.ToString()}";

            // Query the Ambient Weather API
            var json = await QueryAmbientWeatherApiAsync(path, query, cancellationToken);

            return json;
        }

        /// <inheritdoc cref="FetchUserDevicesAsync" />
        public async Task<IEnumerable<UserDevice>> FetchUserDevicesAsync(CancellationToken cancellationToken)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ApiKey));
            if (string.IsNullOrWhiteSpace(ApplicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ApplicationKey));

            // Fetch the JSON string
            var json = await FetchUserDevicesAsJsonAsync(cancellationToken);

            var data = JsonConvert.DeserializeObject<IEnumerable<UserDevice>>(json);
            return data;
        }

        public async Task<string> FetchUserDevicesAsJsonAsync(CancellationToken cancellationToken)
        {
            // Check to see if all parameters have a non-null, non-blank/whitespace value
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ApiKey));
            if (string.IsNullOrWhiteSpace(ApplicationKey))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ApplicationKey));

            // Build our query
            const string path = "v1/devices";
            var query = $"?apiKey={ApiKey}&applicationKey={ApplicationKey}";

            // Query the Ambient Weather API
            var json = await QueryAmbientWeatherApiAsync(path, query, cancellationToken);

            return json;
        }
        
        public async Task<bool> DoesDeviceDataExist(DateTimeOffset? dateToCheck, CancellationToken cancellationToken)
        {
            var json = await FetchDeviceDataAsJsonAsync(dateToCheck, cancellationToken, 1);

            // The Ambient Weather API returns HTTP 200 and an empty JSON Array when data does not exist for a given day.
            return json.Length != 2;
        }

        public string MacAddress { get; set; }
        public string ApiKey { get; set; }
        public string ApplicationKey { get; set; }

        /// <summary>
        ///     Submits a request to the Ambient Weather API
        /// </summary>
        /// <param name="path">API Path: "v1/devices"</param>
        /// <param name="query">API Query</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a JSON string</returns>
        /// Throws
        /// <exception cref="ArgumentNullException"> if path or query are null</exception>
        private async Task<string> QueryAmbientWeatherApiAsync(string path, string query,
            CancellationToken cancellationToken)
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
            var response = await Client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);

            return await response.Content.ReadAsStringAsync();
        }
    }
}