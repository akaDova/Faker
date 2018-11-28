using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class UInt16Generator: IGeneratable<ushort>
    {
        private Random random = new Random();

        public ushort GenerateValue()
        {
            
            return (ushort)random.Next(ushort.MaxValue);
        }
    }
}
