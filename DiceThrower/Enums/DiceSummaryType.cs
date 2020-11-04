using DiceThrower.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceThrower.Enums
{
    public abstract class DiceSummaryType
    {
        public abstract string CalculateSummary(IEnumerable<Throwable> dices);
    }


    public class DungeonsAndDragonsType : DiceSummaryType
    {
        public override string CalculateSummary(IEnumerable<Throwable> dices)
        {
            var results = dices.Select(p => p.Throw()).ToList();
            var stringBuilder = new StringBuilder();
            var isFirst = true;
            foreach (var item in results)
            {
                if (!isFirst && item > 0)
                    stringBuilder.Append("+");
                stringBuilder.Append(item);
                isFirst = false;
            }
            var sum = results.Sum();
            stringBuilder.Append(" = ");
            stringBuilder.Append(sum);
            return stringBuilder.ToString();
        }
    }

    public class GenesysType : DiceSummaryType
    {
        public override string CalculateSummary(IEnumerable<Throwable> dices)
        {
            throw new NotImplementedException();
        }
    }
}
