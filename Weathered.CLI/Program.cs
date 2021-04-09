#nullable enable
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Configuration;
using Serilog.Formatting.Compact;
using Weathered.API;
using Weathered.API.Models;
using Weathered.API.Realtime;
using Weathered.API.Rest;
using Weathered.Data;
using Weathered.Helpers;
using Weathered.Models;
using Weathered.Services;

namespace Weathered
{
    class Program
    {
        /// <param name="queryWeatherStation">Flag to query a weather station. Requires weather station MAC Address, API Key, and Application Key</param>
        /// <param name="queryUsersAccount">Flag to query the user's devices. Requires API Key and Application Key</param>
        /// <param name="macAddress">MAC Address String</param>
        /// <param name="apiKey">API Key</param>
        /// <param name="applicationKey">Application Key</param>
        /// <param name="endEpoch"></param>
        /// <param name="writeLogsToFile">Path to write application logs to a file</param>
        /// <param name="endDate"></param>
        public static async Task<int> Main()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();
            
            Log.Information("Starting application");
            var provider = SetupApplication();
            
            Log.Information("Starting to collect data from weather service.");
            var service = provider.GetRequiredService<IWeatherService>();
            var result = await service.WriteDeviceHistoryToDatabase();

            Log.Information("Finished writing information to database");
            
            Console.ReadKey();

            return 0;

            // Note that the CLI portion doesn't actually do anything yet
        }

        private static ServiceProvider SetupApplication()
        {
            // Add the connections.json file to the configuration builder
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("connections.json", optional: false, reloadOnChange: true)
                .Build();
            
            // setup our DI
            var services = new ServiceCollection()
                .Configure<Credentials>(config)
                .AddTransient<IAmbientWeatherRestWrapper, AmbientWeatherRestWrapper>()
                .AddTransient<IAmbientWeatherRealtime, AmbientWeatherRealtime>()
                .AddTransient<IAmbientWeather, AmbientWeather>()
                .AddTransient<IWeatherService, WeatherService>()
                .AddSerilogServices(config);

            // Create our database service context and tell the application to use SQL Server 
            services.AddDbContext<WeatheredContext>(options =>
            {
                options.UseNpgsql(config.GetValue<string>(nameof(Credentials.DbConnection)));
            });

            return services.BuildServiceProvider();
        }
    }
}