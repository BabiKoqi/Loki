using System;
using Loki.Interface.Controls;

namespace Loki.Interface.Skeleton {
    abstract class Control {
        Control(string name) => Name = name;
        internal Control(string name, Menu parent) : this(name) => Parent = parent;
        
        internal string Name { get; }
        internal Menu Parent { get; }
        internal virtual void OnLeft() { }
        internal virtual void OnRight() { }
        internal virtual void OnPressed() { }
        internal virtual void OnOtherKey(ConsoleKeyInfo info) { }
        internal virtual void Draw(bool currentlySelected) => Console.WriteLine(Name);
    }
}