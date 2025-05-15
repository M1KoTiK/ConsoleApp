using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextInterface.Storage.Converters
{

    public interface IConverter<T>
    {
        string Serialize(T value);
        T Deserialize(string value);
    }
}
