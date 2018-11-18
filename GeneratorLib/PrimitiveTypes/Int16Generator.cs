using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class Int16Generator : IGeneratable<short>
    {
        public short GenerateValue()
        {
            var random = new Random();
            return (short)random.Next(short.MinValue, short.MaxValue);
        }
    }
}
