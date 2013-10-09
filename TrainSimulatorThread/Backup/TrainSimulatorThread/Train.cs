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
        public static int REACH_POSITION = 0;

        public static readonly int MAX_LEFT = 30;

        private readonly int posTop;
        private readonly string shape;
        private readonly ConsoleColor color;
        private readonly Random rand;

        private int posLeft;

        public Train(int posTop, string shape, ConsoleColor color, Random rand)
        {
            this.posTop = posTop;
            this.posLeft = 1;
            this.shape = shape;
            this.color = color;
            this.rand = rand;
        }

        protected void move()
        {
            if ( Train.MAX_LEFT > this.posLeft ){
                this.posLeft++;
            } else {
                throw new DestinationException(this.shape,this.color);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void printConsole(int posTop, int posLeft, ConsoleColor color, string shape ){
            System.Console.SetCursorPosition(posLeft,posTop);
            System.Console.ForegroundColor = color;
            System.Console.Write(shape);
        }

        protected void print( ConsoleColor color ){
            Train.printConsole(this.posTop,this.posLeft,color,this.shape);    
        }

        public void run()
        {
            try {
                while (true)
                {
                    this.move();
                    this.print(this.color);
                    Thread.Sleep(rand.Next(100,1500));
                    this.print(ConsoleColor.Black);
                }
            }
            catch (DestinationException e)
            {
                System.Console.SetCursorPosition(0, 10 + Train.REACH_POSITION);
                System.Console.ForegroundColor = e.TrainColor;
                System.Console.WriteLine("Reach destination: " + e.Message);
                Train.REACH_POSITION++;
            }
        }

        public override string ToString()
        {
            return this.shape;
        }

    }
}
