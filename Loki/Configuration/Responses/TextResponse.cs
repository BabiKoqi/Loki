using System.Net;
using System.Text;
using Loki.Configuration.Skeleton;
using Newtonsoft.Json;

namespace Loki.Configuration.Responses {
    class TextResponse : ResponseBase {
        public override string Type => "Text";

        [JsonRequired]
        public string Text { get; set; }

        public override string ToString() => $"TextResponse [ Url: '{Url}' | Text: '{Text}' ]";

        internal override void ProcessResponse(HttpListenerResponse response) {
            var stream = response.OutputStream;
            response.ContentEncoding = response.ContentEncoding ?? Encoding.UTF8;
            var txt = response.ContentEncoding.GetBytes(Text);
            stream.Write(txt, 0, txt.Length);
        }
    }
}
