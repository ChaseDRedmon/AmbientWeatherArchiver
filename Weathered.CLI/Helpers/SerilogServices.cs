using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SharpRaven.Data.Context;

namespace Weathered.Helpers
{
    public static class SerilogServices
    {
        public static IServiceCollection AddSerilogServices(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            AppDomain.CurrentDomain.ProcessExit += (sender, args) => Log.CloseAndFlush();

            return services.AddSingleton(Log.Logger);
        }
    }
}