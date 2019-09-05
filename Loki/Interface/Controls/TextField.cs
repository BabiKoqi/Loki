using System;
using Loki.Interface.Skeleton;
using Microsoft.VisualBasic;

namespace Loki.Interface.Controls {
    class TextField : Control {
        internal TextField(string name, string def = "") : base(name) => Text = def;
        
        internal string Text { get; set; }

        internal override void OnPressed() => Text = Interaction.InputBox(string.Empty, string.Empty, Text); //Arrrgghhhhh, this one is a tough cookie to implement :/

        internal override void Draw() {
            Console.Write(Name + " ");

            if (Text == string.Empty) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("<EMPTY>");
                Console.ResetColor();
                return;
            }
            
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(Text);
            
            Console.ResetColor();
        }
    }
}