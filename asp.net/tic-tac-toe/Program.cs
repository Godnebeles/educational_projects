using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace tic_tac_toe
{
    
    class Program
    {
        //private GameStatus status = GameStatus.playing;

        static void Main(string[] args)
        {

            Server server = new Server();
            
            server.CreateGame(args[0], int.Parse(args[1]));
            
        }

    
    }
}
