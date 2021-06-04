using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QuickBooksSharp
{
    public class TokenResponse
    {
        /// <summary>
        /// "bearer"
        /// </summary>
        public string token_type { get; set; } = default!;

        public string access_token { get; set; } = default!;

        public string refresh_token { get; set; } = default!;

        /// <summary>
        /// duration in seconds
        /// </summary>
        [JsonConverter(typeof(NumberTimespanConverter))]
        public TimeSpan expires_in { get; set; }

        /// <summary>
        /// duration in seconds
        /// </summary>
        [JsonConverter(typeof(NumberTimespanConverter))]
        public TimeSpan x_refresh_token_expires_in { get; set; }

        public string? id_token { get; set; }
    }
}
