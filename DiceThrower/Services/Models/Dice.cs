using System;

namespace DiceThrower.Services.Models
{
    public class Dice
    {
        private static Random _random = new Random();

        public Dice(short sideCount, int modifier = 0)
        {
            SideCount = sideCount;
            Modifier = modifier;
        }

        public short SideCount { get; }
        public int Modifier { get; }

        public int Throw()
        {
            var next = _random.Next(1, SideCount) + Modifier;
            return next;
        }

    }
}
