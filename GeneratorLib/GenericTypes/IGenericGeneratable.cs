using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.GenericTypes
{
    interface IGenericGeneratable<G, T>: IGeneratable<T> where T: IGeneratable<T>
    {
        G GenerateValue();
    }
}
