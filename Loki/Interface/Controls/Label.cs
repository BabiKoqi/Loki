using System.Collections.Generic;
using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class Label : Control {
        public override int GetHashCode() => EqualityComparer<string>.Default.GetHashCode(Name);

        internal Label(string name, Menu parent = null) : base(name, parent) { }
    }
}