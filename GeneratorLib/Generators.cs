using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorLib.CustomTypes;
using GeneratorLib.PrimitiveTypes;
using GeneratorLib.StringType;

namespace GeneratorLib
{
    class Generators
    {
        private Dictionary<Type, object> supportedGenerators;
        private void Add<T>(IGeneratable<T> generator)
        {
            if (!Has(typeof(T)) && !generator.GetType().IsInterface)
                supportedGenerators.Add(typeof(T), generator);
        }
        void Reset()
        {
            
        }
        public Generators()
        {
            supportedGenerators = new Dictionary<Type, object>();
            try
            {
                Add(new BooleanGenerator());
                Add(new ByteGenerator());
                Add(new SByteGenerator());
                Add(new UInt16Generator());
                Add(new Int16Generator());
                Add(new UInt32Generator());
                Add(new Int32Generator());
                Add(new UInt64Generator());
                Add(new Int64Generator());
                Add(new SingleGenerator());
                Add(new DoubleGenerator());
                Add(new CharGenerator());
                Add(new StringGenerator());
                Add(new UriGenerator());
            }
            catch
            {

            }
        }

        public bool Has(Type type)
        {
            return supportedGenerators.ContainsKey(type);
        }

        public object GenerateValue<T>(Type type)
        {
            IGeneratable<T> generator;
            object result = null;
            if (Has(type))
            {
                generator = (IGeneratable<T>)supportedGenerators[type];
                result = generator.GenerateValue();
            }
            return result;
        }

        public IGeneratable<T> GetGenerator<T>(Type type)
        {
            IGeneratable<T> generator = null;
            if (Has(type))
            {
                generator = (IGeneratable<T>)supportedGenerators[type];
            }
            return generator;
        }

    }
}
