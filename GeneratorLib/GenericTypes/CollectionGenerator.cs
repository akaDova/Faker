using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GeneratorLib.PrimitiveTypes;

namespace GeneratorLib.GenericTypes
{
    public class CollectionGenerator<T, L> : IGeneratable<L> 
                                                where L: class, ICollection<T>
    {
        readonly Generators generators;

        public CollectionGenerator()
        {
            generators = new Generators();
        }

        public L GenerateValue()
        {
            IGeneratable<T> generator = generators.GetGenerator<T>(typeof(T));

            Type unboundList = typeof(L).GetGenericTypeDefinition();
            L result = (L)Activator.CreateInstance(unboundList.MakeGenericType(typeof(T)));

            byte listSize = (byte)generators.GenerateValue<byte>(typeof(byte));
            MethodInfo add = typeof(L).GetMethod("Add");
            if (add == null)
                return result;
            for (int i = 0; i < listSize; i++)
            {              
                add.Invoke(result, new object[] { generator.GenerateValue() });
            }

            return result;
        }
    }

}
