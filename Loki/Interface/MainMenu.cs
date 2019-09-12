using Loki.Configuration;
using Loki.Interface.Controls;
using Loki.Interface.Skeleton;
using Loki.Weapons;

namespace Loki.Interface {
    class MainMenu : Menu {
        internal MainMenu() : base("Loki by xsilent007 | v1.0.0 | github.com/xsilent007/Loki") {
            Options.Add(new Button("Start!", sender => {
                Launcher.Go();
                KeepDrawing = false;
            }));
            Options.Add(new Label(new string('=', 16)));
            
            Options.Add(new Button("Load config", sender => {
                ConfigManager.Load(Misc.Prompt("Path to config file?", $"LokiConfig1.json"));
                _name.Text = ConfigManager.Settings.Name;
                _author.Text = ConfigManager.Settings.Author;
                _exePath.Text = ConfigManager.Settings.ExecutablePath;
                AddResponses();
            }));
            Options.Add(new Button("Save config", sender => {
                ConfigManager.Settings.Name = _name.Text;
                ConfigManager.Settings.Author = _author.Text;
                ConfigManager.Settings.ExecutablePath = _exePath.Text;
                ConfigManager.Save(Misc.Prompt("Where would you like to save the config?", $"{_name.Text}.json"));
            }));
            Options.Add(new AddNewResponseMenu(this));

            Options.Add(new Label(new string('=', 16)));
            Options.Add(_name = new TextField("Name:", ConfigManager.Settings.Name ?? "LokiConfig"));
            Options.Add(_author = new TextField("Author:", ConfigManager.Settings.Author ?? "User"));
            Options.Add(_exePath = new TextField("Executable path:", ConfigManager.Settings.ExecutablePath ?? "Program.exe"));
            Options.Add(new Label(new string('=', 16)));
        }

        readonly TextField _name;
        readonly TextField _author;
        readonly TextField _exePath;

        protected override void UpdateItems() {
            AddResponses();
            base.UpdateItems();
        }

        void RemoveExceptFirstX(int x) {
            for (;Options.Count > x;) {
                Options.RemoveAt(x);
            }
        }

        internal void AddResponses() {
            RemoveExceptFirstX(10);
            foreach (var resp in ConfigManager.Settings.Responses)
                Options.Add(new ResponseMenu(this, resp));
        }
    }
}
