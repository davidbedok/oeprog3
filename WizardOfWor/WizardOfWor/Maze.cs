using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class Maze
    {
        private const String START_SOUND = "music\\start.wav";
        private const String ATTRACT_SOUND = "music\\attract.wav";

        private const int HEIGHT = 22;
        private const int WIDTH = 60;
        private const int NUMBER_OF_WALLS = 1200;

        private readonly Random rand;
        private readonly Boolean[,] fields;

        private readonly Dictionary<TypeOfMonsters, Int32> numberOfMonsters;
        private readonly int totalNumberOfMonsters;
        private readonly Monster[] monsters;

        public Maze(Random rand, Dictionary<TypeOfMonsters, Int32> numberOfMonsters)
        {
            this.rand = rand;
            this.numberOfMonsters = numberOfMonsters;
            this.totalNumberOfMonsters = this.calcTotalNumberOfMonsters();
            this.fields = new Boolean[Maze.HEIGHT, Maze.WIDTH];
            this.init();
            this.monsters = new Monster[totalNumberOfMonsters];
            this.createMonsters();
        }

        private int calcTotalNumberOfMonsters()
        {
            int count = 0;
            foreach (KeyValuePair<TypeOfMonsters, Int32> pair in this.numberOfMonsters)
            {
                count += pair.Value;
            }
            return count;
        }

        private void init()
        {
            int numOfWalls = 0;
            for (int row = 0; row < Maze.HEIGHT; row++)
            {
                for (int column = 0; column < Maze.WIDTH; column++)
                {
                    if (row == 0 || column == 0 || row == Maze.HEIGHT - 1 || column == Maze.WIDTH - 1)
                    {
                        this.fields[row, column] = true;
                    }
                    else if (numOfWalls < Maze.NUMBER_OF_WALLS)
                    {
                        this.fields[row, column] = this.rand.Next(10) > 7;
                        numOfWalls++;
                    }
                }
            }
        }

        public void draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < Maze.HEIGHT; row++)
            {
                for (int column = 0; column < Maze.WIDTH; column++)
                {
                    if (this.fields[row, column])
                    {
                        Console.Write((char)177);
                        //Console.Write('H');
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
            int column = 0;
            int row = 0;
            do
            {
                row = this.rand.Next(Maze.HEIGHT);
                column = this.rand.Next(Maze.WIDTH);
            } while (this.isWall(row, column));
            return new MazeField(column, row);
        }

        public bool isWall( int row, int column )
        {
            bool valid = true;
            if (row >= 0 && row < Maze.HEIGHT && column >= 0 && column < Maze.WIDTH)
            {
                valid = this.fields[row, column];
            }
            return valid;
        }

        public Random getRandom()
        {
            return this.rand;
        }

        private void createMonsters()
        {
            int i = 0;
            foreach (KeyValuePair<TypeOfMonsters, Int32> pair in numberOfMonsters)
            {
                Monster monster = null;
                for (int j = 0; j < pair.Value; j++)
                {
                    switch (pair.Key)
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
                        case TypeOfMonsters.Worluk:
                            monster = new Worluk(this);
                            break;
                        case TypeOfMonsters.WizardOfWor:
                            monster = new WizardOfWor(this);
                            break;
                    }
                    this.monsters[i++] = monster; 
                }
            }
        }

        public void start()
        {
            this.musicStart();
            Thread[] threads = new Thread[this.totalNumberOfMonsters];
            for (int i = 0; i < this.totalNumberOfMonsters; i++)
            {
                threads[i] = new Thread(this.monsters[i].run);
                threads[i].IsBackground = true;
                threads[i].Start();
            }
        }

        private void musicStart()
        {
            SoundPlayer simpleSound = new SoundPlayer(Maze.START_SOUND);
            simpleSound.Play();
        }

        public void musicAttract()
        {
            SoundPlayer simpleSound = new SoundPlayer(Maze.ATTRACT_SOUND);
            simpleSound.Play();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void releasePosition(MazeField field)
        {
            this.fields[field.Row, field.Column] = false;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void reservePosition(MazeField field)
        {
            this.fields[field.Row, field.Column] = true;
        }
    }
}
