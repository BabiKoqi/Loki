using Newtonsoft.Json;

namespace Loki.Configuration {
    abstract class Response {
        [JsonProperty("when")]
        internal Time When { get; set; }
        
        [JsonProperty("type")]
        internal ResponseType Type { get; set; }
    }

    enum Time {
        Before,
        After
    }

    enum ResponseType {
        Text,
        File
    }
}