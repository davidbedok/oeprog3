using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadDemo
{
    public class Program
    {
        private static int threadParam = 0;

        [ThreadStatic]
        private static ConsoleColor textcolor;

        private static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine(Program.printThreadInfo(Thread.CurrentThread));
            // Program.simpleThread(rand);
            // Program.simpleThreadWithParam(rand);
            // Program.threadInClassWithParam(rand);
            // Program.threadPool();
            Console.ReadKey();
        }

        private static String printThreadInfo( Thread thread )
        {
            StringBuilder info = new StringBuilder(150);
            int threadId = thread.ManagedThreadId;
            info.AppendLine("THREAD INFO (" + threadId + ")");
            info.AppendLine("[" + threadId + "] Name: " + thread.Name);
            info.AppendLine("[" + threadId + "] ManagedThreadId: " + thread.ManagedThreadId);
            info.AppendLine("[" + threadId + "] HashCode: " + thread.GetHashCode());
            info.AppendLine("[" + threadId + "] IsAlive: " + thread.IsAlive);
            info.AppendLine("[" + threadId + "] IsBackground: " + thread.IsBackground);
            info.AppendLine("[" + threadId + "] IsThreadPoolThread: " + thread.IsThreadPoolThread);
            info.AppendLine("[" + threadId + "] Priority: " + thread.Priority);
            info.AppendLine("[" + threadId + "] ThreadState: " + thread.ThreadState);
            return info.ToString();
        }

        private static void simpleThread(Random rand)
        {
            Console.WriteLine("### Simple Thread ###");
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                // mivel a hasznalt ThreadStart delegate-nek nincs parametere
                // valamilyen modon megprobalunk parametert atadni a metodusnak
                // A valasztott modszer egy (statikus) field, melynek azonban hibai vannak!
                Program.threadParam = rand.Next(500, 5000);
                Console.WriteLine("[MAIN] Generated static value: " + Program.threadParam);

                threads[i] = new Thread(threadMethod);
                // ThreadStart delegate
                // public delegate void ThreadStart ()

                threads[i].Name = "THREAD_" + (i + 1).ToString();
                threads[i].IsBackground = true;
                threads[i].Start();

                // Ha nincs itt a Thread.Sleep(1000), akkor:
                // lathatjuk hogy a [MAIN] ciklusa tobbszor lefut addig, amig valamelyik szal 
                // elindul! Ez azt fogja okozni, hogy a generalt parameterek elvesznek, es tobb szalnak
                // lehet azonos 'parametere'. Nyilvan ez a parameter veszes es keveredes nem vart esemeny..

                Thread.Sleep(1000);
                // ha idetesszuk, akkor adunk az utemezonek 1 mp-et arra, hogy az eppen aktualisan start()-olt
                // szalat el is inditsa! igy a parameter veszes es keveredes nagy valoszinuseggel nem fog elokerulni
                // azonban a megoldas tovabbra is csunya es nagyon bizonytalan
            }
        }

        private static void threadMethod()
        {
            int tempvar = Program.threadParam;
            Console.WriteLine("[{0}] START (theadId: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, tempvar);
            Thread.Sleep(tempvar);
            Console.WriteLine("[{0}] END (theadId: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, tempvar);
        }

        private static void simpleThreadWithParam(Random rand)
        {
            Console.WriteLine("### Simple Thread with param ###");
            Thread[] threads = new Thread[5];
            int randValue = 0;
            for (int i = 0; i < 5; i++)
            {
                randValue = rand.Next(500, 5000);
                Console.WriteLine("[MAIN] Generated rand value: " + randValue);

                threads[i] = new Thread(threadMethodParam);
                // ParameterizedThreadStart delegate
                // public delegate void ParameterizedThreadStart(Object obj)

                threads[i].Name = "THREAD_" + (i + 1).ToString();
                threads[i].IsBackground = true;

                // itt adjuk at neki az object tipusu parametert!
                threads[i].Start(randValue);
            }
        }

        private static void threadMethodParam(object state)
        {
            int tempvar = (int)state;
            Console.WriteLine("[{0}] START (threadId: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, tempvar);
            Thread.Sleep(tempvar);
            Console.WriteLine("[{0}] END (threadId: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, tempvar);
        }

        public static void threadInClassWithParam(Random rand)
        {
            Console.WriteLine("### Thread in class with param ###");
            Thread[] threads = new Thread[5];
            int randValue = 0;
            for (int i = 0; i < 5; i++)
            {
                randValue = rand.Next(500, 5000);
                Console.WriteLine("[MAIN] Generated rand value: " + randValue);
                Worker worker = new Worker(randValue);
                
                threads[i] = new Thread(worker.run);
                threads[i].Name = "THREAD_" + (i + 1).ToString();
                threads[i].IsBackground = true;
                threads[i].Start();
            }
        }

        private static void threadPool() {
            System.Console.WriteLine("### Thread pool ###");  
            ThreadPool.QueueUserWorkItem(new WaitCallback(threadPoolMethod), ConsoleColor.DarkBlue);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(threadPoolMethod), ConsoleColor.DarkRed);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(threadPoolMethod), ConsoleColor.DarkGreen);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(threadPoolMethod), ConsoleColor.Gray);
        }

        private static void threadPoolMethod(object state)
        {
            Program.textcolor = (ConsoleColor)state;
            Console.ForegroundColor = Program.textcolor;
            Console.WriteLine("[" + Thread.CurrentThread.ManagedThreadId + "] Pool thread");
            // nyilvanvaloan igy at tudjuk adni a parametert:
            Program.DisplayThreadData(textcolor);
            // de a ThreadStatic miatt meg tudjuk oldani a thread statikus valtozoval is!
            Program.DisplayNumbers();            
        }

        private static void DisplayThreadData(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(Program.printThreadInfo(Thread.CurrentThread));
        }

        private static void DisplayNumbers()
        {
            for (int i = 0; i <= 5; i++)
            {
                // bar az ertekadas es a kiiras egymas utani utasitas, a ketto kozott egy masik szal uj
                // erteket adhat a ForegroundColor-nak, es igy a beallitott szinunk elveszik.
                Console.ForegroundColor = Program.textcolor;
                Console.WriteLine("Number value {0}", i);
                Thread.Sleep(250);
                // ez a szinvalto hiba nem a Thread static hibaja nyilvanvaloan, hanem hogy a Thread static erteket atadjuk egy nem thread static 
                // ForegroundColor-nak!
            }
        }

    }

}
