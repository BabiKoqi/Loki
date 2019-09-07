using System.Collections.Generic;
using System.Reflection;
using Loki.Configuration.Skeleton;
using Loki.Interface.Controls;

namespace Loki.Interface {
    class ResponseMenu : Menu {
        readonly ResponseBase _response;

        internal ResponseMenu(ResponseBase resp) : base(resp.Name) => _response = resp;

        TextField _url;
        readonly IDictionary<TextField, PropertyInfo> _dict = new Dictionary<TextField, PropertyInfo>();

        internal override void DrawMenu() {
            Options.Clear();
            _dict.Clear();
            Options.Add(new Label("Type: " + _response.Type));
            Options.Add(_url = new TextField("Url", _response.Url));
            //TODO: Add conditions

            foreach (var prop in _response.GetType().GetProperties()) {
                if (prop.GetGetMethod().IsVirtual)
                    continue;

                var txt = new TextField(prop.Name, (string)prop.GetValue(_response) ?? string.Empty);
                _dict[txt] = prop;
                Options.Add(txt);
            }

            base.DrawMenu();
        }
    }
}
