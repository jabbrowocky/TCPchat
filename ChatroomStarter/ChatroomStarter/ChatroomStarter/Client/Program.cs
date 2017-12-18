﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 9999);
            
            Parallel.Invoke(() =>
            {
                while (true)
                {
                    client.Send();
                }
            },
            () =>
            {
                while (true)
                {
                    client.Recieve();
                }
            });            
        }
    }
}
