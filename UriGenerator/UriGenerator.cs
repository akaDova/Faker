using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorLib;

namespace UriGeneratorLib
{
    public class UriGenerator : IGeneratable<Uri>
    {
        public UriGenerator()
        {

        }

        public Uri GenerateValue()
        {
            Guid g = Guid.NewGuid();
            string guidString = Convert.ToBase64String(g.ToByteArray());
            guidString = guidString.Replace("=", "");
            guidString = guidString.Replace("+", "");
            guidString = guidString.Replace("/", "");
            var res = new Uri($"http://google.com/{guidString}");
            return res;
        }
    }
}
