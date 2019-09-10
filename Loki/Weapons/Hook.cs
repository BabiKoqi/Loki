using System;
using System.Linq;
using System.Net;
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

            dynamic exposed = new ExposedObject(__instance);
            dynamic m_Info = new ExposedObject((object)exposed.m_Info);
            dynamic Offset = new ExposedObject(m_Info.Offset);
            
            var syntax = (object)exposed.m_Syntax;
            dynamic m_Syntax = new ExposedObject(syntax, syntax.GetType().BaseType);
            
            exposed.m_String = $"http://localhost/{resp.Name}";
            
            //15 16
            m_Info.Host = "localhost"; //Used for direct IPs
            m_Info.DnsSafeHost = "localhost"; //Used for domains that need to be resolved through a DNS server first
            Offset.Path = (ushort)15;
            Offset.End = (ushort)(15 + resp.Name.Length);
            m_Syntax.m_Port = 80; //Force port to be 80
            m_Syntax.m_Scheme = "http";
            return;
        }
    }
}