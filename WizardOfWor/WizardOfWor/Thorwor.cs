using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class Thorwor : Monster
    {

        public Thorwor(Maze maze)
            : base(maze, ConsoleColor.Red, 3, 6, 'T', 20)
        {
        }

    }
}
