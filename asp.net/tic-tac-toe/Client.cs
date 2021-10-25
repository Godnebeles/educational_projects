using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace tic_tac_toe
{
    public class Client
    {
        public TcpClient client = null;
        public StreamReader reader = null;
        public StreamWriter writer = null;
        private Player player;

        public Client(TcpClient client)
        {
            this.client = client;
            NetworkStream stream = client.GetStream();
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream);
            writer.AutoFlush = true;
        }

        public PlayerIdentificator GetPlayerIdentificator()
        {
            return player.PlayerIdentificator;
        }

        public Player Player { set { player = value; } }
    }
}