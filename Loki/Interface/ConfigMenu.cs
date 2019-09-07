using Loki.Configuration;
using Loki.Interface.Controls;
using Loki.Interface.Skeleton;

namespace Loki.Interface {
    class ConfigMenu : Menu {
        internal ConfigMenu() : base("Configuration") {
            Options.Add(new Button("Load config", (sender) => {
                ConfigManager.Settings = null;
                ConfigManager.Load(Misc.Prompt("Path to config file?", $"LokiConfig1.json"));
            }));
            Options.Add(new Button("Save config", (sender) => {
                ConfigManager.Save(Misc.Prompt("Where would you like to save the config?", $"{ConfigManager.Settings.Name}.json"));
            }));
            Options.Add(new Button("Add new response", (sender) => { }));

            Options.Add(new Label(new string('=', 16)));
        }

        internal override void DrawMenu() {
            RemoveExceptFirstX(5);
            foreach (var resp in ConfigManager.Settings.Responses)
                Options.Add(new ResponseMenu(resp));

            base.DrawMenu();
        }

        void RemoveExceptFirstX(int x) {
            for (;Options.Count > x;) {
                Options.RemoveAt(x);
            }
        }
    }
}
