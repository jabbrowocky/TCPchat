using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Log
    {
        public void WriteToLog(string text) //Dependency Inversion Principle, this log method writes to the log for every send/receive/log in/log out
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Chez\Desktop\CSharp\TCPChat\ChatroomStarter\ChatroomStarter\ChatroomStarter\Log\log.txt", true))
            {
                file.WriteLine(text);
            }
        }
    }
}
