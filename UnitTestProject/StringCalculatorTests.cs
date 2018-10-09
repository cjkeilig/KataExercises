using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPrep;

namespace UnitTestProject
{
    [TestClass]
    public class StringCalculatorTests
    {

        private static StringCalculator _calculator;
        [TestMethod]
        public void AddingEmptyStringReturnsZeroTest()
        {
            int result = _calculator.Add("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AddingSingleNumberReturnsItselfTest()
        {
            int result = _calculator.Add("3");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddingTwoNumbersSeparatedByACommaTest()
        {
            int result = _calculator.Add("3,6");
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void AddingAnArbitraryAmountOfNumbersTest()
        {
            Random r = new Random();
            int randomSize = r.Next() % 100;

            string randomNumberString = "3";
            for (int i = 1; i < randomSize; i++)
            {
                randomNumberString += ",3";
            }
           
            int result = _calculator.Add(randomNumberString);
            Assert.AreEqual(randomSize * 3, result);
        }

        [TestMethod]
        public void AddingNumbersSeparatedByNewLineTest()
        {
            int result = _calculator.Add("3\n6\n9");
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void AddingNumbersSeparatedByNewLineAndCommaTest()
        {
            int result = _calculator.Add("3,6\n10");
            Assert.AreEqual(19, result);
        }

        [TestMethod]
        public void AddingNumbersWithCustomDelimiterTest()
        {
            // format  ---> '//' + delimiter + '\n' + list of numbers separated by delimiter
            int result = _calculator.Add("//%\n1%2%3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
    "Negatives not allowed, please fix: -6")]
        public void AddingANegativeThrowsAnExceptionTest()
        {
            int result = _calculator.Add("3,-6,10");
            
        }

        [TestMethod]
        public void NumbersAboveOneThousandAreExcludedTest()
        {
            int result = _calculator.Add("1001,2");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void AllowDelimitersOfAnyLengthTest()
        {
            // format  ---> '//' + delimiter + '\n' + list of numbers separated by delimiter
            int result = _calculator.Add("//test\n1test2test3test4");
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void AllowMultipleDelimitersOfAnyLengthTest()
        {
            // format  ---> '//' + delimiter + '\n' + list of numbers separated by delimiter
            int result = _calculator.Add("//[test][blue][red]\n1test2blue3red4");
            Assert.AreEqual(10, result);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _calculator = new StringCalculator();
        }
    }
}
