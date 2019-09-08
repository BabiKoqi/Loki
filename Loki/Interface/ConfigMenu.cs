using Loki.Configuration;
using Loki.Interface.Controls;
using Loki.Interface.Skeleton;

namespace Loki.Interface {
    class ConfigMenu : Menu {
        internal ConfigMenu() : base("Configuration") {
            Options.Add(new Button("Load config", (sender) => {
                ConfigManager.Load(Misc.Prompt("Path to config file?", $"LokiConfig1.json"));
                AddResponses();
            }));
            Options.Add(new Button("Save config", (sender) => {
                ConfigManager.Save(Misc.Prompt("Where would you like to save the config?", $"{_name.Text}.json"));
            }));
            Options.Add(new AddNewResponseMenu(this));

            Options.Add(new Label(new string('=', 16)));
            Options.Add(_name = new TextField("Name:", ConfigManager.Settings.Name ?? "LokiConfig1"));
            Options.Add(_author = new TextField("Author:", ConfigManager.Settings.Author ?? "xsilent007"));
            Options.Add(_exePath = new TextField("Executable path:", ConfigManager.Settings.ExecutablePath ?? "Program.exe"));
            Options.Add(new Label(new string('=', 16)));
        }

        readonly TextField _name;
        readonly TextField _author;
        readonly TextField _exePath;

        internal override void DrawMenu() {
            AddResponses();
            ForceRedraw = true;
            base.DrawMenu();

            ConfigManager.Settings.Name = _name.Text;
            ConfigManager.Settings.Author = _author.Text;
            ConfigManager.Settings.ExecutablePath = _exePath.Text;
        }

        void RemoveExceptFirstX(int x) {
            for (;Options.Count > x;) {
                Options.RemoveAt(x);
            }
        }

        internal void AddResponses() {
            RemoveExceptFirstX(8);
            foreach (var resp in ConfigManager.Settings.Responses)
                Options.Add(new ResponseMenu(this, resp));
        }
    }
}
