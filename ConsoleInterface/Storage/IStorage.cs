using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp.DataBase
{
    public interface IStorage<T>
    {
        public void Clear();
        public void DeleteTable(T tables);
        public void WriteTable(T table);
        public IEnumerable<T> ReadTables(int count = -1);
    }
}
