using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPServerApplication
{
    public class ServerHelper : System.Object
    {
        private IPAddress ipAddress;
        private TcpListener listener;

        private Work work;

        public EndPoint LocalEndPoint
        {
            get
            {
                return this.listener.LocalEndpoint;
            }
        }

        public ServerHelper(Work work)
        {
            this.ipAddress = IPAddress.Parse(CommunicationHelper.HOST);
            this.listener = new TcpListener(this.ipAddress, CommunicationHelper.PORT);
            this.work = work;
        }

        public void StartListener()
        {
            this.listener.Start();
        }

        public void StopListener()
        {
            this.listener.Stop();
        }

        private string GetMessageFromClient(Socket socket)
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

        private void SendMessageToClient(Socket socket, string message)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            socket.Send(encoding.GetBytes(message));
        }

        public string WaitingForClient(int opCount)
        {
            Socket socket = this.listener.AcceptSocket();
     
            string operation = this.GetMessageFromClient(socket);

            WorkItem item = null;
            if (CommunicationHelper.OP_WORK.Equals(operation))
            {
                item = this.work.GetRandomCreatedWorkItem();
            }
            WorkInThread instance = new WorkInThread(socket, opCount, item, operation, this.work);

            Thread workThread = new Thread(instance.run);
            workThread.IsBackground = true;
            workThread.Start();

            return operation;
        }


    }
}