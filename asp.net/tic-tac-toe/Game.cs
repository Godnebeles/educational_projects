using System;
using System.Text;

namespace tic_tac_toe
{
    public class Game
    {
        private char[,] gameField;

        private Player player1;
        private Player player2;
        private Player currentPlayer;
        private GameStatus gameStatus = GameStatus.playing;
        int currentStep = 0;

        public Game(int fieldSize, Player player1, Player player2)
        {
            gameField = new char[fieldSize, fieldSize];
            this.player1 = player1;
            this.player2 = player2;
            this.currentPlayer = player1;
        }
        
        public void PrintConsoleField(Client player)
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    char whatPrint = gameField[i, j] == '\0' ? ' ' : gameField[i, j];
                    player.writer.Write(("| " + whatPrint + " |"));
                }
                player.writer.WriteLine();
            }
            player.writer.WriteLine();
        }


        private bool ChekWinner(char symbol)
        {
            // gorizontaLS
            if (gameField[0, 0] == symbol && gameField[0, 1] == symbol && gameField[0, 2] == symbol)
                return true;
            if (gameField[1, 0] == symbol && gameField[1, 1] == symbol && gameField[1, 2] == symbol)
                return true;
            if (gameField[2, 0] == symbol && gameField[2, 1] == symbol && gameField[2, 2] == symbol)
                return true;
            // VERTICALS
            if (gameField[0, 0] == symbol && gameField[1, 0] == symbol && gameField[2, 0] == symbol)
                return true;
            if (gameField[0, 1] == symbol && gameField[1, 1] == symbol && gameField[2, 1] == symbol)
                return true;
            if (gameField[0, 2] == symbol && gameField[1, 2] == symbol && gameField[2, 2] == symbol)
                return true;
            // DIAGONALS
            if (gameField[0, 0] == symbol && gameField[1, 1] == symbol && gameField[2, 2] == symbol)
                return true;
            if (gameField[0, 2] == symbol && gameField[1, 1] == symbol && gameField[2, 0] == symbol)
                return true;
            return false;
        }


        public Player GetCurrentPlayer()
        {
            return currentPlayer;
        }

        private bool EmptyCell(char elem)
        {
            if (elem == '\0')
                return true;
            else
                return false;
        }

        public bool GameIsEnd()
        {
            return gameStatus != GameStatus.playing;
        }

        public string GetGameStatus()
        {
            if (gameStatus == GameStatus.playing)
                return "Game is continue... Step player's " + currentPlayer.Name;
            else if (gameStatus == GameStatus.draw)
                return "Game ended with draw...";
            else
                return "Game ended. " + currentPlayer.Name + " is Winner";
        }


        public void MakeStep(int x, int y)
        {
            if (gameStatus != GameStatus.playing)
            {
                GetGameStatus();
                throw new Exception(GetGameStatus());
            }

            if (EmptyCell(gameField[x, y]))
            {
                gameField[x, y] = currentPlayer.PlayerSymbol;
                if (currentPlayer.PlayerIdentificator == player1.PlayerIdentificator)
                {
                    currentPlayer = player2;
                }
                else
                {
                    currentPlayer = player1;
                }
            }
            else
            {
                throw new Exception("This cell is lock");
            }
            if (ChekWinner(player1.PlayerSymbol))
            {
                gameStatus = GameStatus.wonPlayer1;
                currentPlayer = player1;
            }
            else if (ChekWinner(player2.PlayerSymbol))
            {
                gameStatus = GameStatus.wonPlayer2;
                currentPlayer = player2;
            }

            if (currentStep == gameField.GetLength(0) * gameField.GetLength(0))
                gameStatus = GameStatus.draw;

            currentStep++;
        }

    }
}
