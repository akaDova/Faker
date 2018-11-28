using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerUnitTest
{
    class SeveralCtorsTestClass
    {
        public SeveralCtorsTestClass()
        {
            kek = "kek";
        }

        public string kek;

        public SeveralCtorsTestClass(string kek)
        {
            this.kek = kek;
        }
    }
}
