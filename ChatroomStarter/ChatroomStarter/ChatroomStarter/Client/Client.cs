using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        string defaultServerIP = "127.0.0.1";

        public Client(string IP, int port)
        {
            IP = SetServerIP();
            
            clientSocket = new TcpClient();
            clientSocket.Connect(IPAddress.Parse(IP), port);
            stream = clientSocket.GetStream();
        }
        
        public string SetServerIP()
        {
            Console.WriteLine("What is the IP of the server you would like to connect to?");
            defaultServerIP = Console.ReadLine();
            return defaultServerIP;
        }
        
        public void Send()
        {
            //while (true)
            //{
            string messageString = UI.GetInput();
            byte[] message = Encoding.ASCII.GetBytes(messageString);
            stream.Write(message, 0, message.Count());
            //}
        }

        public void Recieve()
        {
            //while (true)
            //{
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
            //}
        }

        //public void Update()
        //{
        //    string messageString = //username "has entered the room"
        //    byte[] message = Encoding.ASCII.GetBytes(messageString);
        //    stream.Write(message, 0, message.Count());
        //}
    }
}
