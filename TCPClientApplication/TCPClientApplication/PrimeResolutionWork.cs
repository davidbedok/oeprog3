using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

namespace TCPClientApplication
{
    public class PrimeResolutionWork : IWork
    {

        private static readonly int MAXWORKTIME = 10000;

        private Random rand;

        public PrimeResolutionWork(Random rand)
        {
            this.rand = rand;
        }

        public string Process(int param)
        {
            string ret = "";
            double sqrtLimit = Math.Sqrt(param);
            int tmpDivide = 2;
            int num = 1;
            do
            {              
                if (param % tmpDivide == 0)
                {
                    Thread.Sleep(this.rand.Next(PrimeResolutionWork.MAXWORKTIME));
                    ret += tmpDivide;
                    param = param / tmpDivide;
                    num++;
                    if (param > 1)
                    {
                        ret += " * ";
                    }
                }
                else
                {
                    tmpDivide++;
                    if ((num == 1) && (tmpDivide > sqrtLimit))
                    {
                        ret += "Prime";
                        param = 1;
                    }
                }
            } while (param > 1);
            return ret;
        }

    }
}
