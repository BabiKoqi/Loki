using System.Collections.Generic;
using Newtonsoft.Json;

namespace Loki.Configuration {
    abstract class Response {
        [JsonProperty("url")]
        internal string Url { get; set; }
        
        [JsonProperty("condition")]
        internal IList<Condition> Condition { get; set; }
        
        [JsonProperty("when")]
        internal Time When { get; set; }
        
        [JsonProperty("type")]
        internal virtual ResponseType Type { get; set; }
    }

    enum Time {
        Before,
        After
    }

    enum ResponseType {
        Text,
        File,
        External
    }
}