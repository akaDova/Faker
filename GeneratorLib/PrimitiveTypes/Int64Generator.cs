using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class Int64Generator : IGeneratable<long>
    {
        private Random random = new Random();

        public long GenerateValue()
        {
            
            return (long)(random.NextDouble() * long.MaxValue);
        }
    }
}
