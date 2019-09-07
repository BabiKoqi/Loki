using System;
using Loki.Configuration;
using Loki.Interface.Controls;

namespace Loki.Interface {
    class MainMenu : Menu {
        internal MainMenu(string name = "Loki v0.0.1 \\ALPHA/ | PRIVATE") : base(name) {
            ConfigManager.Default();
            Options.Add(new ConfigMenu());
        }
    }
}