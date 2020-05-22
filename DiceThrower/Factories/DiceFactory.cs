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
        private static Regex _parseRegex = new Regex(@"^( *\+* *((?<number>\d*)|(?<dice>\d*d\d+)))+$");

        public IEnumerable<Dice> Parse(string inputString)
        {
            var matches = _parseRegex.Matches(inputString);
            if (matches.Count == 0)
                throw new Exception("Nope.");
            foreach (var match in matches)
            {
                yield return new Dice(0, 0);
            }
        }
    }
}
