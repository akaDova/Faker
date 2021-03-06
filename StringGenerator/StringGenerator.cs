﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorLib;

namespace StringGeneratorLib
{
    public class StringGenerator : IGeneratable<string>
    {
        private Random random = new Random();


        public string GenerateValue()
        {
            
            byte[] bytes = new byte[random.Next(byte.MaxValue)];

            return Convert.ToBase64String(bytes.Select(val => (byte)random.Next()).ToArray());
        }
    }
}
