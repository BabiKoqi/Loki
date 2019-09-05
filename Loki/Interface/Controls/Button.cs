using Loki.Interface.Skeleton;

namespace Loki.Interface.Controls {
    class Button : Control {
        internal delegate void OnPressedHandler(Button sender);

        readonly OnPressedHandler _handler;
        internal Button(string name, OnPressedHandler handler) : base(name) => _handler = handler;

        internal override void OnPressed() => _handler(this);
    }
}