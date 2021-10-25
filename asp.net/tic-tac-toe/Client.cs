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
        public TcpClient player = null;
        public StreamReader reader = null;
        public StreamWriter writer = null;
        
        public Client(TcpClient client)
        {
            player = client;
            
            NetworkStream stream = client.GetStream();
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream);
            writer.AutoFlush = true;
        }

        
    }
}