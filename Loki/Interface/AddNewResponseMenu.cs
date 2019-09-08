using Loki.Interface.Controls;
using Loki.Configuration.Skeleton;
using Loki.Configuration.Responses;
using Loki.Configuration;

namespace Loki.Interface {
    class AddNewResponseMenu : Menu {
        internal AddNewResponseMenu(Menu parent) : base("Add new response", parent) {
            Options.Add(_type);
            Options.Add(new Button("Ok", (sender) => {
                KeepDrawing = false;
            }));
        }

        TextField _type = new TextField("Type:", "Text");

        internal override void DrawMenu() {
            base.DrawMenu();

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
            ((ConfigMenu)Parent).AddResponses();
        }
    }
}
