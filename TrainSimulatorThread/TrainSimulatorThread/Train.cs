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
            // Console.SetCursorPosition(this.position, this.track);
            // Console.ForegroundColor = color;
            // Console.Write(this.shape);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        protected static void printTrain(int position, int track, string shape, ConsoleColor color)
        {
            // Train.printConsole(this.track, this.position, this.color, this.shape);
            Console.SetCursorPosition(position, track);
            Console.ForegroundColor = color;
            Console.Write(shape);
        }

        /*
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void printConsole(int posTop, int posLeft, ConsoleColor color, string shape ){
            System.Console.SetCursorPosition(posLeft,posTop);
            System.Console.ForegroundColor = color;
            System.Console.Write(shape);
        } */

        public override string ToString()
        {
            return this.shape;
        }

    }
}
