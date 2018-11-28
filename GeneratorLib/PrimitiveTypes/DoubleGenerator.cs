using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class DoubleGenerator : IGeneratable<double>
    {
        private Random random = new Random();

        public double GenerateValue()
        {
            
            return random.NextDouble() * Double.MaxValue;            
        }
    }
}
