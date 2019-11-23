using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    class Dice
    {
        public int value;
        static Random rnd = new Random();

        public void Throw()
        {
            value = rnd.Next(1, 7);
        }
        public void DisplayValue()
        {
            Console.Write("{0} ",value);
        }
    }    
}
