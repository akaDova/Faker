using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    class UInt32Generator : IGeneratable<uint>
    {
        public uint GenerateValue()
        {
            var random = new Random();
            return (uint)random.Next();        
        }
    }
}
