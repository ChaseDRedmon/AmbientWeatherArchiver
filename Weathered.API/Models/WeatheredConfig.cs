using System.Collections.Generic;

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
        
        /// <summary>
        /// Weather station MAC Address
        /// </summary>
        public string MacAddress { get; set; }
        
        /// <summary>
        /// Ambient Weather API Key
        /// </summary>
        public List<string> ApiKey { get; set; }
        
        /// <summary>
        /// Ambient Weather Application Key
        /// </summary>
        public string ApplicationKey { get; set; }
    }
}