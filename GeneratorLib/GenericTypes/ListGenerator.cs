using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorLib.PrimitiveTypes;

namespace GeneratorLib.GenericTypes
{
    class ListGenerator<T, L> : IGeneratable<L> where T: IGeneratable<T>
                                                where L: List<T>
    {
        readonly Generators generators;

        public ListGenerator()
        {
            generators = new Generators();
        }

        public L GenerateValue()
        {
            IGeneratable<T> generator = generators.GetGenerator<T>(typeof(T));
            Type unboundList = typeof(List<>);
            L result = (L)Activator.CreateInstance(unboundList.MakeGenericType(typeof(T)));

        }
    }

}
