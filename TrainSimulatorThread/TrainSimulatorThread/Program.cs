using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrainSimulatorThread
{
    public class Program
    {
        private static readonly int NUMBER_OF_TRAINS = 5;

        private static void Main(string[] args)
        {
            Console.WriteLine("Train Simulator Application");
            Program.drawField(14);
            Program.simulation();
            System.Console.ReadKey();
        }

        private static void drawField( int trainLength )
        {
            Console.SetCursorPosition(1,1);
            for (int i = 0; i < (Train.DESTINATION_POS + trainLength); i++)
            {
                Console.Write("-");
            }
            for (int i = 0; i < Program.NUMBER_OF_TRAINS; i++)
            {
                Console.SetCursorPosition(0, i+2);
                Console.Write("|");
                Console.SetCursorPosition(Train.DESTINATION_POS + 1 + trainLength, i + 2);
                Console.Write("|");
            }
            System.Console.SetCursorPosition(1, Program.NUMBER_OF_TRAINS + 2);
            for (int i = 0; i < (Train.DESTINATION_POS + trainLength); i++)
            {
                Console.Write("-");
            }
        }

        private static void simulation()
        {
            Train[] trains = Train.createTrains(new Random(), Program.NUMBER_OF_TRAINS);
            Thread[] threads = new Thread[Program.NUMBER_OF_TRAINS];
            for (int i = 0; i < Program.NUMBER_OF_TRAINS; i++)
            {
                threads[i] = new Thread(trains[i].run);
                threads[i].IsBackground = true;
                threads[i].Start();
            }
        }

    }
}
