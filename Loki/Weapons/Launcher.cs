using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Harmony;
using Loki.Configuration;

namespace Loki.Weapons {
    static class Launcher {
        static Launcher() => HarmonyInstance.Create("loki").PatchAll(typeof(Launcher).Assembly);
        
        internal static void Go() {
            var asm = TryLoadAssembly();
            if (asm == null)
                return;

            Console.WriteLine("Starting target...");
            new Thread(() => {
                Thread.Sleep(2500); //Make sure ^ can be read
                asm.EntryPoint.Invoke(null, null);
            }) { IsBackground = true }.Start();

            Server.Go();
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