using System.IO;
using Loki.Configuration.Responses;
using Loki.Configuration.Skeleton;
using Newtonsoft.Json;

namespace Loki.Configuration {
    static class ConfigManager {
        internal static Config Settings { get; set; } = new Config();

        internal static void Default() {
            Settings = new Config();

            var resp = new TextResponse();
            resp.Url = "https://google.com";
            resp.Text = "you got pranked yo";
            resp.Conditions.Add(new Condition { ResponseEquals = "neverhappens" });

            var resp2 = new FileResponse();
            resp2.Url = "https://bing.com";
            resp2.Path = "response.bin";

            Settings.Responses.Add(resp);
            Settings.Responses.Add(resp2);

            /*Settings.Responses.Add(new FileResponse { FilePath = "response.bin", Url = "https://google.com" });

            //Sorry bing...
            Settings.Responses.Add(new TextResponse { Text = "<script>document.location = \"https://duckduckgo.com\"</script>", Url = "https://bing.com" });*/
        }

        internal static void Add(ResponseBase resp) => Settings.Responses.Add(resp);
        internal static void Remove(ResponseBase resp) => Settings.Responses.Remove(resp);
        internal static void RemoveAt(int index) => Settings.Responses.RemoveAt(index);

        internal static void Save(string path) {
            if (path == string.Empty)
                return;

            File.WriteAllText(path, JsonConvert.SerializeObject(Settings, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        internal static void Load(string path) {
            if (path == string.Empty)
                return;

            Settings = JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
        }
    }
}
