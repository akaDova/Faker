using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerUnitTest
{
    class SeveralFieldsTestClass
    {
        public readonly string rStr = "eke";
        public string str;
        public int num;
        public List<double> list;
        public Uri uri;
        public Uri oURI
        {
            get => uri;
            set => uri = value;
        }
        public Uri cURI
        {
            get => uri;        
        }
    }
}
