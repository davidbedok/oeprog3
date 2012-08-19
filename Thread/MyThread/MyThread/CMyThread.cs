using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyThread
{
    public class CMyThread
    {
        private static int ThreadParam = 0;

        [ThreadStatic]
        private static ConsoleColor textcolor;

        public static void printCurrentThreadInfo()
        {
            int tid = Thread.CurrentThread.ManagedThreadId;
            System.Console.WriteLine("[" + tid + "] # CURRENT THREAD INFO");
            System.Console.WriteLine("[" + tid + "] Name: " + Thread.CurrentThread.Name);
            System.Console.WriteLine("[" + tid + "] ManagedThreadId: " + Thread.CurrentThread.ManagedThreadId);
            System.Console.WriteLine("[" + tid + "] HashCode: " + Thread.CurrentThread.GetHashCode());
            System.Console.WriteLine("[" + tid + "] CultureInfo:" + Thread.CurrentThread.CurrentCulture.CultureTypes);
            System.Console.WriteLine("[" + tid + "] IsAlive: " + Thread.CurrentThread.IsAlive);
            System.Console.WriteLine("[" + tid + "] IsBackground: " + Thread.CurrentThread.IsBackground);
            System.Console.WriteLine("[" + tid + "] IsThreadPoolThread: " + Thread.CurrentThread.IsThreadPoolThread);
            System.Console.WriteLine("[" + tid + "] Priority: " + Thread.CurrentThread.Priority);
            System.Console.WriteLine("[" + tid + "] ThreadState: " + Thread.CurrentThread.ThreadState);
            System.Console.WriteLine("[" + tid + "] #########################");
        }

        public static void ThreadMethod()
        {
            int tempvar = CMyThread.ThreadParam;
            Console.WriteLine("[{0}] START (number: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, tempvar);
            Thread.Sleep(tempvar);
            Console.WriteLine("[{0}] END (number: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, tempvar);
        }

        public static void simulateSimpleThread( Random rand )
        {
            System.Console.WriteLine("### simulateSimpleThread() ###");
            Thread[] iThreads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                // mivel a hasznalt ThreadStart delegate-nek nincs parametere
                // valamilyen modon megprobalunk parametert atadni a metodusnak
                // A valasztott modszer egy statikus field, melynek azonban hibai vannak! (lasd alabb)
                CMyThread.ThreadParam = rand.Next(500, 5000);
                System.Console.WriteLine("[MAIN] Generated static value: " + CMyThread.ThreadParam);
                
                iThreads[i] = new Thread(ThreadMethod);
                // ThreadStart delegate
                // public delegate void ThreadStart ()
               
                iThreads[i].Name = "New background thread - index = " + (i+1).ToString();
                iThreads[i].IsBackground = true;
                // System.Console.WriteLine("state: "+newThread[i].ThreadState); // unstarted
                iThreads[i].Start();

                // Thread.Sleep(1000);
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

        public static void ThreadMethodParam(object state)
        {
            int tempvar = (int)state;
            Console.WriteLine("[{0}] START (number: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, tempvar);
            Thread.Sleep(tempvar);
            Console.WriteLine("[{0}] END (number: {1}) param: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, tempvar);
        }

        public static void simulateSimpleThreadWithParam(Random rand)
        {
            System.Console.WriteLine("### simulateSimpleThreadWithParam() ###");
            Thread[] iThreads = new Thread[5];
            int randValue = 0;
            for (int i = 0; i < 5; i++)
            {
                randValue = rand.Next(500, 5000);
                System.Console.WriteLine("[MAIN] Generated rand value: " + randValue);

                iThreads[i] = new Thread(ThreadMethodParam);
                // ParameterizedThreadStart delegate
                // public delegate void ParameterizedThreadStart(Object obj)

                iThreads[i].Name = "New background thread - index = " + (i + 1).ToString();
                iThreads[i].IsBackground = true;

                // itt adjuk at neki az object tipusu parametert!
                iThreads[i].Start(randValue);
            }
        }

        public static void simulateThreadInClassWithParam(Random rand)
        {
            System.Console.WriteLine("### simulateThreadInClassWithParam() ###");
            Thread[] iThreads = new Thread[5];
            int randValue = 0;
            for (int i = 0; i < 5; i++)
            {
                randValue = rand.Next(500, 5000);
                System.Console.WriteLine("[MAIN] Generated rand value: " + randValue);
                ClassRunInThead iClassRunInThead = new ClassRunInThead(randValue);
                
                iThreads[i] = new Thread(iClassRunInThead.run);
                iThreads[i].Name = "New background thread - index = " + (i + 1).ToString();
                iThreads[i].IsBackground = true;
                iThreads[i].Start();
            }
        }

        public static void simulateThreadPool() {
            System.Console.WriteLine("### simulateThreadPool() ###");  
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod), ConsoleColor.DarkBlue);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod), ConsoleColor.DarkRed);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod), ConsoleColor.DarkGreen);
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod), ConsoleColor.Gray);
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();
            // CMyThread.printCurrentThreadInfo();
            // CMyThread.simulateSimpleThread(rand);
            // CMyThread.simulateSimpleThreadWithParam(rand);
            // CMyThread.simulateThreadInClassWithParam(rand);
            CMyThread.simulateThreadPool();
            System.Console.ReadKey();
        }

        public static void ThreadPoolMethod(object state)
        {
            textcolor = (ConsoleColor)state;
            Console.ForegroundColor = textcolor;
            Console.WriteLine("[" + Thread.CurrentThread.ManagedThreadId + "] Pool thread");
            // nyilvanvaloan igy at tudjuk adni a parametert:
            CMyThread.DisplayThreadData(textcolor);
            // de a ThreadStatic miatt meg tudjuk oldani a thread statikus valtozoval is!
            CMyThread.DisplayNumbers();            
        }

        private static void DisplayThreadData( ConsoleColor ptextcolor )
        {
            Console.ForegroundColor = ptextcolor;
            CMyThread.printCurrentThreadInfo();
        }

        public static void DisplayNumbers()
        {
            for (int i = 0; i <= 5; i++)
            {
                // bar az ertekadas es a kiiras egymas utani utasitas, a ketto kozott egy masik szal uj
                // erteket adhat a ForegroundColor-nak, es igy a beallitott szinunk elveszik.
                Console.ForegroundColor = textcolor;
                Console.WriteLine("Number value {0}", i);
                Thread.Sleep(250);
                // ez a szinvalto hiba nem a Thread static hibaja nyilvanvaloan, hanem hogy a Thread static erteket atadjuk egy nem thread static 
                // ForegroundColor-nak!
            }
        }

    }

}
