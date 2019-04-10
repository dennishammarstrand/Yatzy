using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    class PlayerActions
    {
        public static int ChooseNumberOfPlayers()
        {
            Console.WriteLine("Please enter number of players: ");
            return int.Parse(Console.ReadLine());
        }

        public static List<Player> EnterPlayerNames(int numberOfPlayers)
        {
            var tempPlayers = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine($"Enter player {i + 1} name: ");
                Player player = new Player
                {
                    Name = Console.ReadLine(),
                    Board = new GameBoard()
                };
                tempPlayers.Add(player);
            }
            return tempPlayers;
        }

        public static bool CheckForBonus(Player player)
        {
            int bonus = 0;
            bonus += player.Board.Ones;
            bonus += player.Board.Twos;
            bonus += player.Board.Threes;
            bonus += player.Board.Fours;
            bonus += player.Board.Fives;
            bonus += player.Board.Sixes;

            if (bonus >= 63) return true;
            else return false;
        }

        public static void SetPoint(Player player, List<int> savedDices)
        {
            Console.WriteLine($"Where do you wanna set your points? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "Ones":
                    player.Board.Ones = SetOneToSix(savedDices, 1);
                    player.Board.TotalScore += SetOneToSix(savedDices, 1);
                    break;
                case "Twos":
                    player.Board.Twos = SetOneToSix(savedDices, 2);
                    player.Board.TotalScore += SetOneToSix(savedDices, 2);
                    break;
                case "Threes":
                    player.Board.Threes = SetOneToSix(savedDices, 3);
                    player.Board.TotalScore += SetOneToSix(savedDices, 3);
                    break;
                case "Fours":
                    player.Board.Fours = SetOneToSix(savedDices, 4);
                    player.Board.TotalScore += SetOneToSix(savedDices, 4);
                    break;
                case "Fives":
                    player.Board.Fives = SetOneToSix(savedDices, 5);
                    player.Board.TotalScore += SetOneToSix(savedDices, 5);
                    break;
                case "Sixes":
                    player.Board.Sixes = SetOneToSix(savedDices, 6);
                    player.Board.TotalScore += SetOneToSix(savedDices, 6);
                    break;
                case "OnePair":
                    player.Board.OnePair = SetOneOrTwoPair(savedDices, 1);
                    player.Board.TotalScore += SetOneOrTwoPair(savedDices, 1);
                    break;
                case "TwoPair":
                    player.Board.OnePair = SetOneOrTwoPair(savedDices, 2);
                    player.Board.TotalScore += SetOneOrTwoPair(savedDices, 2);
                    break;
                case "ThreeOfAKind":
                    player.Board.ThreeOfAKind = ThreeAndFourOfAKind(savedDices, 3);
                    player.Board.TotalScore += ThreeAndFourOfAKind(savedDices, 3);
                    break;
                case "FourOfAKind":
                    player.Board.ThreeOfAKind = ThreeAndFourOfAKind(savedDices, 4);
                    player.Board.TotalScore += ThreeAndFourOfAKind(savedDices, 4);
                    break;
                case "SmallStraight":
                    player.Board.SmallStraight = Straight(savedDices);
                    player.Board.TotalScore += Straight(savedDices);
                    break;
                case "LargeStraight":
                    player.Board.LargeStraight = Straight(savedDices);
                    player.Board.TotalScore += Straight(savedDices);
                    break;
                case "FullHouse":
                    break;
                case "Chance":
                    break;
                case "Yatzy":
                    break;
                default:
                    throw new ArgumentException("Invalid selection");
            }
        }

        public static int SetOneToSix(List<int> savedDices, int choice)
        {
            int value = 0;

            foreach (var item in savedDices)
            {
                if (item == choice)
                {
                    value += item;
                }
            }
            return value;
        }

        public static int SetOneOrTwoPair(List<int> savedDices, int choice)
        {
            int highestPair = 0;
            var count = new int[6];

            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < savedDices.Count; j++)
                {
                    if (i + 1 == savedDices[j])
                    {
                        count[i]++;
                    }
                }
            }
            int rounds = 0;
            for (int i = count.Length - 1; i >= 0; i--)
            {
                if (count[i] >= 2)
                {
                    highestPair += (i + 1) * 2;
                    rounds++;
                    if (rounds == choice) break;
                }
            }
            return highestPair;
        }
        static int ThreeAndFourOfAKind(List<int> savedDices, int threeOrFour)
        {
            int threeOfAKind = 0;
            var count = new int[6];

            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < savedDices.Count; j++)
                {
                    if (i + 1 == savedDices[j])
                    {
                        count[i]++;
                    }
                }
            }

            for (int i = count.Length - 1; i >= 0; i--)
            {
                if (count[i] >= threeOrFour)
                {
                    threeOfAKind += (i + 1) * threeOrFour;
                }
            }
            return threeOfAKind;
        }
        static int Straight(List<int> savedDices)
        {
            var count = new int[6];

            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < savedDices.Count; j++)
                {
                    if (i + 1 == savedDices[j])
                    {
                        count[i]++;
                    }
                }
            }
            int round = 0;
            for (int i = count.Length - 1; i >= 0; i--)
            {
                if (count[i] == 1)
                {
                    round++;
                }
            }
            if (count[5] == 0 && round == 5)
            {
                return 15;
            }
            else if (count[0] == 0 && round == 5)
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }
    }
}
