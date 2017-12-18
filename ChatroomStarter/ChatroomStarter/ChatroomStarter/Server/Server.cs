using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        public static Client client;
        TcpListener server;
        Dictionary<Client, int> user = new Dictionary<Client, int>();
        int userID = 0;
        Queue<string> queueMessage = new Queue<string>();
        Log log = new Log();

        public Server()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
            server.Start();
        }

        public void Run() //Single Responsibility Principle, this method threads the Accept Client method
        {
            Task.Run(() => AcceptClient());
        }

        private void AcceptClient()
        {
            while (true)
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                client = new Client(stream, clientSocket, this);
                AddToDictionary(client);
                Task.Run(() => Recieve(client));
            }
        }
        private void Send(string body)
        {
            Client temp;
            string message = body;
            log.WriteToLog(message);
            foreach (KeyValuePair<Client, int> userID in user)
            {
                temp = userID.Key;
                temp.Send(message);
            }
        }

        public void Recieve(Client client)
        {
            while (true)
            {
                try
                {
                    if (client.client.Connected)
                    {
                        string message = client.Recieve(queueMessage);
                        Task.Run(() => Send(message));
                    }
                }
                catch (Exception e)
                {
                    user.Remove(client);
                    Send("Someone has left the room");
                }
            }
        }

        public void AddToDictionary(Client client)
        {
            userID++;
            user.Add(client, userID);
        }
    }
}
