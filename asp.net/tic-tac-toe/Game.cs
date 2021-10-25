using System;
using System.Text;

namespace tic_tac_toe
{

    public enum GameStatus
    {
        playing,
        wonPlayer1,
        wonPlayer2,
        draw
    }

    public enum PlayerStep
    {
        player1,
        player2
    }

    struct Player
    {
        private char player1;
        private char player2;
        public PlayerStep currentPlayer;
        
        public Player(char player1, char player2)
        {
            currentPlayer = PlayerStep.player1;
            this.player1 = player1;
            this.player2 = player2;
        }

        public char Player1 { get { return player1; } }
        public char Player2 { get { return player2; } }

        public PlayerStep CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
    }
    

    public class Game
    {
        private char[,] gameField;

        private Player players;

        private GameStatus gameStatus = GameStatus.playing;
        int currentStep = 0;

        public Game(int fieldSize, char player1, char player2)
        {
            gameField = new char[fieldSize, fieldSize];
            players = new Player(player1, player2);
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

        
        public char GetCurrentPlayer()
        {
            if (players.currentPlayer == PlayerStep.player1)
            {
                return players.Player1;
            }
            else
            {
                return players.Player2;
            }
        }

        public PlayerStep GetCurrentPlayerStep()
        {
            return players.CurrentPlayer;
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
            return gameStatus == GameStatus.draw || gameStatus == GameStatus.wonPlayer1 ||
                   gameStatus == GameStatus.wonPlayer2;
        }
        
        public string GetGameStatus()
        {
            if (gameStatus == GameStatus.wonPlayer1)
                return "Game ended. " + players.Player1 + " is Winner";
            else if (gameStatus == GameStatus.wonPlayer2)
                return "Game ended. " + players.Player2 + " is Winner";
            else if (gameStatus == GameStatus.draw)
                return "Game ended with draw";
            else
                return "Game is continue";
        }


        public void MakeStep(int x, int y)
        {
            if (gameStatus == GameStatus.wonPlayer1 || gameStatus == GameStatus.wonPlayer2 || gameStatus == GameStatus.draw)
            {
                GetGameStatus();
                throw new Exception(GetGameStatus());
            }

            if (EmptyCell(gameField[x, y]))
            {
                gameField[x, y] = GetCurrentPlayer();
                if (players.currentPlayer == PlayerStep.player1)
                {
                    players.CurrentPlayer = PlayerStep.player2;
                }
                else
                {
                    players.currentPlayer = PlayerStep.player1;
                }             
            }
            else
            {
                throw new Exception("This cell is lock");
            }
            if (ChekWinner(players.Player1))
            {
                gameStatus = GameStatus.wonPlayer1;
            }
            else if (ChekWinner(players.Player2))
            {
                gameStatus = GameStatus.wonPlayer2;
            }
            
            if(currentStep == gameField.GetLength(0) * gameField.GetLength(0))
                gameStatus = GameStatus.draw;
            
            currentStep++;
        }

    }
}
