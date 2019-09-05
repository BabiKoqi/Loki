using System;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class Checkbox : Control {
        public override int GetHashCode() => _value.Value.GetHashCode();

        internal Checkbox(string name, ValueContainer<bool> value = null) : base(name) {
            _value = value ?? new ValueContainer<bool>(false);
        }

        readonly ValueContainer<bool> _value;

        internal override void OnPressed() => _value.Value = !_value.Value;
        internal override void OnLeft() => OnPressed();
        internal override void OnRight() => OnPressed();

        internal override void Draw() {
            Console.Write(Name + " ");
            Console.ForegroundColor = _value.Value ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(_value.Value.ToString().ToUpperInvariant());
            Console.ResetColor();
        }
    }
}