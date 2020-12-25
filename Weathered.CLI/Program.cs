using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Weathered.API;
using Weathered.API.Models;
using Weathered.Configuration;

namespace Weathered
{
    class Program
    {
        static void Main(string[] args)
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
                    .WriteTo.Async(x => x.Console(
                        restrictedToMinimumLevel: LogEventLevel.Verbose,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} <{ThreadId}>{NewLine}{Exception}"))
                    .WriteTo.Async(x => x.File(
                        Path.Combine("logs", "{Date}.log"), 
                        restrictedToMinimumLevel: LogEventLevel.Warning,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} <{ThreadId}>{NewLine}{Exception}", 
                        rollingInterval: RollingInterval.Day)))
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
            var serviceProvider = new ServiceCollection()
                .AddSingleton(Log.Logger)
                .AddSingleton<IAmbientWeatherRestService, AmbientWeatherRestService>()
                .AddTransient<IWeatheredConfigurationValidator, WeatheredConfigurationValidator>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger>();
            logger.Verbose("Starting application");

            // do the actual work here
            //var bar = serviceProvider.GetService<IBarService>();
            //bar.DoSomeRealWork();

            logger.Verbose("All done!");

            Console.ReadKey();
        }
    }
}