using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadDemo
{
    public class Worker
    {

        private int parameter;

        public Worker(int parameter)
        {
            this.parameter = parameter;
        }

        public void run()
        {
            Console.WriteLine("[{0}] START (threadId: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, parameter);
            Thread.Sleep(parameter);
            Console.WriteLine("[{0}] END (threadId: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, parameter);
        }

    }
}
