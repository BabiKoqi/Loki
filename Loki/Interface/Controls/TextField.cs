using System;
using System.Collections.Generic;
using System.Linq;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class TextField : Control {
        internal TextField(string name, string def = "") : base(name) => Text = def.ToCharArray().ToList();
        
        internal IList<char> Text { get; set; }

        int _curPos;

        /*internal override void OnPressed() {
            Console.Clear();
            Console.WriteLine("Previous value: " + Text);
            Console.Write("New value: ");
            Text = Console.ReadLine().ToCharArray();
            Console.Clear();
        }*/

        internal override void OnLeft() {
            _curPos--;
            Normalize();
        }

        internal override void OnRight() {
            _curPos++;
            Normalize();
        }

        void Normalize() {
            if (_curPos < 0)
                _curPos = 0;
            else if (_curPos > Text.Count)
                _curPos = Text.Count;
        }

        internal override void OnOtherKey(ConsoleKeyInfo info) {
            Normalize();
            var key = info.KeyChar;
            
            if (_curPos - 1 < 0 && key == '\b')
                return;

            if (_curPos >= Text.Count && info.Key == ConsoleKey.Delete)
                return;
            
            //Backspace
            if (key == '\b') {
                Text.RemoveAt(_curPos - 1);
                _curPos--;
                return;
            }

            //Delete key
            if (info.Key == ConsoleKey.Delete) {
                Text.RemoveAt(_curPos);
                return;
            }

            if (info.Key == ConsoleKey.Home) {
                _curPos = 0;
                return;
            }

            if (info.Key == ConsoleKey.End) {
                _curPos = Text.Count;
                return;
            }

            Text.Insert(_curPos, key);
            _curPos++;
        }
        
        internal override void Draw(bool currentlySelected) {
            Console.Write(Name + " ");

            if (Text.Count < 1) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("<EMPTY>");
                Console.ResetColor();
                return;
            }

            if (currentlySelected) {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            for (var i = 0; i < Text.Count; i++) {
                if (currentlySelected && i == _curPos) {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Text[i]);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    continue;
                }
                Console.Write(Text[i]);
            }

            if (currentlySelected && _curPos == Text.Count) {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
            }
            
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}