using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    class SingleGenerator : IGeneratable<float>
    {
        public float GenerateValue()
        {
            var random = new Random();
            return (float)random.NextDouble();
        }
    }
}
