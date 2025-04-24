using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.GameObject
{
    public interface ICollectionElement<T>: IElement
    {
        public IEnumerable<T> Items { get; }
    }
}
