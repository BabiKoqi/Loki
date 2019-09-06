using System;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class Checkbox : Control {
        public override int GetHashCode() => _value.Value.GetHashCode();

        internal Checkbox(string name, ValueContainer<bool> value = null) : base(name) {
            _value = value ?? new ValueContainer<bool>();
        }

        readonly ValueContainer<bool> _value;

        internal override void OnPressed() => _value.Value = !_value.Value;
        internal override void OnLeft() => OnPressed();
        internal override void OnRight() => OnPressed();

        internal override void Draw(bool currentlySelected) => Console.WriteLine($"[{(_value.Value ? "√" : "X")}] {Name}");
    }
}