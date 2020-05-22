using System;

namespace DiceThrower.Services.Models
{
    public class Dice
    {
        private static Random _random = new Random();

        public Dice(short sideCount, int modifier = 0)
        {
            if (sideCount < 0)
                IsNegative = true;
            SideCount = Math.Abs(sideCount);
            Modifier = modifier;
        }

        public short SideCount { get; }
        public int Modifier { get; }

        public bool IsNegative { get; }

        public int Throw()
        {
            var next = (SideCount == 0 ? 0 : _random.Next(1, SideCount)) + Modifier;
            return next;
        }
        public override string ToString()
        {
            var dice = $"d{SideCount}";
            var modifier = Modifier == 0 ? "" : Modifier > 0 ? "+" + Modifier : Modifier.ToString();

            return dice + modifier;
        }
    }
}
