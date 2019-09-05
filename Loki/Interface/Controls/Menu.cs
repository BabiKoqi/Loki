using System;
using System.Collections.Generic;
using System.Linq;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    abstract class Menu : Control {
        internal Menu(string name) : base(name) {
            Console.CursorVisible = false;
        }

        internal override void Draw() => Console.WriteLine(Name + " >>");
        
        internal IList<Control> Options { get; } = new List<Control>();

        int _currentIndex;
        int _currentHash;

        internal void DrawMenu() {
            while (true) {
                if (!NeedToRedraw(out var pressed, out var key))
                    continue;
                
                Console.Clear();
                Console.WriteLine(Name + "\n");

                if (pressed) {
                    switch (key) {
                        case ConsoleKey.UpArrow:
                            _currentIndex--;
                            break;
                        case ConsoleKey.DownArrow:
                            _currentIndex++;
                            break;
                        case ConsoleKey.Enter:
                            Options[_currentIndex].OnPressed();
                            break;
                        case ConsoleKey.LeftArrow:
                            Options[_currentIndex].OnLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            Options[_currentIndex].OnRight();
                            break;
                        case ConsoleKey.Escape:
                            return;
                    }
                }

                NormalizeIndex();
                for (var i = 0; i < Options.Count; i++) {
                    if (_currentIndex == i) {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("-> ");
                        Console.ResetColor();
                    } else Console.Write("   ");
                    Options[i].Draw();
                }
            }
        }

        bool NeedToRedraw(out bool pressed, out ConsoleKey keyPressed) {
            pressed = false;
            keyPressed = ConsoleKey.A;
            var prev = _currentHash;
            _currentHash = Options.Sum(ctrl => ctrl.GetHashCode());
            if (prev != _currentHash)
                return true;

            if (!Console.KeyAvailable)
                return false;

            var key = Console.ReadKey(true).Key;
            var arr = new [] { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.Enter, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Escape };
            pressed = true;
            keyPressed = key;
            return arr.Contains(key);
        }

        void NormalizeIndex() {
            if (_currentIndex < 0)
                _currentIndex = Options.Count - 1;
            else if (_currentIndex >= Options.Count)
                _currentIndex = 0;
        }
    }
}