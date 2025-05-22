using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Storage.Converters
{

    public interface IConverter<T>
    {
        string Serialize(T value);
        T Deserialize(string value);
    }
}
