using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GeneratorLib;
using GeneratorLib.GenericTypes;

namespace FakerLib
{
    public class Faker
    {
        readonly Generators generators = new Generators();
        

        public Faker() { }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public T Create<T>(params object[] args)
        {
            return Create<T>(typeof(T), args);
        }
 
        private object Create(Type type)
        {
            object creationResult = null;
           
            if (type.IsGenericType)
            {
                Type firstGenericArg = null;
                if (type.GetGenericArguments().Length >= 1)
                    firstGenericArg = type.GetGenericArguments().First();
                bool res = typeof(ICollection<>).MakeGenericType(firstGenericArg).IsAssignableFrom(type);
                if (type.IsConstructedGenericType
                        && generators.Has(type.GetGenericArguments().First())
                        && res)
                {

                    Type collectionGeneratorClosed = typeof(CollectionGenerator<,>)
                        .MakeGenericType(type.GetGenericArguments().First(), type);
                    creationResult = collectionGeneratorClosed.GetMethod("GenerateValue")
                        .Invoke(Activator.CreateInstance(collectionGeneratorClosed), null);
                }
            }
            
            else if (type.IsPrimitive && generators.Has(type))
                creationResult = generators.GetGeneratedValue(type);
                    
           
                //creationResult = generators.GenerateValue<)>(type);

            // check random value generator (built-in plugins)
            
            // check & pick constructor 
            else if (/*condition*/true)
            {
                (ConstructorInfo constructor, int paramCount) = type.GetConstructors()
                      .Select(ci => (ci: ci, paramCount: ci.GetParameters().Length))
                      .OrderBy(tuple => tuple.paramCount).Last();

                if (paramCount == 0)
                {

                }
                else
                {
                    var paramList = new List<object>();

                    foreach (var parameterInfo in constructor.GetParameters())
                    {
                        // 
                        paramList.Add(Create(parameterInfo.ParameterType));
                    }
                    // TODO: check for exception
                    creationResult = constructor.Invoke(paramList.ToArray());
                }

                
            }

            // check value type
            else if (type.IsValueType)
                creationResult = Activator.CreateInstance(type);

            return creationResult;
        }
    }
}

