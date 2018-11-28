using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class DecimalGenerator : IGeneratable<decimal>
    {
        private Random random = new Random();

        public decimal GenerateValue()
        {
            
            return (decimal)(random.NextDouble() * (double)decimal.MaxValue);         
        }
    }
}
