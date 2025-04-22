using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject
{
    public interface IGameElement
    {   
        string Id { get; }
        public void Print();
        public void Execute();
    }
}
