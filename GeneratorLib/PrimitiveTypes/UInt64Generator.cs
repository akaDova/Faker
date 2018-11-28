using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class UInt64Generator : IGeneratable<ulong>
    {
        private Random random = new Random();

        public ulong GenerateValue()
        {
            
            return (ulong)(random.NextDouble() * ulong.MaxValue);
        }
    }
}
