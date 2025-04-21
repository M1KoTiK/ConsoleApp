using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame
{
    public class GameMenuItem : GameElement
    {
        public override string Name => "Пункт меню";
        public override Action<string> RequestAction { get; }
        public override Action PrintAction { get; }
        public GameMenuItem(string id, string content, Action<string> answerAction) : base(id, content)
        {
            RequestAction = answerAction;
            PrintAction = () =>
            {
                Console.WriteLine(Content);
            };
        }
    }
}
