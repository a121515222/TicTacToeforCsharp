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
    }
}