using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW4;
using System.IO;

namespace UnitTestPerson
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInput()
        {
            //Arrange
            Person actual = new Person();
            //Act

            string stringConsole = "Olia\n" + "2001";
            string name = "Olia";

            Person persExpected = new Person(name, DateTime.ParseExact("2001", "yyyy", null));

            using (StringReader stringReader = new StringReader(stringConsole))
            {
                Console.SetIn(stringReader);
                actual.Input();

            }

            //Assert
            StringAssert.Equals(persExpected, actual);
            //Assert.AreEqual(persExpected.Name, actual.Name);
            //Assert.AreEqual(persExpected.BirthYear, actual.BirthYear);            
        }

        [TestMethod]
        public void TestOutput()
        {
            //Arrange
            string name = "Olia";
            Person actual = new Person(name, DateTime.ParseExact("1999", "yyyy", null));
            //Act

            string expected = "Olia + 19";
            string result;

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                actual.Output();
                result = stringWriter.ToString();
            }

            //Assert
            String.Equals(expected, result);

        }
        [TestMethod]
        public void TestAge()
        {
            //Arrange
            string name = "Olia";
            int expected;
            expected = (DateTime.Now.Year) - 1999;
            //Act

            Person actual = new Person(name, DateTime.ParseExact("1999", "yyyy", null));

            //Assert
            Assert.AreEqual(actual.Age(), expected);


        }
    }
}
