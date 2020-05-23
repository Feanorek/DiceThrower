using DiceThrower.Factories;
using DiceThrower.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiceThrower.Services
{
    public class DiceService
    {
        private readonly DiceFactory _diceFactory;

        public DiceService(DiceFactory diceFactory)
        {
            _diceFactory = diceFactory;
        }
       
        //public string ThrowDice(string input)
        //{
        //    var dices = _diceFactory.Parse(input);

        //}
    }
}
