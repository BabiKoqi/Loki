using System;
using System.Collections.Generic;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class Checkbox : Control {
        public override int GetHashCode() => EqualityComparer<bool>.Default.GetHashCode(Checked);

        internal Checkbox(string name, bool value = false, Menu parent = null) : base(name, parent) => Checked = value;

        internal bool Checked { get; set; }

        internal override void OnPressed() => Checked = !Checked;
        internal override void OnLeft() => OnPressed();
        internal override void OnRight() => OnPressed();

        internal override void Draw(bool currentlySelected) => Console.WriteLine($"[{(Checked ? "√" : "X")}] {Name}");
    }
}