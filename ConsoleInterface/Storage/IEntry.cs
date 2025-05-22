using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataBase
{
    public interface IEntry
    {
        string Id { get; }
    }
    class LazyEntry : IEntry
    {
        public string Id {  get; }
        public LazyEntry(string id)
        {
            Id = id;
        }
    }
}
