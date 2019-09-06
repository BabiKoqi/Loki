using Loki.Interface;
using Loki.Interface.Controls;

namespace Loki {
    static class Program {
        static void Main(string[] args) {
            var menu = new MainMenu();
            var sub = new MainMenu("sub");
            sub.Options.Add(new Checkbox("ayylmao"));
            
            var sub1 = new MainMenu("sub1");
            sub1.Options.Clear();
            sub1.Options.Add(new Checkbox("two"));
            sub.Options.Add(sub1);
            
            menu.Options.Add(sub);
            menu.DrawMenu();
        }
    }
}