using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Client
    {
        public NetworkStream stream;
        public TcpClient client;
        public string UserId;
        Server server;

        public Client(NetworkStream Stream, TcpClient Client, Server server)
        {
            this.server = server;
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }
        public void Send(string Message)
        {
            byte[] message = Encoding.ASCII.GetBytes(Message);
            stream.Write(message, 0, message.Count());
        }
        public string Recieve(Queue<string> queueMessage)
        {
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            string recievedMessageString = Encoding.ASCII.GetString(recievedMessage);
            queueMessage.Enqueue(recievedMessageString);
            Console.WriteLine(recievedMessageString);
            return recievedMessageString;
        }
    }
}
