using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Weathered.API.Models.Rest;
using Weathered.API.Rest;
using Serilog;

namespace Weathered.API
{
    public interface IAmbientWeather
    {
        /// <summary>
        /// Fetch the device's history between now and the end date, relative to the UTC timezone
        /// </summary>
        /// <param name="endDate">
        /// The endDate where weather events will stop being collected, relative to the UTC timezone
        /// An end date of February 20th, 2021 will fetch February 19th, 00:05 - 23:55 UTC
        /// </param>
        /// <param name="limit">
        /// Returns the 
        /// The number of weather events, limited to 288. Data may be stored in 5 or 30 minute increments.
        /// If information is stored every 5 minutes, 288 events translates to one (1), 24 hour day.
        /// </param>
        /// <param name="includeToday">Include Today's Weather Information in the return results.</param>
        /// <returns>Returns an <see cref="IEnumerable{Device}" /></returns>
        public IAsyncEnumerable<IEnumerable<Device>> FetchDeviceHistory(DateTimeOffset? startDate, DateTimeOffset? endDate, CancellationToken token, bool sliceTheListFromTheBeginningOfTheList = false, int limit = 288);

        /// <summary>
        /// Fetch the device's history between now and the number of days specified, relative to UTC
        /// </summary>
        /// <param name="daysGoneBack">How many days we should go back in time to retrieve information from the weather station</param>
        /// <param name="includeToday">Include Today's Weather Information in the return results.</param>
        /// <returns></returns>
        public IAsyncEnumerable<IEnumerable<Device>> FetchDeviceHistory(TimeSpan numberOfDaysToGoBack, CancellationToken token, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288);

        /// <inheritdoc cref="FetchDeviceHistory(TimeSpan, bool)" />
        public IAsyncEnumerable<IEnumerable<Device>> FetchDeviceHistory(int numberOfDaysToGoBack, CancellationToken token, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288);
    }

    public class AmbientWeather : IAmbientWeather
    {
        private IAmbientWeatherRestWrapper _restWrapper;
        private readonly ILogger _log;

        public AmbientWeather(string? apiKey, string? applicationKey, string? macAddress, ILogger logger): this(apiKey, applicationKey, macAddress)
        {
            _log = logger.ForContext<AmbientWeather>();
        }
        
        public AmbientWeather(string? apiKey, string? applicationKey, string? macAddress)
        {
            var services = new ServiceCollection();
            services.AddTransient<IAmbientWeatherRestWrapper>(x =>
                new AmbientWeatherRestWrapper(macAddress, apiKey, applicationKey));
            
            var provider = services.BuildServiceProvider();
            _restWrapper = provider.GetService<IAmbientWeatherRestWrapper>();
        }

        /// <inheritdoc cref="FetchDeviceHistory(System.DateTimeOffset,System.DateTimeOffset,int,bool)" />
        public async IAsyncEnumerable<IEnumerable<Device>> FetchDeviceHistory(DateTimeOffset? startDate, DateTimeOffset? endDate, CancellationToken token, bool sliceTheListFromTheBeginningOfTheList = false, int limit = 288)
        {
            _log.Verbose($"Fetching device history from: {startDate?.ToUniversalTime().ToString()} to {endDate?.ToUniversalTime().ToString()}");
            
            // The start date where we start querying
            var start = startDate;
            
            // The end date where we stop querying
            var end = endDate;
            
            var current = start;
            
            var queryLimit = limit;

            if (sliceTheListFromTheBeginningOfTheList)
                limit = 288;

            // Walk the API 1 day at a time until we reach the end date
            while (current <= end)
            {
                var result = await _restWrapper.FetchDeviceDataAsync(current, token, limit);

                yield return sliceTheListFromTheBeginningOfTheList ? result.TakeLast(queryLimit) : result;

                current = current?.AddDays(1);
            }
        }

        /// <inheritdoc cref="FetchDeviceHistory(TimeSpan, bool)" />
        public async IAsyncEnumerable<IEnumerable<Device>> FetchDeviceHistory(TimeSpan numberOfDaysToGoBack, CancellationToken token, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288)
        {
            if (numberOfDaysToGoBack.Days <= 0)
                throw new ArgumentException("Value must be greater than or equal to 1", nameof(numberOfDaysToGoBack));

            var result = FetchDeviceHistory(numberOfDaysToGoBack.Days, token, sliceTheListFromTheBeginningOfTheList, includeToday, limit);

            await foreach (var x in result)
            {
                yield return x;
            }
        }

        /// <inheritdoc cref="FetchDeviceHistory(int, bool)" />
        public async IAsyncEnumerable<IEnumerable<Device>> FetchDeviceHistory(int numberOfDaysToGoBack, CancellationToken token, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288)
        {
            if(numberOfDaysToGoBack <= 0)
                throw new ArgumentException("Value must be greater than or equal to 1", nameof(numberOfDaysToGoBack));

            var queryLimit = limit;

            // Ambient weather always places the most recent event as the first element in the list.
            // Older events (from earlier in the day) are at the "bottom" of the list, meaning we use TakeLate to fetch from the start of the day
            // We need to query the highest amount that we can (which is 288 elements) to fetch the full day, so that we can work from the bottom up
            // We don't know how many elements are actually returned until we query
            if (sliceTheListFromTheBeginningOfTheList)
                limit = 288;
            
            var queryDate = includeToday ? DateTime.UtcNow : DateTime.UtcNow.AddDays(-1);
            
            for (var i = 0; i <= numberOfDaysToGoBack; i++)
            {
                var result = await _restWrapper.FetchDeviceDataAsync(queryDate, token, limit);

                yield return sliceTheListFromTheBeginningOfTheList ? result.TakeLast(queryLimit) : result;
                
                queryDate = queryDate.AddDays(-1);
            }
        }
    }
}