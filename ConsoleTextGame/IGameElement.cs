using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame
{
    public interface IGameElement
    {   
        string Name { get; }
        string Id { get; }
        string Content { get; }
        public Action PrintAction { get;}
        public void PrintAndRequest();
    }
}
