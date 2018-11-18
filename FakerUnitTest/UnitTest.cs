using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLib;
using System.Text;
using System.Reflection;
using GeneratorLib.GenericTypes;
using System.Collections.Generic;

namespace FakerUnitTest
{
    [TestClass]
    public class UnitTest
    {
        private Faker faker;
        [TestMethod]
        public void CreationTest()
        {
            CollectionGenerator<int, List<int>> collectionGenerator1
                = new CollectionGenerator<int, List<int>>();
            List<int> list = collectionGenerator1.GenerateValue();
            CollectionGenerator<sbyte, List<sbyte>> collectionGenerator12
                = new CollectionGenerator<sbyte, List<sbyte>>();
            List<sbyte> list2 = collectionGenerator12.GenerateValue();
            CollectionGenerator<string, HashSet<string>> collectionGenerator2 
                = new CollectionGenerator<string, HashSet<string>>();
            HashSet<string> listStr = collectionGenerator2.GenerateValue();
            faker = new Faker();

            MemberInfo[] members = typeof(Faker).GetMembers();
            foreach (var member in members)
            {
                Console.WriteLine(member);
            }
            char expectedValue = new char();
            char actualValue = faker.Create<char>();
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
