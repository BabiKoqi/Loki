using System.Collections.Generic;
using System.Reflection;
using Loki.Configuration;
using Loki.Configuration.Skeleton;
using Loki.Interface.Controls;

namespace Loki.Interface {
    class ResponseMenu : Menu {
        readonly ResponseBase _response;

        internal ResponseMenu(Menu parent, ResponseBase resp) : base(resp.Name, parent) => _response = resp;

        TextField _url;
        bool _delete;
        readonly IDictionary<TextField, PropertyInfo> _dict = new Dictionary<TextField, PropertyInfo>();

        internal override void DrawMenu() {
            Options.Clear();
            _dict.Clear();
            Options.Add(new Label("Type: " + _response.Type));
            Options.Add(_url = new TextField("Url:", _response.Url ?? string.Empty));

            //TODO: Add conditions

            foreach (var prop in _response.GetType().GetProperties()) {
                if (prop.GetGetMethod().IsVirtual || prop.PropertyType != typeof(string))
                    continue;

                var txt = new TextField(prop.Name + ":", (string)(prop.GetValue(_response) ?? string.Empty));
                _dict[txt] = prop;
                Options.Add(txt);
            }

            Options.Add(new Label(new string('=', 16)));
            Options.Add(new Button("Delete response", (sender) => { _delete = true; KeepDrawing = false; }));

            base.DrawMenu();

            if (_delete) {
                ConfigManager.Settings.Responses.Remove(_response);
                ((ConfigMenu)Parent).AddResponses();
                return;
            }

            _response.Url = _url.Text;
            foreach (var kp in _dict)
                kp.Value.SetValue(_response, kp.Key.Text);
        }
    }
}
