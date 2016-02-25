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
            results.Add(new Result()
            {
                Title = input.ToLower(),
                SubTitle = "Convert to Lowercase",
                IcoPath = "Images\\lowercase.png",
                Action = e =>
                {
                    // copy to clipboard after user select the item
                    Clipboard.SetText(input.ToLower());
                    // return false to tell Wox don't hide query window, otherwise Wox will hide it automatically
                    return false;
                }
            });
            
            results.Add(new Result()
            {
                Title = input.ToUpper(),
                SubTitle = "Convert to Uppercase",
                IcoPath = "Images\\uppercase.png",
                Action = e =>
                {
                    // copy to clipboard after user select the item
                    Clipboard.SetText(input.ToUpper());
                    // return false to tell Wox don't hide query window, otherwise Wox will hide it automatically
                    return false;
                }
            });
            return results;
        }
    }
}
