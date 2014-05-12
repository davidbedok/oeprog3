using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class Maze
    {
        private const int WIDTH = 20;
        private const int HEIGHT = 20;
        private const int NUMBER_OF_WALLS = 100;

        private readonly Random rand;
        private readonly Boolean[,] fields;

        private readonly int numberOfMonsters;
        private readonly Monster[] monsters;

        public Maze(Random rand, int numberOfMonsters)
        {
            this.rand = rand;
            this.numberOfMonsters = numberOfMonsters;
            
            this.fields = new Boolean[Maze.WIDTH, Maze.HEIGHT];
            this.init();
            this.monsters = new Monster[numberOfMonsters];
            this.createMonsters();
        }

        private void init()
        {
            int numOfWalls = 0;
            for (int i = 0; i < this.fields.GetLength(0); i++)
            {
                for (int j = 0; j < this.fields.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == this.fields.GetLength(0) - 1 || j == this.fields.GetLength(1) - 1)
                    {
                        this.fields[i, j] = true;
                    }
                    else if (numOfWalls < Maze.NUMBER_OF_WALLS)
                    {
                        this.fields[i, j] = this.rand.Next(10) > 7;
                    }
                }
            }
        }

        public void draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < this.fields.GetLength(0); i++)
            {
                for (int j = 0; j < this.fields.GetLength(1); j++)
                {
                    if (this.fields[i, j])
                    {
                        // Console.Write((char)177);
                        Console.Write('H');
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public MazeField getRandomPosition()
        {
            int x = 0;
            int y = 0;
            do
            {
                x = this.rand.Next(this.fields.GetLength(0));
                y = this.rand.Next(this.fields.GetLength(1));
            } while (this.isWall(x, y));
            return new MazeField(x, y);
        }

        public bool isWall( int x, int y )
        {
            bool valid = true;
            if (x >= 0 && x < this.fields.GetLength(0) && y >= 0 && y < this.fields.GetLength(1))
            {
                valid = this.fields[x, y];
            }
            return valid;
        }

        public Random getRandom()
        {
            return this.rand;
        }

        private void createMonsters()
        {
            this.monsters[0] = new WizardOfWor(this);
            this.monsters[1] = new Worluk(this);
            this.monsters[2] = new Worluk(this);

            for (int i = 3; i < this.numberOfMonsters; i++)
            {
                TypeOfMonsters type = (TypeOfMonsters)this.rand.Next(3);
                Monster monster = null;
                switch (type)
                {
                    case TypeOfMonsters.Burwor:
                        monster = new Burwor(this);
                        break;
                    case TypeOfMonsters.Garwor:
                        monster = new Garwor(this);
                        break;
                    case TypeOfMonsters.Thorwor:
                        monster = new Thorwor(this);
                        break;
                }
                this.monsters[i] = monster; 
            }
        }

        public void start()
        {
            Thread[] threads = new Thread[this.numberOfMonsters];
            for (int i = 0; i < this.numberOfMonsters; i++)
            {
                threads[i] = new Thread(this.monsters[i].run);
                threads[i].IsBackground = true;
                threads[i].Start();
            }
        }

    }
}
