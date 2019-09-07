using Loki.Configuration.Skeleton;
using Newtonsoft.Json;

namespace Loki.Configuration.Responses {
    class FileResponse : ResponseBase {
        public override string Type => "File";

        [JsonRequired]
        public string Path { get; set; }

        public override string ToString() => $"FileResponse [ Url: '{Url}' | Path: '{Path}' ]";
    }
}
