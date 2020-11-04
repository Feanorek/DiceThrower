using System;

namespace DiceThrower.Services.Models
{
    public abstract class Throwable<T>
    {
        public abstract T Throw();
    }
    public abstract class Throwable: Throwable<int>
    {
    }

    public class Dice : Throwable
    {
        private static readonly Random _random = new Random();

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

}
