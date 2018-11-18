using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    class UInt64Generator : IGeneratable<ulong>
    {
        public ulong GenerateValue()
        {
            var random = new Random();
            return (ulong)(random.NextDouble() * ulong.MaxValue);
        }
    }
}
