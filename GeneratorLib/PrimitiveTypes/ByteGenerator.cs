using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    class ByteGenerator : IGeneratable<byte>
    {
        public byte GenerateValue()
        {
            var random = new Random();
            return (byte)random.Next(byte.MaxValue);
        }
    }
}
