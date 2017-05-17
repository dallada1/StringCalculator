using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace UnitStringCalculatorKataTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator;

        public CalculatorTests()
        {
            calculator = new Calculator();
        }
        [TestMethod]
        public void EmptyStringReturnsZero()
        {
            Assert.AreEqual(0, calculator.Add(String.Empty));
        }

        [TestMethod]
        public void SpacesReturnZero()
        {
            Assert.AreEqual(0, calculator.Add(" "));
        }

        [TestMethod]
        public void OneReturnsOne()
        {
            Assert.AreEqual(1, calculator.Add("1"));
        }

        [TestMethod]
        public void ElevenReturnsEleven()
        {
            Assert.AreEqual(11, calculator.Add("11"));
        }

        [TestMethod]
        public void OneAndTwoReturnThree()
        {
            Assert.AreEqual(3, calculator.Add("1,2"));
        }

        [TestMethod]
        public void ElevenAndElevenReturnsTwentyTwo()
        {
            Assert.AreEqual(22, calculator.Add("11,11"));
        }

        [TestMethod]
        public void ThreeThreesReturnsNine()
        {
            Assert.AreEqual(9, calculator.Add("3,3,3"));
        }
    }
}
