﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainSimulatorThread
{
    public class DestinationException : Exception
    {

        private string trainShape;
        private ConsoleColor trainColor;

        public override string Message
        {
            get
            {
                return "Train: " + this.trainShape;
            }
        }

        public ConsoleColor TrainColor
        {
            get
            {
                return this.trainColor;
            }
        }

        public DestinationException( string trainShape, ConsoleColor trainColor ) {
            this.trainShape = trainShape;
            this.trainColor = trainColor;
        }

    }
}
