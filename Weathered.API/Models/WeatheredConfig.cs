namespace Weathered.API.Models
{
    public class WeatheredConfig
    {
        /// <summary>
        /// Database Connection String
        /// </summary>
        public string DbConnection { get; set; }
        
        /// <summary>
        /// Sentry.IO DSN String. See Sentry.IO Client Keys DSN connection strings.
        /// </summary>
        public string SentryIOToken { get; set; }
    }
}