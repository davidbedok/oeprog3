using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class Program
    {
        private static void Main(string[] args)
        {

            // Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);

            Random rand = new Random();
            Maze maze = new Maze(rand, 10);

            maze.draw();
            maze.start();

            Console.ReadKey();


        }
    }
}
