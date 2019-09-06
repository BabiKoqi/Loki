using Newtonsoft.Json;

namespace Loki.Configuration {
    class ExternalResponse : Response {
        [JsonProperty("externalUrl")]
        internal string ExternalUrl { get; set; }

        internal override ResponseType Type => ResponseType.External;
    }
}