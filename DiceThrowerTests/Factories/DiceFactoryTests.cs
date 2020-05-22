using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceThrower.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DiceThrower.Factories.Tests
{
    [TestClass()]
    public class DiceFactoryTests
    {
        private DiceFactory _diceFactory = new DiceFactory();

        [TestMethod()]
        public void ParseTest()
        {
            var input = "1d6";
            var dices = _diceFactory.Parse(input).ToList();
            Assert.AreEqual(1, dices.Count());
            var first = dices.First();
            Assert.AreEqual(6, first.SideCount);
            Assert.AreEqual(0, first.Modifier);
            Assert.IsFalse(first.IsNegative);
        }

        [TestMethod()]
        public void ParseMultipleTest()
        {
            var input = "2d6";
            var dices = _diceFactory.Parse(input).ToList();
            Assert.AreEqual(2, dices.Count());
            var first = dices.First();
            Assert.AreEqual(6, first.SideCount);
            Assert.AreEqual(0, first.Modifier);
            Assert.IsFalse(first.IsNegative);

        }

        [TestMethod()]
        public void ParseMultipleWithModifiedTest()
        {
            var input = "2d6+1";
            var dices = _diceFactory.Parse(input).ToList();
            Assert.AreEqual(3, dices.Count());

            var first = dices[0];
            Assert.AreEqual(6, first.SideCount);
            Assert.AreEqual(0, first.Modifier);
            Assert.IsFalse(first.IsNegative);

            var second = dices[1];
            Assert.AreEqual(6, second.SideCount);
            Assert.AreEqual(0, second.Modifier);
            Assert.IsFalse(second.IsNegative);

            var third = dices[2];
            Assert.AreEqual(0, third.SideCount);
            Assert.AreEqual(1, third.Modifier);
            Assert.IsFalse(third.IsNegative);

        }

        [TestMethod()]
        public void ParseMultipleTypesWithPlusTest()
        {
            var input = "2d6+1d10";
            var dices = _diceFactory.Parse(input).ToList();
            Assert.AreEqual(3, dices.Count());

            var first = dices[0];
            Assert.AreEqual(6, first.SideCount);
            Assert.AreEqual(0, first.Modifier);
            Assert.IsFalse(first.IsNegative);


            var second = dices[1];
            Assert.AreEqual(6, second.SideCount);
            Assert.AreEqual(0, second.Modifier);
            Assert.IsFalse(second.IsNegative);

            var third = dices[2];
            Assert.AreEqual(10, third.SideCount);
            Assert.AreEqual(0, third.Modifier);
            Assert.IsFalse(third.IsNegative);

        }

        [TestMethod()]
        public void ParseMultipleTypesWithMinusTest()
        {
            var input = "2d6-1d10";
            var dices = _diceFactory.Parse(input).ToList();
            Assert.AreEqual(3, dices.Count());

            var first = dices[0];
            Assert.AreEqual(6, first.SideCount);
            Assert.AreEqual(0, first.Modifier);
            Assert.IsFalse(first.IsNegative);

            var second = dices[1];
            Assert.AreEqual(6, second.SideCount);
            Assert.AreEqual(0, second.Modifier);
            Assert.IsFalse(second.IsNegative);


            var third = dices[2];
            Assert.AreEqual(10, third.SideCount);
            Assert.AreEqual(0, third.Modifier);
            Assert.IsTrue(third.IsNegative);
        }
    }
}