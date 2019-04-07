using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    class GameBoard
    {
        public int Ones { get; set; }
        public int Twos { get; set; }
        public int Threes { get; set; }
        public int Fours { get; set; }
        public int Fives { get; set; }
        public int Sixes { get; set; }
        public int OnePair { get; set; }
        public int TwoPair { get; set; }
        public int ThreeOfAKind { get; set; }
        public int FourOfAKind { get; set; }
        public int SmallStraight { get; set; }
        public int LargeStraight { get; set; }
        public int FullHouse { get; set; }
        public int Chance { get; set; }
        public int Yatzy { get; set; }
        public int Bonus { get; set; }
        public int TotalScore { get; set; }

              
    }
}
