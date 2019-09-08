using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class Button : Control {
        internal delegate void OnPressedHandler(Button sender);

        readonly OnPressedHandler _handler;
        internal Button(string name, OnPressedHandler handler, Menu parent = null) : base(name, parent) => _handler = handler;

        internal override void OnPressed() => _handler(this);
    }
}