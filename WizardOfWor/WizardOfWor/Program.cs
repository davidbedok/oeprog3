using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class Program
    {

  
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);

            Random rand = new Random();
            
            Dictionary<TypeOfMonsters, int> numberOfMonsters = new Dictionary<TypeOfMonsters,Int32>();
            numberOfMonsters.Add(TypeOfMonsters.Burwor, 12);
            numberOfMonsters.Add(TypeOfMonsters.Garwor, 10);
            numberOfMonsters.Add(TypeOfMonsters.Thorwor, 8);
            numberOfMonsters.Add(TypeOfMonsters.Worluk, 4);
            numberOfMonsters.Add(TypeOfMonsters.WizardOfWor, 2);

            Maze maze = new Maze(rand, numberOfMonsters);

            maze.draw();
            maze.start();

            Console.ReadKey();
        }
    }
}
