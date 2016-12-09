using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleShip.BLL;

namespace Battleship.Tests
{
    [TestFixture]
    class CoordinateValidationTests
    {

        [TestCase("a2", 1)]
        [TestCase("b9", 2)]
        [TestCase("c5", 3)]
        [TestCase("d3", 4)]
        [TestCase("e7", 5)]
        [TestCase("f1", 6)]
        [TestCase("g8", 7)]
        [TestCase("h10", 8)]
        [TestCase("i3", 9)]
        [TestCase("j1", 10)]

        public void LetterTest(string coor, int expected)
        {
            var actual = CoordinateTranslator.LetterTranslator(coor);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("a2", 2)]
        [TestCase("b9", 9)]
        [TestCase("c5", 5)]
        [TestCase("d3", 3)]

        public void NumberCheck(string input, int expected)
        {
            var actual = CoordinateTranslator.NumberTranslator(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("a2", true)]
        [TestCase("b10", true)]
        [TestCase("c5", true)]
        [TestCase("d10", true)]
        [TestCase("d101", false)]
        [TestCase("aa101", false)]
        [TestCase("a", false)]
        [TestCase("", false)]

        public void LengthCheck(string input, bool expected)
        {
            var actual = CoordinateTranslator.CoordinateLengthValidation(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("a2", true)]
        [TestCase("b9", true)]
        [TestCase("c5", true)]
        [TestCase("f3", true)]
        [TestCase("k2", false)]
        [TestCase("z5", false)]
        [TestCase("n", false)]
        [TestCase("za", false)]

        public void LetterCheck(string input, bool expected)
        {
            var actual = CoordinateTranslator.CheckForCoorLetter(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("a1", true)]
        [TestCase("b7", true)]
        [TestCase("c3", true)]
        [TestCase("a0", false)]
        [TestCase("d11", false)]
        [TestCase("e999", false)]

        public void ActualNumberCheck(string input, bool expected)
        {
            var actual = CoordinateTranslator.NumberCheck(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
