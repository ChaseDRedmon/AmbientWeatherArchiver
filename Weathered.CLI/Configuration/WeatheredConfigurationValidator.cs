using System;
using Microsoft.Extensions.Options;
using Serilog;
using Weathered.API.Models;

namespace Weathered.Configuration
{
    public interface IWeatheredConfigurationValidator
    {
        Action Configure(Action next);
    }

    public class WeatheredConfigurationValidator : IWeatheredConfigurationValidator
    {
        private readonly WeatheredConfig _config;

        public WeatheredConfigurationValidator(IOptions<WeatheredConfig> config)
        {
            Log.Verbose("Weathered.CLI Config Validator Hit");
            _config = config.Value;
        }

        public Action Configure(Action next)
        {
            
            
            if (string.IsNullOrWhiteSpace(_config.DbConnection))
            {
                Log.Fatal("The DbConnection string was not set - this is fatal! Check the config");
            }

            if (string.IsNullOrWhiteSpace(_config.SentryIOToken))
            {
                Log.Warning("The SentryIOToken was not set. SentryIO logging disabled. Check the config.");
            }

            return next;
        }
    }
}