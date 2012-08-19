using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TCPServerApplication
{
    public class Program
    {

        public static int incrementOpCount(int opCount)
        {
            if (opCount > 20)
            {
                opCount = 0;
            }
            else
            {
                opCount++;
            }
            return opCount;
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();

            System.Console.SetWindowSize(80,50);

            Work work = new Work(rand);
            ServerHelper helper = new ServerHelper(work);
            helper.StartListener();
            int opCount = 0;
            string operation = "";
            do {
                operation = helper.WaitingForClient(opCount);
                opCount = Program.incrementOpCount(opCount);
            } while (!CommunicationHelper.OP_KILL.Equals(operation));
            System.Console.WriteLine("Kill Server by client..");
            helper.StopListener();
        }

    }
}
