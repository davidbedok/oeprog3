using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyThread
{
    public class ClassRunInThead
    {

        private int parameter;

        public ClassRunInThead(int parameter)
        {
            this.parameter = parameter;
        }

        public void run()
        {
            Console.WriteLine("[{0}] START (number: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, parameter);
            Thread.Sleep(parameter);
            Console.WriteLine("[{0}] END (number: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, parameter);
        }

    }
}
