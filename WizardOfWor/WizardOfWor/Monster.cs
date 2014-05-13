using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public abstract class Monster
    {
        private const int MAX_SPEED = 10;
        private const int TIME_UNIT = 100;

        private readonly Random rand;
        private readonly Maze maze;
        private readonly ConsoleColor color;
        private readonly int minSpeed;
        private readonly int maxSpeed;
        private readonly char shape;
        private readonly int hidePercent;

        private bool hide;
        private MazeField position;
        private Direction lastDirection;

        public Monster(Maze maze, ConsoleColor color, int minSpeed, int maxSpeed, char shape, int hidePercent)
        {
            this.maze = maze;
            this.rand = this.maze.getRandom();
            this.color = color;
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.shape = shape;
            this.hidePercent = hidePercent;
            this.hide = false;
            this.position = this.maze.getRandomPosition();
            this.lastDirection = Direction.UP;
        }

        public void run()
        {
            while (true)
            {
                this.move();
                this.calcHide();
                this.print(this.color);
                this.wait();
                this.print(ConsoleColor.Black);
            }
        }

        private void move()
        {
            int column = this.position.Column;
            int row = this.position.Row;
            Direction direction = Direction.DOWN;
            Direction oppositeDirection = this.oppositeDirection(lastDirection);
            do
            {
                int limit = 4;
                do
                {
                    direction = (Direction)this.rand.Next(4);
                    limit--;
                } while (direction == oppositeDirection && limit > 0);
                
                column = this.position.Column;
                row = this.position.Row;

                switch (direction)
                {
                    case Direction.UP:
                        column = column - 1;
                        break;
                    case Direction.LEFT:
                        row = row - 1;
                        break;
                    case Direction.RIGHT:
                        row = row + 1;
                        break;
                    case Direction.DOWN:
                        column = column + 1;
                        break;
                }
            } while (this.maze.isWall(row, column));
            this.lastDirection = direction;
            this.maze.releasePosition(this.position);
            this.position.Column = column;
            this.position.Row = row;
            this.maze.reservePosition(this.position);
        }

        private Direction oppositeDirection(Direction direction)
        {
            Direction opposite = Direction.UP;
            switch (direction)
            {
                case Direction.UP:
                    opposite = Direction.DOWN;
                    break;
                case Direction.LEFT:
                    opposite = Direction.RIGHT;
                    break;
                case Direction.RIGHT:
                    opposite = Direction.LEFT;
                    break;
                case Direction.DOWN:
                    opposite = Direction.UP;
                    break;
            }
            return opposite;
        }

        private void calcHide()
        {
            if (this.hidePercent != 0)
            {
                int percent = this.rand.Next(100);
                if (this.hide)
                {
                    if ((100 - percent) < this.hidePercent)
                    {
                        this.hide = !this.hide;
                    }
                }
                else {
                    if (percent < this.hidePercent)
                    {
                        this.hide = !this.hide;
                    } 
                }
            }
        }

        private void print(ConsoleColor color)
        {
            if (!this.hide)
            {                                   
                Monster.printMonster(this.position, color, shape);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        protected static void printMonster(MazeField position, ConsoleColor color, char shape)
        {
            Console.SetCursorPosition(position.Column, position.Row);
            Console.ForegroundColor = color;
            Console.Write(shape);
        }

        private void wait()
        {
            int time = this.rand.Next((Monster.MAX_SPEED - this.maxSpeed) * Monster.TIME_UNIT, ( Monster.MAX_SPEED -  this.minSpeed ) * Monster.TIME_UNIT);
            Thread.Sleep(time);
        }

    }
}
