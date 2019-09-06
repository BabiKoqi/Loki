using System;

namespace Loki.Interface.Skeleton {
    abstract class Control {
        internal Control(string name) => Name = name;
        
        internal string Name { get; }
        internal virtual void OnLeft() { }
        internal virtual void OnRight() { }
        internal virtual void OnPressed() { }
        internal virtual void OnOtherKey(ConsoleKeyInfo info) { }
        internal virtual void Draw(bool currentlySelected) => Console.WriteLine(Name);
    }
}