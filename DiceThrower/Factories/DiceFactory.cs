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
        public IEnumerable<Dice> Parse(string inputString)
        {
            var dices = new List<Dice>();
            var items = inputString.Split("+").Select(p => p.Trim());
            foreach (var possiblyContainingMinus in items)
            {
                var splitted = possiblyContainingMinus.Split("-");
                var isFirstMinus = possiblyContainingMinus.StartsWith("-");
                var isFirst = true;
                //FUBAR for negatives; return to this in the morning.
                foreach (var item in splitted)
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
                        dices.AddRange(Enumerable.Repeat(diceSize, count).Select(p => new Dice(p)));
                    }
                    isFirst = false;
                }
            }
            return dices;
        }
    }
}
