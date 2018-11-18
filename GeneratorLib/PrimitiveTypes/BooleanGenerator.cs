using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    class BooleanGenerator: IGeneratable<bool>
    {
        public Type GeneratableType
        {
            get => typeof(bool);
        }

        public bool GenerateValue()
        {
            var random = new Random();
            return random.Next(1) == 1;
        }

        
    }
}
