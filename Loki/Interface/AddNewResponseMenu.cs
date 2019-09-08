using Loki.Interface.Controls;
using Loki.Configuration.Skeleton;
using Loki.Configuration.Responses;
using Loki.Configuration;

namespace Loki.Interface {
    class AddNewResponseMenu : Menu {
        internal AddNewResponseMenu(Menu parent) : base("Add new response", parent) {
            Options.Add(_type);
            Options.Add(new Button("Ok", sender => {
                KeepDrawing = false;
                _add = true;
            }));
        }

        readonly TextField _type = new TextField("Type:", "Text");
        bool _add;

        internal override void DrawMenu() {
            base.DrawMenu();

            if (!_add)
                return;
            
            ResponseBase respbase;
            switch (_type.Text) {
                case "Text":
                    respbase = new TextResponse();
                    break;
                case "File":
                    respbase = new FileResponse();
                    break;
                default: return;
            }

            ConfigManager.Settings.Responses.Add(respbase);
            ((MainMenu)Parent).AddResponses();
        }
    }
}
