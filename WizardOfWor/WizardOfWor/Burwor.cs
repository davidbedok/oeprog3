using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class Burwor : Monster
    {

        public Burwor(Maze maze)
            : base(maze, ConsoleColor.Green, 1, 3, 'B', 0)
        {
        }

    }
}
