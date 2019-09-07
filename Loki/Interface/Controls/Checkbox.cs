using System;
using System.Collections.Generic;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class Checkbox : Control {
        public override int GetHashCode() => EqualityComparer<bool>.Default.GetHashCode(_value);

        internal Checkbox(string name, bool value = false) : base(name) {
            _value = value;
        }

        bool _value;

        internal override void OnPressed() => _value = !_value;
        internal override void OnLeft() => OnPressed();
        internal override void OnRight() => OnPressed();

        internal override void Draw(bool currentlySelected) => Console.WriteLine($"[{(_value ? "√" : "X")}] {Name}");
    }
}