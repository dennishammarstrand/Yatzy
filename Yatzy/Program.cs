using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    class Program
    {
        public static List<Player> players;
        public static int currentTurn = 0;
        public static List<int> savedDices;
        public static int dicesToThrow = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Lets play yatzy!");
            players = PlayerActions.EnterPlayerNames(PlayerActions.ChooseNumberOfPlayers());
            Console.Clear();
            while (true)
            {
                string option = Menu.ShowMenu($"Yatzy! {players[currentTurn].Name} turn to throw!", new[]
                {
                    "Throw Dices"
                });
                if (option == "Throw Dices") 
                {
                    Menu.PrintGameBoard(players, currentTurn);
                    savedDices = Menu.ShowMultiMenu("Select what dices to save!", ThrowDices.Throw(dicesToThrow)).ToList();
                    dicesToThrow -= savedDices.Count;
                    for (int i = 0; i < 2; i++)
                    {
                        int[] thisTurnsSaved = Menu.ShowMultiMenu("Select what dices to save!", ThrowDices.Throw(dicesToThrow));
                        if (thisTurnsSaved.Length != 0)
                        {
                            dicesToThrow -= thisTurnsSaved.Length;
                        }
                        savedDices.AddRange(thisTurnsSaved);
                    }
                    bool pointSet = true;
                    while (pointSet)
                    {
                        try
                        {
                            PlayerActions.SetPoint(players[currentTurn], savedDices);
                            pointSet = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (PlayerActions.CheckForBonus(players[currentTurn]))
                    {
                        players[currentTurn].Board.Bonus = 50;
                        players[currentTurn].Board.TotalScore += 50;
                    }
                }
                if (currentTurn == players.Count - 1)
                {
                    currentTurn = 0;
                    dicesToThrow = 5;
                    savedDices.Clear();
                }
                else
                {
                    currentTurn++;
                    dicesToThrow = 5;
                    savedDices.Clear();
                }
            }
        }        
    }
}
