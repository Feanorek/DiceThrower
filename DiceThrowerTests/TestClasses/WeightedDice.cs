using DiceThrower.Services.Models;

namespace DiceThrowerTests.TestClasses
{
    internal class WeightedDice : Dice
    {
        public WeightedDice(int sideCount) : base(sideCount)
        {
        }

        public override int Throw()
        {
            return (SideCount) * (IsNegative ? -1 : 1);
        }
    }
}
