using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLib;
using System.Text;
using System.Reflection;

namespace FakerUnitTest
{
    [TestClass]
    public class UnitTest
    {
        private Faker faker;
        [TestMethod]
        public void CreationTest()
        {
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
