using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace FakerLib
{
    public class Faker
    {
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

            if ()
            // check random value generator (built-in plugins)

            // check & pick constructor 
            if (/*condition*/true)
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
            if (type.IsValueType)
                creationResult = Activator.CreateInstance(type);

            return creationResult;
        }
        
        
        V GenerateRandomValue<T, V>(T Generator) where T: IGeneratable
        {
            return Generator.GenerateValue<V>();
        }

        //private T Create<T>(Type type, params object[] args)
        //{
        //    return (T)Activator.CreateInstance(type, args);
        //}

    }

    interface IGeneratable
    {
        T GenerateValue<T>();
    }
}

