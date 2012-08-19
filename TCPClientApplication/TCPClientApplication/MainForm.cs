using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;

namespace TCPClientApplication
{
    public partial class MainForm : Form
    {
        private ClientHelper helper;
        private Random rand;
        private IWork work;

        private int simulatorCount = 0;

        public MainForm()
        {
            InitializeComponent();
            this.rand = new Random();
            this.work = new PrimeResolutionWork(this.rand);
            this.helper = new ClientHelper(this.rand, this.lbEventDiary, this.work);
        }

        private void log(string message)
        {
            lbEventDiary.Items.Add(message);
        }

        private void DoOperation( string operation )
        {
            try
            {
                helper.Connect();
                switch (operation)
                {
                    case CommunicationHelper.OP_TEST:
                        helper.TestOperation();
                        break;
                    case CommunicationHelper.OP_WORK:
                        helper.WorkOperation();
                        break;
                    case CommunicationHelper.OP_KILL:
                        helper.KillOperation();
                        break;
                }
                helper.Disconnect();
            }
            catch (SocketException se)
            {
                log("Server is not responding ("+se.Message+").");
            }
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            this.DoOperation(CommunicationHelper.OP_TEST);
        }

        private void bKill_Click(object sender, EventArgs e)
        {
            this.DoOperation(CommunicationHelper.OP_KILL);
        }

        private void bWork_Click(object sender, EventArgs e)
        {
            ClientHelper helper = new ClientHelper(this.rand, this.lbEventDiary, this.work);
            try
            {
                helper.Connect();
               
                Thread workThread = new Thread(helper.WorkOperationInThread);
                workThread.IsBackground = true;
                workThread.Start();

            }
            catch (SocketException se)
            {
                log("Server is not responding (" + se.Message + ").");
            }
        }

        private void bWorkNoThread_Click(object sender, EventArgs e)
        {
            this.DoOperation(CommunicationHelper.OP_WORK);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSimulator_Click(object sender, EventArgs e)
        {
            this.timerSimulatorBegin.Enabled = true;
        }

        private void timerSimulator_Tick(object sender, EventArgs e)
        {
            this.bTest_Click(sender, e);
        }

        private void timerSimulatorBegin_Tick(object sender, EventArgs e)
        {
            this.simulatorCount++;
            this.bWork_Click(sender, e);
            if (simulatorCount > 25)
            {
                this.timerSimulatorBegin.Enabled = false;
                this.timerSimulator.Enabled = true;
            }
        }

    }
}
