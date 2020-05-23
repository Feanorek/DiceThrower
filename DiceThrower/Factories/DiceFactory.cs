using DiceThrower.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiceThrower.Factories
{
    public class DiceFactory
    {
        public IEnumerable<Throwable> ParseDungeonAndDragonsDice(string inputString)
        {
            var dices = new List<Throwable>();
            var items = inputString.Split("+").Select(p => p.Trim());
            foreach (var possiblyContainingMinus in items)
            {
                var isFirstMinus = possiblyContainingMinus.StartsWith("-");
                var splitted = possiblyContainingMinus.Split("-");
                var isFirst = true;
                foreach (var item in splitted)
                {
                    var parts = item.Split("d");
                    var isNegative = isFirstMinus || !isFirst;
                    if (parts.Length == 1)
                    {
                        var value = short.Parse(item);
                        if (isNegative)
                        {
                            value *= -1;
                        }
                        if (item.StartsWith("d"))
                        {
                            dices.Add(new Dice(value));
                        }
                        else
                        {
                            dices.Add(new ConstantDice(value));
                        }
                    }
                    else if (parts.Length == 2)
                    {
                        var count = int.Parse(parts[0]);
                        var diceSize = short.Parse(parts[1]);
                        dices.AddRange(Enumerable.Repeat(diceSize, count).Select(p => new Dice(isNegative ? (short)-p : p)));
                    }
                    isFirst = false;
                }
            }
            return dices;
        }
    }
}
