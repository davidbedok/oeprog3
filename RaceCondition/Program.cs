using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace RaceCondition
{
    class Program
    {    
        // K�z�sen haszn�lt mez�
        static int counter = 0;
        // Z�rol�shoz haszn�lt bels� objektum
        static object myLock = new object();

        const int MAX_DELAY = 750 * 1000 * 1000;
        const int COUNTER_CEILING = 20;

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            ParameterizedThreadStart starter = new ParameterizedThreadStart(CounterMethod4);

            Thread t1 = new Thread(starter); 
            Thread t2 = new Thread(starter);
            Thread t3 = new Thread(starter);
            Thread t4 = new Thread(starter);
            t1.Start(ConsoleColor.Blue);
            t2.Start(ConsoleColor.Red);
            t3.Start(ConsoleColor.DarkGreen);
            t4.Start(ConsoleColor.DarkRed);            
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            sw.Stop();
            Console.ResetColor();
            Console.WriteLine("�sszesen {0} ms", sw.ElapsedMilliseconds);
        }

        // Els� megold�s: naiv megval�s�t�s (versenyhelyzetet id�z el� �s p�rhuzamos v�grehajt�s eset�n nem m�k�dik helyesen)
        static void CounterMethod1(object parameter)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (counter <= COUNTER_CEILING)
            {
                TimeConsumingMethodCall();

                counter++;
                Console.ForegroundColor = (ConsoleColor) parameter;
                Console.WriteLine(counter);
            }

            sw.Stop();
            Console.ForegroundColor = (ConsoleColor) parameter;
            Console.WriteLine("\t " + sw.ElapsedMilliseconds + " ms");
        }

        // M�sodik megold�s: helyesen m�k�d� v�ltozat a Monitor oszt�ly statikus met�dusainak haszn�lat�val
        static void CounterMethod2(object parameter)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (counter <= COUNTER_CEILING)
            {
                Monitor.Enter(myLock);
                try
                {
                    TimeConsumingMethodCall();

                    counter++;
                    if (counter <= COUNTER_CEILING)
                    {
                        Console.ForegroundColor = (ConsoleColor) parameter;
                        Console.WriteLine(counter);
                    }
                }
                finally
                {
                    Monitor.Exit(myLock);
                }
            }

            sw.Stop();
            Console.ForegroundColor = (ConsoleColor) parameter;
            Console.WriteLine("\t " + sw.ElapsedMilliseconds + " ms");
        }

        // Harmadik megold�s: helyesen m�k�d� v�ltozat a C# lock kulcsszav�nak haszn�lat�val
        static void CounterMethod3(object parameter)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (counter <= COUNTER_CEILING)
            {
                lock (myLock)
                {
                    TimeConsumingMethodCall();

                    counter++;
                    if (counter <= COUNTER_CEILING)
                    {
                        Console.ForegroundColor = (ConsoleColor) parameter;
                        Console.WriteLine(counter);
                    }
                }
            }

            sw.Stop();
            Console.ForegroundColor = (ConsoleColor) parameter;
            Console.WriteLine("\t " + sw.ElapsedMilliseconds + " ms");
        }

        // Negyedik megold�s: teljes�tm�nyoptimaliz�l�s
        static void CounterMethod4(object parameter)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (counter <= COUNTER_CEILING)
            {
                TimeConsumingMethodCall();

                lock (myLock)
                {
                    counter++;
                    if (counter <= COUNTER_CEILING)
                    {
                        Console.ForegroundColor = (ConsoleColor) parameter;
                        Console.WriteLine(counter);
                    }
                }
            }

            sw.Stop();
            Console.ForegroundColor = (ConsoleColor) parameter;
            Console.WriteLine("\t " + sw.ElapsedMilliseconds + " ms");
        }

        // �t�dik megold�s: t�lz�sba vitt teljes�tm�nyoptimaliz�l�s (gyeng�bb id�eredm�nyt ad, mint az el�z� megold�s)
        static void CounterMethod5(object parameter)
        {
            int myCounter;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            do
            {
                TimeConsumingMethodCall();

                lock (myLock)
                {
                    myCounter = ++counter;
                }
                if (myCounter <= COUNTER_CEILING)
                {
                    Console.ForegroundColor = (ConsoleColor) parameter;
                    Console.WriteLine(myCounter);
                }

            }
            while (myCounter <= COUNTER_CEILING);

            sw.Stop();
            Console.ForegroundColor = (ConsoleColor) parameter;
            Console.WriteLine("\t " + sw.ElapsedMilliseconds + " ms");
        }

        private static void TimeConsumingMethodCall()
        {
            for (int i = 0; i < MAX_DELAY; i++) { }
        }
    }
}