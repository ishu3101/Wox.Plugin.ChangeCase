using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Wox.Plugin.ChangeCase
{
    public class Main : IPlugin
    {
        public void Init(PluginInitContext context) { }
        public List<Result> Query(Query query)
        {
            List<Result> results = new List<Result>();
            var keyword = query.ActionParameters;
            //  get the input entered by the user
            string input = "";
            foreach (string param in keyword)
            {
                   input += " " + param;
            }

            String title = input.ToLower();
            results.Add(Result(title, "Convert to Lowercase", "Images\\lowercase.png", Action(title)));
            title = input.ToUpper();
            results.Add(Result(title, "Convert to Uppercase", "Images\\uppercase.png", Action(title)));

            return results;
        }

        private static Result Result(String title, String subtitle, String icon, Func<ActionContext, bool> action)
        {
            return new Result()
            {
                Title = title,
                SubTitle = subtitle,
                IcoPath = icon,
                Action = action
            };
        }

        // The Action method is called after the user selects the item
        private static Func<ActionContext, bool> Action(String text)
        {
            return e =>
            {
                CopyToClipboard(text);

                // return false to tell Wox don't hide query window, otherwise Wox will hide it automatically
                return false;
            };
        }

        // Copy the text entered to the Clipboard
        public static void CopyToClipboard(String text)
        {
            Clipboard.SetText(text);
        }
    }
}
