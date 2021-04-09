using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Weathered.API;
using Weathered.API.Rest;
using Weathered.Data;

namespace Weathered.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Download and write the entire history of the weather station's data to the database
        /// </summary>
        /// <returns></returns>
        public Task<bool> WriteDeviceHistoryToDatabase();
    }

    public class WeatherService : IWeatherService
    {
        private readonly IAmbientWeather _ambientWeather;
        private readonly WeatheredContext _weatheredContext;
        private readonly ILogger _logger;

        public WeatherService(WeatheredContext context, IAmbientWeather ambientWeather, ILogger logger)
        {
            _ambientWeather = ambientWeather;
            _weatheredContext = context;
            _logger = logger;
        }

        public async Task<bool> WriteDeviceHistoryToDatabase()
        {
            var dto = new DateTimeOffset(2021, 3, 20, 0, 0, 0, TimeSpan.Zero);
            var today = DateTimeOffset.UtcNow;

            var difference = today - dto;
            var dayCount = 0;
            
            _logger.Information($"There are {difference.Days.ToString()} days total");

            var result = _ambientWeather.FetchDeviceHistory(dto, DateTimeOffset.UtcNow,
                CancellationToken.None);

            await foreach (var element in result)
            {
                _logger.Information($"Day: {(++dayCount).ToString()}");
                
                foreach (var weatherEvent in element)
                {
                    await _weatheredContext.AddAsync(weatherEvent);
                }

                await _weatheredContext.SaveChangesAsync();
            }
            
            return true;
        }
    }
}