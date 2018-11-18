using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class DecimalGenerator : IGeneratable<decimal>
    {
        public decimal GenerateValue()
        {
            var random = new Random();
            return (decimal)(random.NextDouble() * (double)decimal.MaxValue);         
        }
    }
}
