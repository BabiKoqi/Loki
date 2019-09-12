﻿using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Harmony;
using Loki.Configuration;

namespace Loki.Weapons {
    static class Launcher {
        static Launcher() => HarmonyInstance.Create("loki").PatchAll(typeof(Launcher).Assembly);

        internal static Assembly RealAssembly;
        
        internal static void Go() {
            var asm = TryLoadAssembly();
            if (asm == null)
                return;

            RealAssembly = asm;

            Console.WriteLine("Starting target...");
            new Thread(() => {
                Thread.Sleep(1000); //Make sure ^ can be read
                asm.EntryPoint.Invoke(null, new object[] { new string[] {  } }); //This will need to be changed probably...
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