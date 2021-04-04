using System;
using System.Threading.Tasks;
using MediatR;
using Weathered.API.Rest;

namespace Weathered.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Download and write the entire history of the weather station's data to the database
        /// </summary>
        /// <returns></returns>
        public bool WriteDeviceHistoryToDatabase();
    }

    public class WeatherService : IWeatherService
    {
        private readonly IAmbientWeatherRestWrapper _ambientWeather;

        public WeatherService(IAmbientWeatherRestWrapper ambientWeather)
        {
            _ambientWeather = ambientWeather;
        }

        public bool WriteDeviceHistoryToDatabase()
        {
            throw new NotImplementedException();
        }
    }
}