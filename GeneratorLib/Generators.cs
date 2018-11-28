using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using GeneratorLib.CustomTypes;
using GeneratorLib.GenericTypes;
using GeneratorLib.PrimitiveTypes;
using GeneratorLib.StringType;

namespace GeneratorLib
{
    public class Generators
    {
        private Dictionary<Type, object> supportedGenerators;
        private void Add<T>(IGeneratable<T> generator)
        {
            if (!Has(typeof(T)) && !generator.GetType().IsInterface)
                supportedGenerators.Add(typeof(T), generator);
        }

        public void Add(Type type, object generator)
        {
            Type generatorType = generator.GetType();
            var res = (from i in generator.GetType().GetInterfaces()
                       where i.GetGenericTypeDefinition() == typeof(IGeneratable<>)
                       where i.GenericTypeArguments.Length == 1 
                            && i.GenericTypeArguments.First() == type
                       select i).Any();

            if (!Has(type) && res)
                supportedGenerators.Add(type, generator);
            
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
                //Add(new StringGenerator());
                //Add(new UriGenerator());
            }
            catch
            {

            }
        }

        public bool Has(Type type)
        {
            return supportedGenerators.ContainsKey(type);
        }

        public object GetGeneratedValue(Type type)
        {
            return this.GetType().GetMethod("GenerateValue")
                .MakeGenericMethod(type)
                .Invoke(this, new object[] { type });
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

