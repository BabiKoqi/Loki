using System;
using Loki.Configuration;
using Loki.Interface;
using Loki.Weapons;

namespace Loki {
    static class Program {
        static void Main(string[] args) {
            if (args.Length > 0)
                LaunchWithConfig(args[0]);
            
            new MainMenu().DrawMenu();
        }

        static void LaunchWithConfig(string path) {
            ConfigManager.Load(path);
            Launcher.Go();
            Environment.Exit(0);
        }
    }
}