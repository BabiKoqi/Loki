using System;
using System.Text;
using Loki.Interface.Controls;

namespace Loki.Interface {
    class MainMenu : Menu {
        internal MainMenu(string name = "Loki v0.0.1 \\ALPHA/ | PRIVATE") : base(name) {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            
            Options.Add(new Label("I am a label"));
            Options.Add(new Button("I am a button and i will crash the app", null));
            Options.Add(new Checkbox("Hello there"));
            Options.Add(new TextField("Some text", "Alongerstringwithnospaces"));
        }
    }
}