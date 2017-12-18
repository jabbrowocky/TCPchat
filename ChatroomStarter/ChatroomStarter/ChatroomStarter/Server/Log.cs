using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    class Log : Ilogger
    {
        StreamWriter file = new StreamWriter("log.txt", true);
        public void WriteToLog(string text) //Dependency Inversion Principle, this log method writes to the log for every send/receive/log in/log out
        {
            
            {
                file.WriteLine(text);
                
            }
        }
    }
}
