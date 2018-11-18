using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib
{
    public class SByteGenerator : IGeneratable<sbyte>
    {
        public sbyte GenerateValue()
        {
            var random = new Random();
            return (sbyte)random.Next(sbyte.MinValue, sbyte.MaxValue);
        }
    }
}
