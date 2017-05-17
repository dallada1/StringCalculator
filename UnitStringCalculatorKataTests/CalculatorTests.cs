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

        [TestMethod]
        public void FourFoursReturnsSixteen()
        {
            Assert.AreEqual(16, calculator.Add("4,4,4,4"));
        }

        [TestMethod]
        public void NewLinesAndCommasCanBeDelimiters()
        {
            Assert.AreEqual(6, calculator.Add("1\n2,3"));
        }

        [TestMethod]
        public void OnlyNewLinesAsDelimiters()
        {
            Assert.AreEqual(6, calculator.Add("1\n2\n3"));
        }

        [TestMethod]
        public void ConfiguringDelimitersWorks()
        {
            Assert.AreEqual(3, calculator.Add("//;\n1;2"));
        }

        [TestMethod]
        public void NegativeNumberThrowsExceptionWithNumberInMessage()
        {
            var exception = Assert.ThrowsException<NegativesNotAllowedException>(() => calculator.Add("2,-3"));
            Assert.AreEqual("-3 is not allowed.", exception.Message);
        }

        [TestMethod]
        public void MultipleNegativeNumbersThrowExceptionWithNumbersInMessage()
        {
            var exception = Assert.ThrowsException<NegativesNotAllowedException>(() => calculator.Add("-1,-3"));
            Assert.AreEqual("-1, -3 are not allowed.", exception.Message);
        }

        [TestMethod]
        public void NumbersLargerThan1000AreIgnored()
        {
            Assert.AreEqual(2, calculator.Add("2,1001"));
        }

        [TestMethod]
        public void DelimiterCanBeAnyLength()
        {
            Assert.AreEqual(6, calculator.Add("//[***]\n1***2***3"));
        }

        [TestMethod]
        public void MultipleDelimitersCanBeSet()
        {
            Assert.AreEqual(6, calculator.Add("//[*][%]\n1*2%3"));
        }

        [TestMethod]
        public void MultipleDelimitersCanBeSetLongerThanOneCharacter()
        {
            Assert.AreEqual(6, calculator.Add("//[***][%%%]\n1***2%%%3"));
        }
    }
}
