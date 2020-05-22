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
        [TestMethod]
        public void Test()
        {
            var inputString = "2d6+3d6+5+10";
            //var _parseRegex = new Regex(@"^( *\+* *((?<number>\d*)|(?<dice>\d*d\d+)))+$");
            //var matches = _parseRegex.Matches(inputString);
            //if (matches.Count == 0)
            //    throw new Exception("Nope.");
            //foreach (Match match in matches)
            //{
            //    var dices = match.Groups;
            //    var numbers = match.Groups["numbers"];
            //}
            var dices = new List<Dice>();
            var items = inputString.Split("+").Select(p => p.Trim());
            foreach (var item in items)
            {
                var parts = item.Split("d");
                if (parts.Length == 1)
                {
                    if (item.StartsWith("d"))
                    {
                        dices.Add(new Dice(short.Parse(item)));
                    }
                    else
                    {
                        dices.Add(new Dice(0, short.Parse(item)));
                    }
                }
                else if (parts.Length == 2)
                {
                    var count = int.Parse(parts[0]);
                    var diceSize = short.Parse(parts[1]);
                   dices.AddRange( Enumerable.Repeat(diceSize, count).Select(p => new Dice(p)));
                }
            }

        }

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
    }
}