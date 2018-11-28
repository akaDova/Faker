using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorLib;

namespace UriGeneratorLib
{
    public class ExportUriGenerator : IExportable
    {

        //public UriGenerator generator = new UriGenerator();

        public object GetGenerator()
        {
            return new UriGenerator();
        }

        public Type ExportType
        {
            get => typeof(Uri);
        }
    }
}
