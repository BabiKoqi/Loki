using System.Collections.Generic;
using Newtonsoft.Json;
using Loki.Configuration.Skeleton;

namespace Loki.Configuration {
    class Config {
        [JsonRequired]
        public string Name { get; set; } = "LokiConfig1";

        [JsonRequired]
        public string Author { get; set; } = "xsilent007";

        [JsonRequired]
        public string ExecutablePath { get; set; }

        //This can be used if Assembly.EntryPoint isn't the real entrypoint
        public int RealEntryPointMDToken { get; set; }

        [JsonRequired]
        public IList<ResponseBase> Responses { get; set; } = new List<ResponseBase>();
    }
}