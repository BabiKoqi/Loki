using Newtonsoft.Json;

namespace Loki.Configuration {
    class TextResponse : Response {
        [JsonProperty("text")]
        internal string Text { get; set; }

        internal override ResponseType Type => ResponseType.Text;
    }
}