
using TicTacToeLogic;
namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            game.ShowGame();
            game.SwitchPlayUntileEnd();

        }
    }
}