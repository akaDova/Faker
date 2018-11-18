using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class Int64Generator : IGeneratable<long>
    {
        public long GenerateValue()
        {
            var random = new Random();
            return (long)(random.NextDouble() * long.MaxValue);
        }
    }
}
