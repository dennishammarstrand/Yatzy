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

        public static void SetPoint(Player player, List<string> savedDices)
        {
            Console.WriteLine($"Where do you wanna set your points? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "Ones":
                    player.Board.Ones = SetOneToSix(player, savedDices, "1");
                    break;
                case "Twos":
                    player.Board.Twos = SetOneToSix(player, savedDices, "2");
                    break;
                case "Threes":
                    player.Board.Threes = SetOneToSix(player, savedDices, "3");
                    break;
                case "Fours":
                    player.Board.Fours = SetOneToSix(player, savedDices, "4");
                    break;
                case "Fives":
                    player.Board.Fives = SetOneToSix(player, savedDices, "5");
                    break;
                case "Sixes":
                    player.Board.Sixes = SetOneToSix(player, savedDices, "6");
                    break;
                case "OnePair":
                    break;
                case "TwoPair":
                    break;
                case "ThreeOfAKind":
                    break;
                case "FourOfAKind":
                    break;
                case "SmallStraight":
                    break;
                case "LargeStraight":
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

        public static int SetOneToSix(Player player, List<string> savedDices, string choice)
        {
            int value = 0;

            foreach (var item in savedDices)
            {
                if (item == choice)
                {
                    value += int.Parse(item);
                }
            }
            player.Board.TotalScore += value;
            return value;
        }

        public static int SetOnePair(Player player, List<string> savedDices)
        {
            return 0;
        }
    }
}
