using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class Garwor : Monster
    {

        public Garwor(Maze maze)
            : base(maze, ConsoleColor.Yellow, 2, 5, 'G', 5)
        {
        }

    }
}
