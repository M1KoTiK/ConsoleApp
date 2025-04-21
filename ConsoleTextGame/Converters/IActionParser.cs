using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.Converters
{
    public interface IActionParser
    {
        string Key { get; }
        public void ParseAndExecute(string parsableString);
    }
}
