using Newtonsoft.Json;

namespace Loki.Configuration {
    class FileResponse : Response {
        [JsonProperty("path")]
        internal string FilePath { get; set; }

        internal override ResponseType Type => ResponseType.File;
    }
}