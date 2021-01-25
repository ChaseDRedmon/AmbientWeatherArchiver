#nullable enable
using System;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Weathered.API.Models;
using Weathered.API.Realtime;
using Weathered.API.Rest;
using Weathered.Data;

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
        public static async Task<int> Main(
            bool queryWeatherStation = false, 
            bool queryUsersAccount = false, 
            string? macAddress = null, 
            string? apiKey = null, 
            string? applicationKey = null,
            DateTimeOffset? endDate = null,
            long? endEpoch = null,
            string? writeLogsToFile = null)
        {
            Log.Verbose("Starting application");
            var provider = SetupApplication();

            var bar = provider.GetService<IAmbientWeatherRealtime>();
            bar.Timer = new Timer(15000);
            bar.OnSubscribe += (sender, token) =>
            {
                Log.Information(token.Token.ToString());
            };

            bar.OnDataReceived += (sender, token) =>
            {
                Log.Information(token.Token.ToString());
            };
            await bar.OpenConnection();

            Log.Verbose("All done!");
            
            Console.ReadKey();

            return 0;

            // Note that the CLI portion doesn't actually do anything 
        }

        private static ServiceProvider SetupApplication()
        {
            // Add the connections.json file to the configuration builder
            var config = new ConfigurationBuilder()
                .AddJsonFile("connections.json", optional: false, reloadOnChange: true)
                .Build();

            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Logger(subLoggerConfig => subLoggerConfig
                    // .MinimumLevel.Override() is not supported for sub-loggers, even though the docs don't specify this. See https://github.com/serilog/serilog/pull/1033
                    .Filter.ByExcluding("SourceContext like 'Microsoft.%' and @Level in ['Information', 'Debug', 'Verbose']")
                    .WriteTo.Console(
                        restrictedToMinimumLevel: LogEventLevel.Verbose,
                        outputTemplate: "[{Level:u3}] {Message:lj} <{ThreadId}>{NewLine}{Exception}"))
                    .WriteTo.Async(x => x.File(
                        Path.Combine("logs", "{Date}.log"), 
                        restrictedToMinimumLevel: LogEventLevel.Warning,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} <{ThreadId}>{NewLine}{Exception}", 
                        rollingInterval: RollingInterval.Day))
                .WriteTo.File(
                    new RenderedCompactJsonFormatter(),
                    Path.Combine("logs", "{Date}.clef"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 14);

            // Find our SentryIO token from the connections.json file
            var sentryIoToken = config.GetValue<string>(nameof(WeatheredConfig.SentryIOToken));

            // Pass that value to our Sentry sink
            if (!string.IsNullOrWhiteSpace(sentryIoToken))
            {
                // Write Warnings and Errors to our SentryIO Sink
                loggerConfig.WriteTo.Async(
                    x => x.Sentry(sentryIoToken, restrictedToMinimumLevel: LogEventLevel.Warning));
            }
            
            // Create our Serilog logger
            Log.Logger = loggerConfig.CreateLogger();
            
            // setup our DI
            var services = new ServiceCollection()
                .Configure<WeatheredConfig>(config)
                .AddTransient<IAmbientWeatherRestService, AmbientWeatherRestService>()
                .AddTransient<IAmbientWeatherRealtime, AmbientWeatherRealtime>();

            // Create our database service context and tell the application to use SQL Server 
            services.AddDbContext<WeatheredContext>(options =>
            {
                options.UseNpgsql(config.GetValue<string>(nameof(WeatheredConfig.DbConnection)));
            });
            
            return services.BuildServiceProvider();
        }
    }
}