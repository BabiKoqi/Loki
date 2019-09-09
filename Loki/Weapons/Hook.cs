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
        static void Postfix(Uri __instance, UriParser ___m_Syntax) {
            var conf = ConfigManager.Settings.Responses;
            var uri = __instance.IdnHost + __instance.LocalPath;
            Console.WriteLine(uri);
            var resp = conf.SingleOrDefault(r => r.Url == uri);
            
            if (resp == null)
                return;

            //Get all fields required to spoof URI
            var inst = __instance.GetType();
            var inst_m_Info = GetField(inst, "m_Info").GetValue(__instance);
            
            var m_Info = inst_m_Info.GetType();

            var Host = GetField(m_Info, "Host"); //Used for direct IP addresses
            var DnsSafeHost = GetField(m_Info, "DnsSafeHost"); //Used for URLs that need to be run through DNS first

            var inst_Offset = GetField(m_Info, "Offset").GetValue(inst_m_Info);
            var Port = GetField(inst_Offset.GetType(), "PortValue"); //We need to force this to be 80

            var m_DefaultPort = GetField(___m_Syntax.GetType().BaseType, "m_Port"); //Force this to be 80 as well

            //Spoof URI
            Host.SetValue(inst_m_Info, "loki");
            DnsSafeHost.SetValue(inst_m_Info, "loki");

            Port.SetValue(inst_Offset, (ushort)80);

            m_DefaultPort.SetValue(___m_Syntax, 80);
        }

        static FieldInfo GetField(Type type, string name) => type.GetField(name, (BindingFlags)(-1));
    }
}