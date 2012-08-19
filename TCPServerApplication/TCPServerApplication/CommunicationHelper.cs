using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPServerApplication
{
    public class CommunicationHelper
    {
        public static readonly string HOST = "127.0.0.1";
        public static readonly int PORT = 10001;
        public static readonly int BUFFERSIZE = 100;

        public static readonly string OP_TEST = "test";
        public static readonly string OP_KILL = "kill";
        public static readonly string OP_WORK = "work"; 
    }
}
