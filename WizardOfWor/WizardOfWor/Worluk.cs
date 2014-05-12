using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class Worluk : Monster
    {

        public Worluk(Maze maze)
            : base(maze, ConsoleColor.White, 5, 8, (char)1, 0)
        {
        }

    }
}
