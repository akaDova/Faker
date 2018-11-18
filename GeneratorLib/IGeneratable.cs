using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib
{
    public interface IGeneratable<T>
    {
        T GenerateValue();
        //Type GeneratableType
        //{
        //    get;
        //}
    }

    interface IGeneratable
    {
        object GenerateValue();
    }
}
