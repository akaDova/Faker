using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class UInt32Generator : IGeneratable<uint>
    {
        private Random random = new Random();

        public uint GenerateValue()
        {
            
            return (uint)random.Next();        
        }
    }
}
