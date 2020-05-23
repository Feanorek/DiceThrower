using System;

namespace DiceThrower.Services.Models
{
    public abstract class Throwable
    {
        public abstract int Throw();
    }

    public class Dice : Throwable
    {
        private static Random _random = new Random();

        public Dice(int sideCount)
        {
            if (sideCount < 0)
                IsNegative = true;
            SideCount = Math.Abs(sideCount);
        }

        public virtual int SideCount { get; }
        public virtual bool IsNegative { get; }

        public override int Throw()
        {
            var next = (SideCount == 0 ? 0 : _random.Next(1, SideCount));
            if (IsNegative)
                return -next;
            return next;
        }
        public override string ToString()
        {
            var dice = $"d{SideCount}";

            return dice;
        }
    }

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
