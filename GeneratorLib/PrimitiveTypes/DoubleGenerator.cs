using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class DoubleGenerator : IGeneratable<double>
    {
        public double GenerateValue()
        {
            var random = new Random();
            return random.NextDouble() * Double.MaxValue;            
        }
    }
}
