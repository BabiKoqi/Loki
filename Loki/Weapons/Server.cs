using System;
using System.Linq;
using System.Net;
using System.Threading;
using Loki.Configuration;

namespace Loki.Weapons {
    static class Server {
        static bool _running;
        static readonly HttpListener _listener = new HttpListener();
    
        internal static void Start() {
            //Add prefixes???
            _running = true;
            _listener.Prefixes.Add($"http://loki:80/");
            _listener.Start();
            new Thread(Loop).Start();
        }

        /*internal static void Stop() {
            _running = false;
            _listener.Stop();
        }*/

        static Config _settings = ConfigManager.Settings;
        static void Loop() {
            while (_running) {
                var ctx = _listener.GetContext();

                var req = ctx.Request;
                var handler = _settings.Responses.SingleOrDefault(r => string.Equals(r.Name, req.Url.AbsolutePath, StringComparison.OrdinalIgnoreCase));
                if (handler == null)
                    return;

                handler.ProcessResponse(ctx.Response);
            }
        }
    }
}