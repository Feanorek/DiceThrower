using System;

namespace DiceThrower.Services.Models
{
    public class ConstantDice : Throwable
    {
        public ConstantDice(int modifier)
        {
            Modifier = Math.Abs(modifier);
            IsNegative = modifier < 0;
        }
        public virtual bool IsNegative { get; }

        public virtual int Modifier { get; }

        public override int Throw()
        {
            return Modifier * (IsNegative ? -1 : 1);
        }

        public override string ToString()
        {
            return $"{(IsNegative ? "-" : " + ")}{Modifier}";
        }
    }
}
