using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyThread
{
    class CMyThread
    {
        static int ThreadParam = 0;

        [ThreadStatic]
        static ConsoleColor textcolor;

        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Create a new thread.");
            Console.WriteLine("Mainthread (number:{0})",Thread.CurrentThread.GetHashCode());
            System.Console.WriteLine("### Threading.Thread ###");
            Thread[] newThread = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                CMyThread.ThreadParam = rand.Next(500, 5000);
                newThread[i] = new Thread(ThreadMethod);
                newThread[i].Name = "new thread "+i.ToString();
                newThread[i].IsBackground = true;
                newThread[i].Start();
                Thread.Sleep(1000);                
            }            
            //.NET 1.1: Thread newThread = new Thread(new ThreadStart(ThreadMethod));
            System.Console.ReadKey();
            System.Console.WriteLine("### Threading.ThreadPool ###");
            
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod), ConsoleColor.DarkBlue);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod), ConsoleColor.DarkRed);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod), ConsoleColor.DarkGreen);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod), ConsoleColor.Black);

            System.Console.ReadKey();
        }

        static void ThreadMethod()
        {
            int tempvar = CMyThread.ThreadParam;
            Console.WriteLine("{0}(number: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.GetHashCode(), tempvar);
            Thread.Sleep(tempvar);
            Console.WriteLine("{0} end: {1}", Thread.CurrentThread.GetHashCode(), tempvar.ToString());
        }

        static void ThreadPoolMethod(object state)
        {
            textcolor = (ConsoleColor)state;
            Console.ForegroundColor = textcolor;
            Console.WriteLine("Pool thread number: " + Thread.CurrentThread.ManagedThreadId);
            DisplayThreadData();
            DisplayNumbers();            
        }

        private static void DisplayThreadData()
        {
            Console.ForegroundColor = textcolor;
            Console.WriteLine("-- Pool thread data -- ");
            Console.WriteLine("\tPriority:\t\t{0}", Thread.CurrentThread.Priority);
            Console.WriteLine("\tCulture:\t\t{0}", Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("\tIsThreadPool?\t\t{0}", Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("\tState:\t\t\t{0}", Thread.CurrentThread.ThreadState);
            Console.WriteLine();
        }

        static void DisplayNumbers()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.ForegroundColor = textcolor;
                Console.WriteLine("Number value {0}", i);
                Thread.Sleep(250);
            }
        }

    }

}
