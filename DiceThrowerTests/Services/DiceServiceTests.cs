using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceThrower.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DiceThrower.Services.Tests
{
    [TestClass()]
    public class DiceServiceTests
    {
        [TestMethod()]
        public void ParseD6Test()
        {
            var d6 = "d6";
            var result = new DiceService(new Factories.DiceFactory()).ParseDices(d6);

            Assert.AreEqual(6, result.First().SideCount);
        }

        [TestMethod()]
        public void Parse1d6Test()
        {
            var d6 = "1d6";
            var result = new DiceService(new Factories.DiceFactory()).ParseDices(d6);

            Assert.AreEqual(6, result.First().SideCount);
        }

        [TestMethod()]
        public void Parse1d6Add1Test()
        {
            var d6 = "1d6+1";
            var result = new DiceService(new Factories.DiceFactory()).ParseDices(d6);

            Assert.AreEqual(6, result.First().SideCount);
        }
    }
}