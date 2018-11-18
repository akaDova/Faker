using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class Int32Generator : IGeneratable<int>
    {
        private Random random = new Random();
        public int GenerateValue()
        {
            var random = new Random();
            return this.random.Next();
        }
    }
}
