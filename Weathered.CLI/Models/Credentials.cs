using System.Collections.Generic;

namespace Weathered.Models
{
    public class Credentials
    {
        /// <summary>
        /// Database Connection String
        /// </summary>
        public string DbConnection { get; set; }
        
        /// <summary>
        /// Sentry.IO DSN String. See Sentry.IO Client Keys DSN connection strings.
        /// </summary>
        public string SentryIOToken { get; set; }
        
        /// <summary>
        /// Weather Station MAC Address. Found Here: https://ambientweather.net/devices
        /// </summary>
        public string MacAddress { get; set; }
        
        /// <summary>
        /// Ambient Weather API Key. Found Here: https://ambientweather.net/account
        /// </summary>
        public List<string> ApiKey { get; set; }
        
        /// <summary>
        /// Account Application Key. Found Here: https://ambientweather.net/account
        /// </summary>
        public string ApplicationKey { get; set; }
    }
}