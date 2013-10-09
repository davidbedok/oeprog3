using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

namespace TrainSimulatorThread
{
    public class Train
    {
        public static int CURRENT_FREE_RANK = 0;

        public static readonly int DESTINATION_POS = 30;

        private readonly int track;
        private readonly string shape;
        private readonly ConsoleColor color;
        private readonly Random rand;
        private int position;

        public Train(int track, string shape, ConsoleColor color, Random rand)
        {
            this.track = track;
            this.shape = shape;
            this.color = color;
            this.rand = rand;
            this.position = 1;
        }

        public void run()
        {
            try
            {
                while (true)
                {
                    this.move();
                    this.print(this.color);
                    Thread.Sleep(rand.Next(100, 1500));
                    this.print(ConsoleColor.Black);
                }
            }
            catch (DestinationException e)
            {
                Console.SetCursorPosition(0, 10 + Train.CURRENT_FREE_RANK);
                Console.ForegroundColor = e.TrainColor;
                Console.WriteLine("Reach destination: " + e.Message);
                Train.CURRENT_FREE_RANK++;
            }
        }

        protected void move()
        {
            if ( Train.DESTINATION_POS > this.position ){
                this.position++;
            } else {
                throw new DestinationException(this.shape,this.color);
            }
        }

        protected void print(ConsoleColor color)
        {
            Train.printTrain(this.position, this.track, this.shape, color);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        protected static void printTrain(int position, int track, string shape, ConsoleColor color)
        {
            Console.SetCursorPosition(position, track + 1);
            Console.ForegroundColor = color;
            Console.Write(shape);
        }

        public static Train[] createTrains( Random rand, int numberOfTrains )
        {
            Train[] trains = new Train[numberOfTrains];
            trains[0] = new Train(1, "[O][O][1][AAA>", ConsoleColor.Blue, rand);
            trains[1] = new Train(2, "[O][O][2][BBB>", ConsoleColor.Green, rand);
            trains[2] = new Train(3, "[O][O][3][CCC>", ConsoleColor.White, rand);
            trains[3] = new Train(4, "[O][O][4][DDD>", ConsoleColor.Yellow, rand);
            trains[4] = new Train(5, "[O][O][5][EEE>", ConsoleColor.Red, rand);
            return trains;
        }

    }
}
