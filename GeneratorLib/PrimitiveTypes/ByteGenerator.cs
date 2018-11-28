using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class ByteGenerator : IGeneratable<byte>
    {
        private Random random = new Random();

        public byte GenerateValue()
        {
            
            return (byte)random.Next(byte.MaxValue);
        }
    }
}
