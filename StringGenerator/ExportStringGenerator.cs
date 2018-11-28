using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorLib;

namespace StringGeneratorLib
{
    public class ExportStringGenerator : IExportable
    {

        public Type ExportType
        {
            get => typeof(string);
        }

        public object GetGenerator()
        {
            return new StringGenerator();
        }
    }
}
