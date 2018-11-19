using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLib;
using System.Text;
using System.Reflection;
using GeneratorLib;
using GeneratorLib.GenericTypes;
using System.Collections.Generic;


namespace FakerUnitTest
{
    [TestClass]
    public class UnitTest
    {

        private Faker faker;
        [TestMethod]
        public void GenericCreationTest()
        {
            Generators generators = new Generators();
            Type type = typeof(List<int>);
            int kek = (int)generators.GetGeneratedValue(typeof(int));
            //List<int> val = (List<int>)generators.GetType().GetMethod("GenerateValue<>")
            //    .MakeGenericMethod(type).Invoke(generators, new object[] { type });
            //CollectionGenerator<int, List<int>> collectionGenerator1
            //    = new CollectionGenerator<int, List<int>>();
            //List<int> list = collectionGenerator1.GenerateValue();
            //CollectionGenerator<sbyte, List<sbyte>> collectionGenerator12
            //    = new CollectionGenerator<sbyte, List<sbyte>>();
            //List<sbyte> list2 = collectionGenerator12.GenerateValue();
            //CollectionGenerator<string, HashSet<string>> collectionGenerator2 
            //    = new CollectionGenerator<string, HashSet<string>>();
            //HashSet<string> listStr = collectionGenerator2.GenerateValue();
            faker = new Faker();
            faker.Create<List<int>>();
            Assert.AreEqual(new List<int>().GetType(), faker.Create<List<int>>().GetType());         
            
        }

        [TestMethod]
        public void Int32CreationTest()
        {

           
            faker = new Faker();

            int intActualValue = faker.Create<int>();
            Assert.IsTrue(int.MaxValue >= intActualValue && intActualValue >= int.MinValue);
        }

        [TestMethod]
        public void PrivateConstructorTest()
        {


            faker = new Faker();
   
            Assert.IsTrue(faker.Create<PrivateCtorTestClass>() == null);
        }

        [TestMethod]
        public void 

    }
}
