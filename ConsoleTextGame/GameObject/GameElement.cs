using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject
{
    public abstract class Element : IElement, IPositionable
    {
        public string Id { get; }
        protected Action? PrintAction { get; set; }
        protected Action? ExecuteAction { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Element(string id, Action? printAction = null, Action? executeAction = null)
        {
            Id = id;
            PrintAction = printAction;
            ExecuteAction = executeAction;
        }

        public void Print()
        {
            if (PrintAction == null) return;
            PrintAction.Invoke();
        }

        public void Execute()
        {   if (ExecuteAction == null) return;
            ExecuteAction.Invoke();
        }
    }
}
