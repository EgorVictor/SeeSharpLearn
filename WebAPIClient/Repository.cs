using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPIClient
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }

        public DateTime LastPush => LastPushUtc.ToLocalTime();
    }
}
