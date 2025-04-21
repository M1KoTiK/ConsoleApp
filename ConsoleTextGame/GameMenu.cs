using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame
{
    public class GameMenu : GameElement, GameCollectionElement<GameMenuItem>
    {
        public GameMenu(string id, string content) : base(id, content)
        {

        }

        public override string Name => "Меню";

        public override Action PrintAction => throw new NotImplementedException();

        public override Action<string> RequestAction => throw new NotImplementedException();

        private List<GameMenuItem> items;
        public IEnumerable<GameMenuItem> Items => items;

        public void Clear()
        {
            ((List<GameMenuItem>)Items).Clear();
        }

        public bool Add(GameMenuItem item)
        {
            items.Add(item);
            return true;
        }

        public bool Add(IEnumerable<GameMenuItem> items)
        {
            foreach (GameMenuItem item in items)
            {
                this.items.Add(item);
            }
            return true;
        }

        public void PrintAndRequest()
        {
            throw new NotImplementedException();
        }
    }
}
