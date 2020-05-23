using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceThrower.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using DiceThrowerTests.TestClasses;

namespace DiceThrower.Enums.Tests
{
    [TestClass()]
    public class DungeonsAndDragonsTypeTests
    {
        [TestMethod()]
        public void CalculateSummaryTest()
        {
            var fakeDice = new WeightedDice(10);

            var type = new DungeonsAndDragonsType();
            var summary = type.CalculateSummary(new[] { fakeDice });

            Assert.AreEqual("10 = 10", summary);
        }

        [TestMethod()]
        public void CalculateSummaryMultipleTest()
        {
            var fakeDice = new WeightedDice(10);
            var fakeDice2 = new WeightedDice(2);
            var fakeDice3 = new WeightedDice(3);
            var fakeDice4 = new WeightedDice(-4);


            var type = new DungeonsAndDragonsType();
            var summary = type.CalculateSummary(new[] { fakeDice, fakeDice2, fakeDice3, fakeDice4 });

            Assert.AreEqual("10+2+3-4 = 11", summary);
        }
    }
}