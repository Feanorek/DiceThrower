using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiceThrower.Services.Models
{
    public class Dice
    {
        private static Random _random = new Random();
        private readonly short _sideCount;

        public Dice(short sideCount)
        {
            _sideCount = sideCount;
        }

        public short SideCount => _sideCount;

        public int Throw()
        {
            var next = _random.Next(1, SideCount);
            return next;

        }

    }
}
