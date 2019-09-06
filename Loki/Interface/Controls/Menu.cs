using System;
using System.Collections.Generic;
using System.Linq;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    abstract class Menu : Control {
        internal Menu(string name) : base(name) {
            Console.CursorVisible = false;
        }

        internal override void Draw(bool currentlySelected) => Console.WriteLine($">> {Name}");

        internal override void OnPressed() {
            Console.Clear();
            DrawMenu();
            Console.Clear();
        }
        
        internal IList<Control> Options { get; } = new List<Control>();

        int _currentIndex;
        int _currentHash;

        internal void DrawMenu() {
            MenuNesting.Add(Name);
            var reDraw = true;
            while (true) {
                if (!NeedToRedraw(out var pressed, out var key) && !reDraw) {
                    continue;
                }

                reDraw = false;

                Console.Title = MenuNesting.Render();
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine(Name + "\n");

                if (pressed) {
                    switch (key.Value.Key) {
                        case ConsoleKey.UpArrow:
                            _currentIndex--;
                            break;
                        case ConsoleKey.DownArrow:
                            _currentIndex++;
                            break;
                        case ConsoleKey.Enter:
                            Options[_currentIndex].OnPressed();
                            reDraw = true;
                            continue;
                        case ConsoleKey.LeftArrow:
                            Options[_currentIndex].OnLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            Options[_currentIndex].OnRight();
                            break;
                        default:
                            Options[_currentIndex].OnOtherKey(key.Value);
                            break;
                        case ConsoleKey.Escape:
                            MenuNesting.Remove();
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
                    Options[i].Draw(_currentIndex == i);
                }
            }
        }

        bool NeedToRedraw(out bool pressed, out ConsoleKeyInfo? keyPressed) {
            pressed = false;
            keyPressed = null;
            var prev = _currentHash;
            _currentHash = Options.Sum(ctrl => ctrl.GetHashCode());
            if (prev != _currentHash)
                return true;

            if (!Console.KeyAvailable)
                return false;

            var key = Console.ReadKey(true);
            pressed = true;
            keyPressed = key;
            return true;
        }

        void NormalizeIndex() {
            if (_currentIndex < 0)
                _currentIndex = Options.Count - 1;
            else if (_currentIndex >= Options.Count)
                _currentIndex = 0;
        }
    }
}