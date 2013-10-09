using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainSimulatorThread
{
    public class DestinationException : Exception
    {

        private string trainShape;
        private ConsoleColor color;

        public DestinationException( string trainShape, ConsoleColor color ) {
            this.trainShape = trainShape;
            this.color = color;
        }

        public override string ToString()
        {
            return "Train: " + this.trainShape;
        }

        public override string Message
        {
            get
            {
                return this.ToString();
            }
        }

        public ConsoleColor TrainColor
        {
            get
            {
                return this.color;
            }
        }

    }
}
