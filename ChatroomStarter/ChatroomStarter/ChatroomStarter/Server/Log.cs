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
        public void WriteToLog(string text) //Dependency Inversion Principle: the server is no longer dependent on THIS specific logger, it can use any logger of type Ilogger.
        {
            
            {
                file.WriteLine(text);
                
            }
        }
    }
}
