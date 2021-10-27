using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace tic_tac_toe
{
    public class Server
    {
        private TcpListener server = null;
        private Client[] clients = new Client[2];
        private Game game = null;

        private void CreateGame()
        {
            char[] charSymbols = new char[2];
            string[] namePlayers = new string[2];

            for (int i = 0; i < clients.Length; ++i)
            {
                try
                {
                    Console.Write("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    clients[i] = new Client(client);

                    clients[i].writer.WriteLine("Your name: ");
                    namePlayers[i] = clients[i].reader.ReadLine();

                    clients[i].writer.WriteLine("Write symbol: ");
                                    
                    charSymbols[i] = Convert.ToChar(clients[i].reader.ReadLine());
                    if (charSymbols[0] == charSymbols[1])
                    {
                        throw new Exception("Player entered bad symbol...");
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"CreateGame: {e}");
                    System.Console.WriteLine("Try again...");
                    i--;
                }

            }

            Player player1 = new Player(namePlayers[0], charSymbols[0], PlayerIdentificator.player1);
            Player player2 = new Player(namePlayers[1], charSymbols[1], PlayerIdentificator.player2);

            clients[0].Player = player1;
            clients[1].Player = player2;
            game = new Game(3, player1, player2);
        }

        private void PrintFieldAllPlayers()
        {
            for (int i = 0; i < clients.Length; i++)
            {
                game.PrintConsoleField(clients[i]);
            }
        }

        private void StartGame()
        {
            while (!game.GameIsEnd())
            {
                try
                {
                    Client currentPlayer = GetCurrentClient(game.GetCurrentPlayer().PlayerIdentificator);
                    //Client waitingPlayer = GetCurrentClient(game.GetCurrentPlayer().PlayerIdentificator);

                    PrintFieldAllPlayers();

                    SayStatusGameAllPlayer();

                    currentPlayer.writer.WriteLine("Your step: ");
                    string[] coors = currentPlayer.reader.ReadLine().Split();
                    game.MakeStep(int.Parse(coors[0]), int.Parse(coors[1]));
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"Start Game: {e}");
                    System.Console.WriteLine("Try again...");
                }

            }

            PrintFieldAllPlayers();
            SayStatusGameAllPlayer();
        }

        private void SayStatusGameAllPlayer()
        {
            for(int i = 0; i < clients.Length; i++)
                clients[i].writer.WriteLine(game.GetGameStatus());
        }

        private Client GetCurrentClient(PlayerIdentificator pi)
        {
            if (pi == clients[0].GetPlayerIdentificator())
                return clients[0];
            else
                return clients[1];
        }

        private Client GetWaitingClient(PlayerIdentificator pi)
        {
            if (pi == clients[0].GetPlayerIdentificator())
                return clients[1];
            else
                return clients[0];
        }

        public void CreateGame(string ip, int portNumber)
        {
            while (true)
            {
                try
                {
                    IPAddress localAddr = IPAddress.Parse(ip);
                    Int32 port = portNumber;

                    server = new TcpListener(localAddr, port);

                    server.Start();
                    Console.WriteLine("Server started....");

                    CreateGame();

                    StartGame();
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketExeption: {e}");
                }
                finally
                {
                    server.Stop();
                }
            }

        }
    }
}