using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.StringType
{
    class StringGenerator : IGeneratable<string>
    {
        public string GenerateValue()
        {
            var random = new Random();
            byte[] bytes = new byte[random.Next(byte.MaxValue)];
            
            return Convert.ToBase64String(bytes.Select(val => (byte)random.Next()).ToArray());
        }
    }
}
