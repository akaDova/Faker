using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class BooleanGenerator: IGeneratable<bool>
    {
        private Random random = new Random();

        public bool GenerateValue()
        {
            
            return random.Next(1) == 1;
        }

        
    }
}
