﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.PrimitiveTypes
{
    public class SingleGenerator : IGeneratable<float>
    {
        private Random random = new Random();

        public float GenerateValue()
        {
           
            return (float)random.NextDouble();
        }
    }
}
