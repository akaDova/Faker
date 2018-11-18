using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    class Int32Generator : IGeneratable<int>
    {
        public int GenerateValue()
        {
            var random = new Random();
            return random.Next();
        }
    }
}
