using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceThrower.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace DiceThrower.Services.Models.Tests
{
    [TestClass()]
    public class DiceTests
    {
        [TestMethod()]
        public void ThrowTest()
        {
            var d6 = new Dice(6);
            var throws = Enumerable.Repeat(0, 100).Select(p => d6.Throw());

            foreach (var thr in throws)
            {
                Assert.IsTrue(thr >= 1);
                Assert.IsTrue(thr <= 6);
            }
        }

        [TestMethod]
        public void NegativeTest()
        {
            var negativeD10 = new Dice(-10);
            var throws = Enumerable.Repeat(0, 100).Select(p => negativeD10.Throw());
            foreach (var thr in throws)
            {
                Assert.IsTrue(thr <= -1);
                Assert.IsTrue(thr >= -10);
            }
        }
    }
}