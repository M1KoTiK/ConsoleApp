using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterface.ConsoleObject.Menu
{
    public class MenuItem : Element
    {
        public string Separator { get; set; } = " : ";
        public string Marker { get; set; } = " ";
        public string ItemContent { get; set; }

        public MenuItem(string id, string itemContent, Action? executeAction = null) : base(id, executeAction: executeAction)
        {
            ItemContent = itemContent;
            PrintAction = () =>
            {
                Console.WriteLine(Marker + Id + Separator + ItemContent);
            };
        }
    }
}
