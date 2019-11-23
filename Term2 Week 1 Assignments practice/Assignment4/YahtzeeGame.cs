using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    class YahtzeeGame
    {
        Dice[] dices = new Dice[5];
        public void Init()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice();
            }
        }
        public void Throw()
        {
            for (int i = 0; i < dices.Length; i++)
            {                
                dices[i].Throw();
            }
        }
        public void DisplayValues()
        {
            for (int i = 0; i < dices.Length; i++)
            {                
                dices[i].DisplayValue();                
            }
        }
        public bool Yahtzee()
        {
            for (int i = 1; i < dices.Length; i++)
            {
                if (dices[0].value != dices[i].value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
