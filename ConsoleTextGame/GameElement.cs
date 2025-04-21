using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame
{
    public abstract class GameElement : IGameElement
    {
        public abstract string Name { get; }
        public string Id { get; }
        public string Content { get; }

        abstract public Action PrintAction { get;}

        abstract public Action<string> RequestAction { get; }

        public GameElement(string id, string content)
        {
            Id = id;
            Content = content;
        }

        public void PrintAndRequest()
        {
            PrintAction.Invoke();
            RequestAction.Invoke(Console.ReadLine() ?? "");
        }
    }
}
