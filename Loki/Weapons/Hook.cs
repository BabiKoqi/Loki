using System;
using System.Linq;
using System.Reflection;
using Harmony;
using Loki.Configuration;

namespace Loki.Weapons {
    [HarmonyPatch(typeof(Uri))]
    [HarmonyPatch("CreateThis")]
    [HarmonyPatch(new [] { typeof(string), typeof(bool), typeof(UriKind) })]
    class Hook {
        static void Postfix(Uri __instance) {
            var conf = ConfigManager.Settings.Responses;
            var uri = __instance.IdnHost + __instance.LocalPath;
            var resp = conf.SingleOrDefault(r => r.Url == uri);
            
            if (resp == null)
                return;

            var newuri = new Uri($"http://localhost/{__instance}");
            TakeOver(__instance, newuri);
        }
        
        static void TakeOver(object originst, object newinst) {
            var origtype = originst.GetType();
            var newtype = newinst.GetType();
            if (origtype != newtype)
                throw new InvalidOperationException("The types do not match");

            var thisfields = origtype.GetFields((BindingFlags)(-1)).OrderBy(f => f.MetadataToken).ToArray();
            var otherfields = newtype.GetFields((BindingFlags)(-1)).OrderBy(f => f.MetadataToken).ToArray();
            for (var i = 0; i < thisfields.Length; i++) {
                if (thisfields[i].IsInitOnly || thisfields[i].IsLiteral)
                    continue;
                
                otherfields[i].SetValue(originst, thisfields[i].GetValue(newinst));
            }
        }
    }
}