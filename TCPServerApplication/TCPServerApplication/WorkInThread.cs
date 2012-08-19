using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace TCPServerApplication
{
    public class WorkInThread
    {

        private Socket socket;
        private int opCount;
        private WorkItem item;
        private string operation;
        private Work work;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void log(string message, int x, int y)
        {
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.SetCursorPosition(x, y + Work.MAXITEM + 2);
            System.Console.Write(message + " ");
        }

        public WorkInThread(Socket socket, int opCount, WorkItem item, string operation, Work work)
        {
            this.socket = socket;
            this.opCount = opCount;
            this.item = item;
            this.operation = operation;
            this.work = work;
        }

        private string GetMessageFromClient()
        {
            byte[] buffer = new byte[CommunicationHelper.BUFFERSIZE];
            int k = socket.Receive(buffer);
            StringBuilder str = new StringBuilder(CommunicationHelper.BUFFERSIZE);
            for (int i = 0; i < k; i++)
            {
                str.Append(Convert.ToChar(buffer[i]));
            }
            return str.ToString();
        }

        private void SendMessageToClient(string message)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            socket.Send(encoding.GetBytes(message));
        }

        private void TestOperation()
        {
            WorkInThread.log("[Test Operation]", 0, opCount);

            this.SendMessageToClient("ping");
            string pong = this.GetMessageFromClient();
            if ("pong".Equals(pong))
            {
                WorkInThread.log("ping-pong successful                           ", 20, opCount);
            }
        }

        private void WorkOperation()
        {
            WorkInThread.log("[Work Operation]", 0, opCount);

            if (item != null)
            {
                WorkInThread.log("Send parameter to client (" + item.Parameter + ")", 20, opCount);
                this.SendMessageToClient(item.Parameter.ToString());
                item.DoWork();
                item.Result = this.GetMessageFromClient();
            }
            else
            {
                WorkInThread.log("No available work for client!                        ", 20, opCount);
                this.SendMessageToClient("-1");
            }
        }

        public void run()
        {
            Work.Print(this.work.Items);
            if (CommunicationHelper.OP_TEST.Equals(this.operation))
            {
                this.TestOperation();
            }
            if (CommunicationHelper.OP_WORK.Equals(this.operation))
            {
                this.WorkOperation();
            }
            socket.Close();
        }


    }
}
