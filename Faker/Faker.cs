﻿using System;
using System.Collections.Generic;
using System.IO;
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
        readonly Stack<Type> generatedTypes = new Stack<Type>();

        static string pluginsPath = @"plugins";
            
        private void LoadPluginGenerators()
        {
            var generatorsList = (
                from file in Directory.GetFiles(pluginsPath, "*.dll")
                select Assembly.LoadFrom(file) into assembly
                select assembly.GetTypes() into types
                from type in types
                from i in (
                    from i in type.GetInterfaces()
                    select i
                )
                where i == (typeof(IExportable))
                select Activator.CreateInstance(type) as IExportable into generator
                select generator
             ).ToList();

            foreach (var gen in generatorsList)
            {
                generators.Add(gen.ExportType, gen.GetGenerator());
            }
         

        }

        public Faker()
        {
            LoadPluginGenerators();
      
        }

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
            if (generatedTypes.Contains(type))
                return creationResult;
            generatedTypes.Push(type);
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
                        .Invoke(Activator.CreateInstance(collectionGeneratorClosed, generators), null);
                }
            }
            
            else if (type.IsPrimitive && generators.Has(type))
                creationResult = generators.GetGeneratedValue(type);
            else if (type.IsValueType && generators.Has(type))
                creationResult = generators.GetGeneratedValue(type);
            else if (type.IsClass && generators.Has(type))
                creationResult = generators.GetGeneratedValue(type);
 
            else if (type.IsClass)
            {
                ConstructorInfo[] constructors = type.GetConstructors();
                if (constructors.Length >= 1)
                {
                    (ConstructorInfo constructor, int paramCount) =
                        (from ctor in constructors
                         select (ctor, ctor.GetParameters().Length) into tuple
                         orderby tuple.Length
                         select tuple).Last();                       

                    if (paramCount == 0)
                    {
                        creationResult = constructor.Invoke(null);
                        FieldInfo[] fields = type.GetFields();
                        if (fields.Length > 0)
                        {
                            foreach (var field in fields)
                            {
                                if (!field.IsInitOnly)
                                    field.SetValue(creationResult, Create(field.FieldType));
                            }
                        }

                        PropertyInfo[] properties = type.GetProperties();
                        if(properties.Length > 0)
                        {
                            foreach (var property in properties)
                            {
                                if (property.CanWrite)
                                    property.SetValue(creationResult, Create(property.PropertyType));
                            }
                        }
                    }
                    else
                    {
                        var paramList = new List<object>();

                        foreach (var parameterInfo in constructor.GetParameters())
                        {
                            
                            paramList.Add(Create(parameterInfo.ParameterType));
                        }
                        
                        creationResult = constructor.Invoke(paramList.ToArray());
                    }
                    
                }
                           
            }


            else if (type.IsValueType)
                creationResult = Activator.CreateInstance(type);
            generatedTypes.Pop();
            return creationResult;
        }
    }
}

