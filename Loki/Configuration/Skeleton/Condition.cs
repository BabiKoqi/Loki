using Newtonsoft.Json;

namespace Loki.Configuration.Skeleton {
    class Condition {
        public string ResponseEquals { get; set; }

        public string ResponseContains { get; set; }

        public string ResponseEqualsFile { get; set; }
    }
}