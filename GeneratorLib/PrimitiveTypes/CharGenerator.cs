using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class CharGenerator : IGeneratable<char>
    {
        private Random random = new Random();

        public char GenerateValue()
        {
            
            return (char)random.Next(char.MinValue, char.MaxValue);        
        }
    }
}
