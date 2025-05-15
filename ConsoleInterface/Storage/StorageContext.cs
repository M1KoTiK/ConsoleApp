using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleTextInterface.DataBase
{
    public interface StorageContext<T>
    {
        public void DeleteTables(IEnumerable<T> tables);
        public void WriteTables(IEnumerable<T> tables);
        public IEnumerable<T> ReadTables(int count = -1);
    }
}
