using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib.CustomTypes
{
    public class UriGenerator : IGeneratable<Uri>
    {
        public Uri GenerateValue()
        {
            Guid g = Guid.NewGuid();
            string guidString = Convert.ToBase64String(g.ToByteArray());
            guidString = guidString.Replace("=", "");
            guidString = guidString.Replace("+", "");
            return new Uri($"http://{guidString}.com");
        }
    }
}
