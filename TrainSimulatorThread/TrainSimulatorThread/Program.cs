using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrainSimulatorThread
{
    public class Program
    {
        private static readonly int NUMBER_OF_TRAIN = 5;

        public static void drawField( int trainLength )
        {
            System.Console.SetCursorPosition(1,1);
            for (int i = 0; i < (Train.MAX_LEFT + trainLength); i++)
            {
                System.Console.Write("-");
            }
            for (int i = 0; i < Program.NUMBER_OF_TRAIN; i++)
            {
                System.Console.SetCursorPosition(0, i+2);
                System.Console.Write("|");
                System.Console.SetCursorPosition(Train.MAX_LEFT + 1 + trainLength, i + 2);
                System.Console.Write("|");
            }
            System.Console.SetCursorPosition(1, Program.NUMBER_OF_TRAIN + 2);
            for (int i = 0; i < (Train.MAX_LEFT + trainLength); i++)
            {
                System.Console.Write("-");
            }
        }

        public static void Main(string[] args)
        {
            System.Console.WriteLine("Train Simulator Application");
            Program.drawField(14);
            
            Random rand = new Random();

            Train[] iTrains = new Train[NUMBER_OF_TRAIN];
            iTrains[0] = new Train(2, "[O][O][1][AAA>", ConsoleColor.Blue, rand);
            iTrains[1] = new Train(3, "[O][O][2][BBB>", ConsoleColor.Green, rand);
            iTrains[2] = new Train(4, "[O][O][3][CCC>", ConsoleColor.White, rand);
            iTrains[3] = new Train(5, "[O][O][4][DDD>", ConsoleColor.Yellow, rand);
            iTrains[4] = new Train(6, "[O][O][5][EEE>", ConsoleColor.Red, rand);

            Thread[] iThreads = new Thread[NUMBER_OF_TRAIN];
           
            for (int i = 0; i < NUMBER_OF_TRAIN; i++)
            {
                iThreads[i] = new Thread(iTrains[i].run);
                iThreads[i].IsBackground = true;
                iThreads[i].Start();
            }
             
            System.Console.ReadKey();
        }
    }
}
