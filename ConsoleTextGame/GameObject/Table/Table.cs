using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject.Table
{
    public class Table<T> : Element, ICollectionElement<ITableRow<T>>
    {
        public IList<ITableRow<T>> Items { get; }
        public Table(string id, IList<ITableRow<T>> table, Action? printAction = null, Action? executeAction = null) : base(id, printAction, executeAction)
        {
            PrintAction = Print;
            this.Items = table;
        }
        private void Print()
        {
            Items[0].PrintTopLine();
            Console.WriteLine();
            for(var i = 0; i < Items.Count - 1; i++)
            {
                Items[i].PrintElementLine();
                Console.WriteLine();
                Items[i].PrintSeparatorLine();
                Console.WriteLine();
            }
            Items[Items.Count-1].PrintElementLine();
            Console.WriteLine();
            Items[Items.Count-1].PrintBottomLine();
        }

        public void PrintTable()
        {
            if (PrintAction == null) return;
            PrintAction.Invoke();
        }


    }
}
