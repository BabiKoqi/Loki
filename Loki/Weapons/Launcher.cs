using System.IO;
using System.Reflection;
using Harmony;
using Loki.Configuration;

namespace Loki.Weapons {
    static class Launcher {
        internal static void Launch() {
            RunOnce();
            var asm = TryLoadAssembly();
            if (asm == null)
                return;
        }

        static bool _ran;
        static void RunOnce() {
            if (_ran)
                return;

            //Server.Start();
            HarmonyInstance.Create("loki").PatchAll(typeof(Launcher).Assembly);
            _ran = true;
        }

        static Assembly TryLoadAssembly() {
            try {
                return Assembly.LoadFile(Path.GetFullPath(ConfigManager.Settings.ExecutablePath));
            }
            catch {
                return null;
            }
        }
    }
}