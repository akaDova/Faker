using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    class CharGenerator : IGeneratable<char>
    {
        public char GenerateValue()
        {
            var random = new Random();
            return (char)random.Next(char.MinValue, char.MaxValue);        
        }
    }
}
