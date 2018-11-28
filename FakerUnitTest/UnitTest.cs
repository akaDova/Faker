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

        [TestInitialize]
        public void Setup()
        {
            faker = new Faker();
        }

        
        [TestMethod]
        public void GenericCreationTest()
        {                        

            Assert.AreEqual(new List<int>().GetType(), faker.Create<List<int>>().GetType());
     
            Assert.AreEqual(new List<Uri>().GetType(), faker.Create<List<Uri>>().GetType());

            Assert.AreEqual(new LinkedList<string>().GetType(), faker.Create<LinkedList<string>>().GetType());

        }

        [TestMethod]
        public void IntCreationTest()
        {                      

            int intActualValue = faker.Create<int>();
            Assert.IsTrue(int.MaxValue >= intActualValue && intActualValue >= int.MinValue);

            uint uintActualValue = faker.Create<uint>();
            Assert.IsTrue(uint.MaxValue >= uintActualValue && uintActualValue >= uint.MinValue);

            ulong ulongActualValue = faker.Create<ulong>();
            Assert.IsTrue(ulong.MaxValue >= ulongActualValue && ulongActualValue >= ulong.MinValue);

            long longActualValue = faker.Create<long>();
            Assert.IsTrue(long.MaxValue >= longActualValue && longActualValue >= long.MinValue);

            short shortActualValue = faker.Create<short>();
            Assert.IsTrue(short.MaxValue >= shortActualValue && shortActualValue >= short.MinValue);

            ushort ushortActualValue = faker.Create<ushort>();
            Assert.IsTrue(ushort.MaxValue >= ushortActualValue && ushortActualValue >= ushort.MinValue);

            byte byteActualValue = faker.Create<byte>();
            Assert.IsTrue(byte.MaxValue >= byteActualValue && byteActualValue >= byte.MinValue);

            sbyte sbyteActualValue = faker.Create<sbyte>();
            Assert.IsTrue(sbyte.MaxValue >= sbyteActualValue && sbyteActualValue >= sbyte.MinValue);
        }

        [TestMethod]
        public void FloatCreationTest()
        {
            float floatActualValue = faker.Create<float>();
            Assert.IsTrue(float.MaxValue >= floatActualValue && floatActualValue >= float.MinValue);

            double doubleActualValue = faker.Create<double>();
            Assert.IsTrue(double.MaxValue >= doubleActualValue && doubleActualValue >= double.MinValue);

            decimal decimalActualValue = faker.Create<decimal>();
            Assert.IsTrue(decimal.MaxValue >= decimalActualValue && decimalActualValue >= decimal.MinValue);
        }

        [TestMethod]
        public void PrivateConstructorTest()
        {


            faker = new Faker();
   
            Assert.IsTrue(faker.Create<PrivateCtorTestClass>() == null);
            Assert.IsFalse(faker.Create<PrivateCtorTestClass>() != null);
        }

        [TestMethod]
        public void CycleDependseTest()
        {
            CycleDependenceFooTestClass foo = faker.Create<CycleDependenceFooTestClass>();
            Assert.IsTrue(foo.bar.foo == null);
            Assert.AreEqual(typeof(CycleDependenceBarTestClass), foo.bar.GetType());
            Assert.AreEqual(typeof(CycleDependenceFooTestClass), foo.GetType());
        }

        [TestMethod]
        public void FakerCreationTest()
        {
            Assert.AreEqual(faker.GetType(), faker.Create<Faker>().GetType());
        }

        [TestMethod]
        public void SeveralCtorsTest()
        {
            SeveralCtorsTestClass severalCtorsExpected = new SeveralCtorsTestClass();
            SeveralCtorsTestClass severalCtorsActual = faker.Create<SeveralCtorsTestClass>();

            OneCtorTestClass oneCtor = new OneCtorTestClass();

            Assert.AreEqual(severalCtorsExpected.GetType(), severalCtorsActual.GetType());
            Assert.AreNotEqual(severalCtorsExpected.kek, severalCtorsActual.kek);
            Assert.AreEqual(severalCtorsExpected.kek.GetType(), severalCtorsActual.kek.GetType());

            Assert.AreEqual(oneCtor.kek, faker.Create<OneCtorTestClass>().kek);

        }

        [TestMethod]
        public void SeveralFieldsTest()
        {
            var expectedValue = new SeveralFieldsTestClass();
            SeveralFieldsTestClass actualValue = faker.Create<SeveralFieldsTestClass>();

            Assert.AreEqual(expectedValue.GetType(), actualValue.GetType());
            Assert.AreEqual(actualValue.oURI, actualValue.cURI);
            Assert.AreEqual(expectedValue.rStr, actualValue.rStr);
        }
    }
}
