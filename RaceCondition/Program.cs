using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace RaceCondition
{
    class Program
    {    
        // Közösen használt mezõ
        static int counter = 0;
        // Zároláshoz használt belsõ objektum
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
            Console.WriteLine("Összesen {0} ms", sw.ElapsedMilliseconds);
        }

        // Elsõ megoldás: naiv megvalósítás (versenyhelyzetet idéz elõ és párhuzamos végrehajtás esetén nem mûködik helyesen)
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

        // Második megoldás: helyesen mûködõ változat a Monitor osztály statikus metódusainak használatával
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

        // Harmadik megoldás: helyesen mûködõ változat a C# lock kulcsszavának használatával
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

        // Negyedik megoldás: teljesítményoptimalizálás
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

        // Ötödik megoldás: túlzásba vitt teljesítményoptimalizálás (gyengébb idõeredményt ad, mint az elõzõ megoldás)
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