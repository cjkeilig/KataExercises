using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals;

namespace UnitTestProject
{

    [TestClass]
    public class RomanNumeralTests
    {

        private static RomanNumeralConverter _romanNumeralConverter;

        [TestMethod]
        public void BasicRomanCombinationsReturnCorrectNumeralTest()
        {
            Assert.AreEqual("40", _romanNumeralConverter.RomanToNumeral("XL"));
        }

        [TestMethod]
        public void NonBasicRomanCombinationsReturnCorrectNumeralTest()
        {
            Assert.AreEqual("41", _romanNumeralConverter.RomanToNumeral("XLI"));
        }

        [TestMethod]
        public void BasicNumeralCombinationsReturnCorrectRomanTest()
        {
            Assert.AreEqual("XX", _romanNumeralConverter.NumeralToRoman("20"));
        }

        [TestMethod]
        public void NonBasicNumeralCombinationsReturnCorrectRomanTest()
        {
            Assert.AreEqual("XLI", _romanNumeralConverter.NumeralToRoman("41"));
        }



        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _romanNumeralConverter = new RomanNumeralConverter();
        }
    }



}
