using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;

namespace TCPClientApplication
{
    public class ClientHelper
    {
        private ListBox logger;

        private TcpClient client;
        private Stream stream;
        private StringBuilder response;

        private Random rand;
        private IWork work;

        public string Response
        {
            get { 
                return this.response.ToString(); 
            }
        }

        public ClientHelper(Random rand, ListBox logger, IWork work)
        {
            this.rand = rand;
            this.logger = logger;
            this.response = new StringBuilder(200);
            this.work = work;
        }

        public void Connect()
        {
            this.client = new TcpClient();
            this.client.Connect(CommunicationHelper.HOST, CommunicationHelper.PORT);
            this.stream = this.client.GetStream();
        }

        public void Disconnect()
        {
            this.client.Close();
        }

        private void log( string message )
        {
            logger.Items.Add(message);
        }

        private void logThread(string message)
        {
            this.response.Append(message+"\n");
        }

        private int parseParameter(string parameter)
        {
            int ret = -1;
            try
            {
                ret = Int32.Parse(parameter);
            }
            catch (FormatException fe)
            {
                this.log("Can not parse response (parameter:" + parameter + ") " + fe.Message);
            }
            return ret;
        }

        public void TestOperation()
        {
            // log("Test Operation is in progress...");
            this.SendMessageToServer(this.stream, CommunicationHelper.OP_TEST);
            string ping = this.GetMessageFromServer(this.stream);
            if ("ping".Equals(ping))
            {
                log("Received ping...");
                this.SendMessageToServer(this.stream,"pong");
                log("Send pong...");
            }
            // log("Test Operation is done.");
        }

        public void WorkOperation()
        {
            // log("Work Operation is in progress...");
            this.SendMessageToServer(this.stream, CommunicationHelper.OP_WORK);
            string parameter = this.GetMessageFromServer(this.stream);
            int intParameter = this.parseParameter(parameter);
            if (intParameter >= 0)
            {
                log("Get parameter from Server: " + intParameter);
                string result = work.Process(intParameter);
                log("Send Result to Server: " + result);
                this.SendMessageToServer(this.stream, result);
            }
            else
            {
                logThread("No Work to do...");
            }
            // log("Work Operation is done.");
        }

        public void WorkOperationInThread()
        {
            // logThread("Work Operation is in progress...");
            this.SendMessageToServer(this.stream, CommunicationHelper.OP_WORK);
            string parameter = this.GetMessageFromServer(this.stream);
            int intParameter = this.parseParameter(parameter);
            if (intParameter >= 0)
            {
                logThread("Get parameter from Server: " + intParameter);
                string result = work.Process(intParameter);
                logThread("Send Result to Server: " + result);
                this.SendMessageToServer(this.stream, result);
            }
            else
            {
                logThread("No Work to do...");
            }
            // logThread("Work Operation is done.");
            this.Disconnect();
        }

        public void KillOperation()
        {
            // log("KillOperation is in progress...");
            this.SendMessageToServer(this.stream, CommunicationHelper.OP_KILL);
            log("KillOperation is done.");
        }

        private string GetMessageFromServer(Stream stream)
        {
            byte[] buffer = new byte[CommunicationHelper.BUFFERSIZE];
            int k = stream.Read(buffer, 0, CommunicationHelper.BUFFERSIZE);
            StringBuilder str = new StringBuilder(CommunicationHelper.BUFFERSIZE);
            for (int i = 0; i < k; i++)
            {
                str.Append(Convert.ToChar(buffer[i]));
            }
            return str.ToString();
        }

        private void SendMessageToServer(Stream stream, string message)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }

    }
}
