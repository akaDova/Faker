using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class UInt16Generator: IGeneratable<ushort>
    {
        public ushort GenerateValue()
        {
            var random = new Random();
            return (ushort)random.Next(ushort.MaxValue);
        }
    }
}
