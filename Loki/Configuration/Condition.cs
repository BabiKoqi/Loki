using Newtonsoft.Json;

namespace Loki.Configuration {
    class Condition {
        [JsonProperty("responseEquals")]
        internal string ResponseEquals { get; set; }
        
        [JsonProperty("responseContains")]
        internal string ResponseContains { get; set; }
        
        [JsonProperty("responseEqualsFile")]
        internal string ResponseEqualsFile { get; set; }
    }
}