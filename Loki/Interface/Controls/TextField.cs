using System;
using System.Collections.Generic;
using System.Linq;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class TextField : Control {
        public override int GetHashCode() => EqualityComparer<string>.Default.GetHashCode(Text);

        internal TextField(string name, string def = "", Menu parent = null) : base(name, parent) => Text = def;

        internal string Text {
            get => new string(_text.ToArray());
            set => _text = value.ToCharArray().ToList();
        }

        IList<char> _text;

        int _curPos;

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
            else if (_curPos > _text.Count)
                _curPos = _text.Count;
        }

        internal override void OnOtherKey(ConsoleKeyInfo info) {
            Normalize();
            var key = info.KeyChar;
            
            if (_curPos - 1 < 0 && info.Key == ConsoleKey.Backspace)
                return;

            if (_curPos >= _text.Count && info.Key == ConsoleKey.Delete)
                return;
            
            //Backspace
            if (info.Key == ConsoleKey.Backspace) {
                _text.RemoveAt(_curPos - 1);
                _curPos--;
                return;
            }

            //Delete key
            if (info.Key == ConsoleKey.Delete) {
                _text.RemoveAt(_curPos);
                return;
            }

            if (info.Key == ConsoleKey.Home) {
                _curPos = 0;
                return;
            }

            if (info.Key == ConsoleKey.End) {
                _curPos = _text.Count;
                return;
            }

            _text.Insert(_curPos, key);
            _curPos++;
        }
        
        internal override void Draw(bool currentlySelected) {
            Console.Write(Name + " ");

            if (_text.Count < 1) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("<EMPTY>");
                Console.ResetColor();
                return;
            }

            if (currentlySelected) {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            for (var i = 0; i < _text.Count; i++) {
                if (currentlySelected && i == _curPos) {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(_text[i]);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    continue;
                }
                Console.Write(_text[i]);
            }

            if (currentlySelected && _curPos == _text.Count) {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
            }
            
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}