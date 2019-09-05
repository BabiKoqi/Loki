using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Loki.Configuration {
    class Config {
        [JsonProperty("name")]
        internal string Name { get; set; }
        
        [JsonProperty("responses")]
        internal IList<Response> Responses { get; set; }

        internal void Save(string path) => File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        internal static Config Load(string path) => JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
    }
}