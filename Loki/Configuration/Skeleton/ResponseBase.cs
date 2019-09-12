using System.Net;
using Newtonsoft.Json;

namespace Loki.Configuration.Skeleton {
    [JsonConverter(typeof(BaseConverter))]
    abstract class ResponseBase {
        [JsonRequired]
        public virtual string Type { get; }

        [JsonRequired]
        public string Name { get; set; } = "LokiResponse";
        
        [JsonRequired]
        public string Url { get; set; }

        internal abstract void ProcessResponse(HttpListenerResponse response);
    }
}
