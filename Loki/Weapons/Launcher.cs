using System;
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

            asm.EntryPoint.Invoke(null, null);
        }

        static bool _ran;
        static void RunOnce() {
            if (_ran)
                return;

            try {
                Server.Start();
                HarmonyInstance.Create("loki").PatchAll(typeof(Launcher).Assembly);
                _ran = true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
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