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
        public void ParseDicesTest()
        {
            var d6 = "d6";
            var result = new DiceService().ParseDices(d6);

            Assert.AreEqual(6, result.First().SideCount);
        }
    }
}