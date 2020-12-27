using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Weathered.API;
using Weathered.API.Models;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Weathered
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            // Sample code. CLI will go here eventually
            var serviceProvider = BuildDI();
            BuildLogger();
            
            Log.Verbose("Starting application");

            // do the actual work here
            //var bar = serviceProvider.GetService<IAmbientWeatherRestService>();
            /*var result = await bar.FetchDeviceDataAsync
            (
                "", 
                "", 
                "",
                null,
                CancellationToken.None,
                2
            );*/

            Log.Verbose("All done!");

            var rootCommand = new RootCommand
            {
                new Option<bool>(new[] {"--devices", "-d"}, () => false, "Fetch data from the Ambient Weather Device API. Requires Device Mac Address") { Argument = new Argument<bool>(), IsRequired = false},
                new Option<bool>(new[] {"--user", "-u"}, () => false, "Fetch a list of the user's devices, along with the latest data reported by each device") { Argument = new Argument<bool>(), IsRequired = false},
                new Option<string?>(new[] {"--mac-address", "-m"}, () => null, "Fetch data from the Ambient Weather Device API. Requires Device Mac Address") { Argument = new Argument<string?>(), IsRequired = false},
                new Option<string?>(new[] {"--api-key", "-api"}, () => null, "Ambient Weather API Key") { Argument = new Argument<string?>(), IsRequired = false},
                new Option<string?>(new[] {"--application-key", "-app"}, () => null, "Ambient Weather Application Key") { Argument = new Argument<string?>(), IsRequired = false }, 
                new Option<string?>(new[] {"--log-file"}, () => null, "Write logs to file") { Argument = new Argument<string?>(), IsRequired = false },
            };
            
            rootCommand.Description = "Weathered CLI for Ambient Weather API";
            
            rootCommand.Handler = CommandHandler.Create<bool, bool, string?, string?, string?, string?>(async (devices, user, macAddress, apiKey, applicationKey, logFile) =>
            {
                while (!devices && !user)
                {
                    Console.WriteLine();
                    Log.Warning("API Selection Flag not specified. Please select \"--devices\" to query a device's data or \"--user\" to query a list of devices associated with your account");
                    
                    Console.Write("Do you wanted to enable the \"--device\" flag? (Y/n): ");
                    var deviceResult = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(deviceResult) || deviceResult.ToLower() is "y")
                    {
                        devices = true;
                    }
                    else if (deviceResult.ToLower() is not "n")
                    {
                        Log.Warning("Invalid Input" + Environment.NewLine);
                        continue;
                    }

                    Console.Write("Do you wanted to enable the \"--user\" flag? (Y/n): ");
                    var userResult = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userResult) || userResult.ToLower() is "y")
                    {
                        user = true;
                    }
                    else if (userResult.ToLower() is not "n")
                    {
                        Log.Warning("Invalid Input" + Environment.NewLine);
                        continue;
                    }
                }

                if (devices && string.IsNullOrWhiteSpace(macAddress))
                {
                    Console.WriteLine();
                    Log.Warning("Weather Station MAC Address not specified. Weather Station querying is disabled.");
                    
                    devices = false;

                    while (string.IsNullOrWhiteSpace(macAddress))
                    {
                        Console.Write("Please specify a MAC address to re-enable weather station querying: ");
                        var userResult = Console.ReadLine();
                        
                        if (string.IsNullOrWhiteSpace(userResult))
                        {
                            continue;
                        }

                        break;
                    }

                    devices = true;
                }

                if (string.IsNullOrWhiteSpace(apiKey))
                {
                    Console.WriteLine();
                    Log.Warning("API Key not specified and is required.");
                    
                    while (string.IsNullOrWhiteSpace(apiKey))
                    {
                        Console.Write("Provide an API Key: ");
                        apiKey = Console.ReadLine();
                    }
                }

                if (string.IsNullOrWhiteSpace(applicationKey))
                {
                    Console.WriteLine();
                    Log.Warning("Application Key not specified and is required.");
                    
                    while (string.IsNullOrWhiteSpace(applicationKey))
                    {
                        Console.Write("Provide an Application Key: ");
                        applicationKey = Console.ReadLine();
                    }
                }

                Console.WriteLine();
                Log.Debug("Executing query...");
                
                // await Run(devices!, user!, splitChannels, combine);
            });
            
            await rootCommand.InvokeAsync(args);

            Console.ReadKey();

            return 0;

            // Note that the CLI portion doesn't actually do anything 
        }

        private static void BuildLogger()
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
        }

        private static ServiceProvider BuildDI()
        {
            // setup our DI
            return new ServiceCollection()
                .AddSingleton<IAmbientWeatherRestService, AmbientWeatherRestService>()
                .BuildServiceProvider();
        }
    }
}