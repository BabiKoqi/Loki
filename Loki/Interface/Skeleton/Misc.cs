using Loki.Interface.Controls;

namespace Loki.Interface.Skeleton {
    static class Misc {
        internal static string Prompt(string message, string def = "") {
            var prompt = new Menu(message);
            var field = new TextField("Input:", def);
            var final = "";
            prompt.Options.Add(field);
            prompt.Options.Add(new Button("Ok", (sender) => { final = field.Text; prompt.KeepDrawing = false; }));
            prompt.DrawMenu();
            return final;
        }

        internal static bool PromptYesNo(string message) {
            var prompt = new Menu(message);
            var final = false;
            prompt.Options.Add(new Button("Yes", (sender) => { final = true; prompt.KeepDrawing = false; }));
            prompt.Options.Add(new Button("No", (sender) => { final = false; prompt.KeepDrawing = false; }));
            prompt.DrawMenu();
            return final;
        }
    }
}
