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
        private Client[] players = new Client[2];
        private Game game = null;

        private void CreateGame()
        {
            char[] charPlayers = new char[2];

            for (int i = 0; i < players.Length; ++i)
            {
                Console.Write("Waiting for a connection... ");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");


                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                players[i] = new Client(client);

                writer.Write("Write symbol: ");

                string symbol = reader.ReadLine();

                charPlayers[i] = Convert.ToChar(symbol);
            }

            game = new Game(3, charPlayers[0], charPlayers[1]);
        }

        private void PrintFieldAllPlayers()
        {
            for (int i = 0; i < players.Length; i++)
            {
                game.PrintConsoleField(players[i]);
            }
        }

        private void StartGame()
        {
            while (!game.GameIsEnd())
            {
                int i = 0;
                PrintFieldAllPlayers();
                
                if (game.GetCurrentPlayerStep() == PlayerStep.player2)
                    i = 1;
                
                players[i].writer.Write("Your step: ");
                string[] coors = players[i].reader.ReadLine().Split();
                game.MakeStep(int.Parse(coors[0]), int.Parse(coors[1]));
            }
            
            PrintFieldAllPlayers();
            players[0].writer.WriteLine(game.GetGameStatus());
            players[1].writer.WriteLine(game.GetGameStatus());
        }

        public void CreateGame(string ip, int portNumber)
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