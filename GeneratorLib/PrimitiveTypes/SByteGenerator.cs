using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib
{
    public class SByteGenerator : IGeneratable<sbyte>
    {
        private Random random = new Random();

        public sbyte GenerateValue()
        {
           
            return (sbyte)random.Next(sbyte.MinValue, sbyte.MaxValue);
        }
    }
}
