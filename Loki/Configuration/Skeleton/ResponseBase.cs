using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Loki.Configuration.Skeleton {
    [JsonConverter(typeof(BaseConverter))]
    abstract class ResponseBase {
        [JsonRequired]
        public string Name { get; set; } = "LokiResponse";

        public virtual string Type { get; }

        [JsonRequired]
        public virtual string Url { get; set; }

        //public virtual IList<Condition> Conditions { get; set; } = new List<Condition>();
    }
}
