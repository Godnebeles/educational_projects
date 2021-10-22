using System;

namespace tic_tac_toe
{
    class Program
    {
        private GameStatus status = GameStatus.playing;
        static void Main(string[] args)
        {
            Game ticTacToe = new Game(3, '1', '%');
            ticTacToe.PrintConsoleField();
            
            ticTacToe.MakeStep(0, 0);
            ticTacToe.PrintConsoleField();
            System.Console.WriteLine(ticTacToe.GetGameStatus());
            ticTacToe.MakeStep(1, 0);
            ticTacToe.PrintConsoleField();
            ticTacToe.MakeStep(0, 1);
            ticTacToe.PrintConsoleField();
            ticTacToe.MakeStep(2, 0);
            ticTacToe.PrintConsoleField();
            ticTacToe.MakeStep(0, 2);
            ticTacToe.PrintConsoleField();
            System.Console.WriteLine(ticTacToe.GetGameStatus());
            ticTacToe.MakeStep(0, 2); 
        }

    
    }
}
