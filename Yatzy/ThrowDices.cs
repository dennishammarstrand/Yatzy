using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    class ThrowDices
    {
        public static string[] Throw(int dicesToThrow)
        {
            string[] diceResults = new string[dicesToThrow];
            for (int i = 0; i < dicesToThrow; i++)
            {
                Random dice = new Random();
                diceResults[i] = dice.Next(1, 6).ToString();
            }
            return diceResults;
        }
    }
}
