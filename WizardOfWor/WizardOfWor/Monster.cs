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
            int x = this.position.X;
            int y = this.position.Y;
            do
            {
                x = this.position.X;
                y = this.position.Y;
                Direction direction = (Direction)this.rand.Next(4);
                switch (direction)
                {
                    case Direction.UP:
                        x = x - 1;
                        break;
                    case Direction.LEFT:
                        y = y - 1;
                        break;
                    case Direction.RIGHT:
                        y = y + 1;
                        break;
                    case Direction.DOWN:
                        x = x + 1;
                        break;
                }
            } while (this.maze.isWall(y, x));
            this.position.X = x;
            this.position.Y = y;
        }

        private void calcHide()
        {
            if (this.hidePercent != 0)
            {
                int percent = this.rand.Next(100);
                if (percent < this.hidePercent)
                {
                    this.hide = !this.hide;
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
            Console.SetCursorPosition(position.X, position.Y);
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
