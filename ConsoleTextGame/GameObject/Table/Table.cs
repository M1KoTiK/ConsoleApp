using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject.Table
{
    public class Table<T> : Element, ICollectionElement<ITableRow<T>>
    {
        public Table(string id, ICollection<ITableRow<T>> table, Action? printAction = null, Action? executeAction = null) : base(id, printAction, executeAction)
        {
            PrintAction = Print;
            this.table = table;
        }
        private ICollection<ITableRow<T>> table;
        private void Print()
        {
            foreach(var row in table)
            {
                row.PrintInTop();
            }
        }
        public void PrintTable()
        {
            if (PrintAction == null) return;
            PrintAction.Invoke();
        }
        public IEnumerable<ITableRow<T>> Items { get ;}
    }
}
