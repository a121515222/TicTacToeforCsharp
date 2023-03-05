using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLogic
{
    public class TicTacToeGame
    {
        public int[] GameData
        {
            get; set; 
        }
        public TicTacToeGame()
        {
            GameData = new int[9];
            for (int i = 0; i < 9; i++)
            {
                GameData[i] = 0;
            }
        }
        public void ShowGame() 
        {
            for (int i = 0; i < GameData.Length; i++)
            {
                switch (GameData[i])
                {
                    case 1:
                        Console.Write("O");
                        break;
                    case 2:
                        Console.Write("X");
                        break;
                    default:
                        Console.Write(".");
                        break;
                }
                if ((i + 1) % 3 == 0) {
                    Console.WriteLine();
                }
            }
        }
        public void PlayerTurn() 
        {
            while (true)
            {
                int userTypeNumber = InputValid();
                if (GameData[userTypeNumber] == 0)
                {
                    GameData[userTypeNumber] = 1;
                    Console.WriteLine($"Player type {userTypeNumber}");
                    break;
                }
                else
                {
                    Console.WriteLine("Player can't type the place that already occupied");
                }
            }
            ShowGame();
        }
        private static int InputValid()
        {
            var isValid = false;
            int userTypeNumber = -1;
            while (!isValid)
            {
                Console.WriteLine("Please type one number, 0 - 8");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out userTypeNumber);
                if (!isValid)
                {
                    Console.WriteLine("Please type one number, 0 - 8,without space or latter ,punctuation");
                }
            }
            return userTypeNumber;
        }
        public void ComputerTurn()
        {
            while (true) {
                Random randomNum = new Random();
                var computerPlay = randomNum.Next(9);
                if (GameData[computerPlay] == 0)
                {
                    GameData[computerPlay] = 2;
                    Console.WriteLine($"Computer type {computerPlay}");
                    break;
                }
            }
            ShowGame();
        }
        public bool IsSomeOneWin()
        {
            if (GameData[0] == GameData[1] && GameData[0] == GameData[2] && GameData[0] != 0)
            {
                return true;
            }
            else if (GameData[3] == GameData[4] && GameData[3] == GameData[5] && GameData[3] != 0)
            {
                return true;
            }
            else if (GameData[6] == GameData[7] && GameData[6] == GameData[8] && GameData[6] != 0)
            {
                return true;
            }
            else if (GameData[0] == GameData[3] && GameData[0] == GameData[6] && GameData[0] != 0)
            {
                return true;
            }
            else if (GameData[1] == GameData[4] && GameData[1] == GameData[7] && GameData[1] != 0)
            {
                return true;
            }
            else if (GameData[2] == GameData[5] && GameData[2] == GameData[8] && GameData[2] != 0)
            {
                return true;
            }
            else if (GameData[0] == GameData[4] && GameData[0] == GameData[8] && GameData[0] != 0)
            {
                return true;
            }
            else if (GameData[2] == GameData[4] && GameData[2] == GameData[6] && GameData[2] != 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public bool IsDraw()
        {
            int[] notPlay = GameData.Where(x => x == 0).ToArray();
            if (notPlay.Length == 0) 
            {
                return true;
            } else
            {
                return false;
            }
        }
        public void SwitchPlayUntileEnd()
        {
            while (true)
            {
                PlayerTurn();
                if (IsSomeOneWin())
                {
                    Console.WriteLine("Player Win");
                    break;
                }
                ComputerTurn();
                if (IsSomeOneWin())
                {
                    Console.WriteLine("Computer Win");
                    break;
                }
                if (IsDraw())
                {
                    Console.WriteLine("Draw!!");
                    break;
                }
            }
        }
    }

}
