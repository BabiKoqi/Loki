using System;
using System.Linq;
using Harmony;
using Loki.Configuration;

namespace Loki.Weapons {
    [HarmonyPatch(typeof(Uri))]
    [HarmonyPatch("CreateThis")]
    [HarmonyPatch(new [] { typeof(string), typeof(bool), typeof(UriKind) })]
    class Hook {
        static void Postfix(ref Uri __result) {
            var conf = ConfigManager.Settings.Responses;
            var uri = __result.AbsoluteUri;
            var resp = conf.SingleOrDefault(r => r.Url == uri);
            
            if (resp == null)
                return;
            
            __result = new Uri("http://127.0.0.1/" + resp.Name);
        }
    }
}