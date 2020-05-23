using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceThrower.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DiceThrower.Services.Models;

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
            var dices = _diceFactory.ParseDungeonAndDragonsDice(input).ToList();
            Assert.AreEqual(1, dices.Count());
            var first = dices[0];
            Assert.IsInstanceOfType(first, typeof(Dice));
            var firstDice = first as Dice;
            Assert.AreEqual(6, firstDice.SideCount);
            Assert.IsFalse(firstDice.IsNegative);
        }

        [TestMethod()]
        public void ParseMultipleTest()
        {
            var input = "2d6";
            var dices = _diceFactory.ParseDungeonAndDragonsDice(input).ToList();
            Assert.AreEqual(2, dices.Count());
            var first = dices[0];
            Assert.IsInstanceOfType(first, typeof(Dice));

            Assert.IsInstanceOfType(first, typeof(Dice));
            var firstDice = first as Dice;
            Assert.AreEqual(6, firstDice.SideCount);
            Assert.IsFalse(firstDice.IsNegative);

            var second = dices[1];
            Assert.IsInstanceOfType(second, typeof(Dice));
            var secondDice = second as Dice;
            Assert.AreEqual(6, secondDice.SideCount);
            Assert.IsFalse(secondDice.IsNegative);

        }

        [TestMethod()]
        public void ParseMultipleWithModifiedTest()
        {
            var input = "2d6+1";
            var dices = _diceFactory.ParseDungeonAndDragonsDice(input).ToList();
            Assert.AreEqual(3, dices.Count());

            var first = dices[0];
            Assert.IsInstanceOfType(first, typeof(Dice));
            var firstDice = first as Dice;
            Assert.AreEqual(6, firstDice.SideCount);
            Assert.IsFalse(firstDice.IsNegative);

            var second = dices[1];
            Assert.IsInstanceOfType(second, typeof(Dice));
            var secondDice = second as Dice;
            Assert.AreEqual(6, secondDice.SideCount);
            Assert.IsFalse(secondDice.IsNegative);

            var third = dices[2];
            Assert.IsInstanceOfType(third, typeof(ConstantDice));
            var thrirdDice = third as ConstantDice;
            Assert.AreEqual(1, thrirdDice.Modifier);
            Assert.IsFalse(thrirdDice.IsNegative);

        }

        [TestMethod()]
        public void ParseMultipleTypesWithPlusTest()
        {
            var input = "2d6+1d10";
            var dices = _diceFactory.ParseDungeonAndDragonsDice(input).ToList();
            Assert.AreEqual(3, dices.Count());

            var first = dices[0];
            var firstDice = first as Dice;
            Assert.AreEqual(6, firstDice.SideCount);
            Assert.IsFalse(firstDice.IsNegative);


            var second = dices[1];
            Assert.IsInstanceOfType(second, typeof(Dice));
            var secondDice = second as Dice;
            Assert.AreEqual(6, secondDice.SideCount);
            Assert.IsFalse(secondDice.IsNegative);

            var third = dices[2];
            Assert.IsInstanceOfType(third, typeof(Dice));
            var thirdDice = third as Dice;
            Assert.AreEqual(10, thirdDice.SideCount);
            Assert.IsFalse(thirdDice.IsNegative);

        }

        [TestMethod()]
        public void ParseMultipleTypesWithMinusTest()
        {
            var input = "2d6-1d10";
            var dices = _diceFactory.ParseDungeonAndDragonsDice(input).ToList();
            Assert.AreEqual(3, dices.Count());

            var first = dices[0];
            var firstDice = first as Dice;
            Assert.AreEqual(6, firstDice.SideCount);
            Assert.IsFalse(firstDice.IsNegative);

            var second = dices[1];
            Assert.IsInstanceOfType(second, typeof(Dice));
            var secondDice = second as Dice;
            Assert.AreEqual(6, secondDice.SideCount);
            Assert.IsFalse(secondDice.IsNegative);


            var third = dices[2];
            Assert.IsInstanceOfType(third, typeof(Dice));
            var thirdDice = third as Dice;
            Assert.AreEqual(10, thirdDice.SideCount);
            Assert.IsTrue(thirdDice.IsNegative);
        }
    }
}