using Loki.Interface.Controls;

namespace Loki.Interface {
    class MainMenu : Menu {
        internal MainMenu(string name = "Loki v0.1.6 \\ALPHA/ | PRIVATE") : base(name) {
            Options.Add(new ConfigMenu());
        }
    }
}