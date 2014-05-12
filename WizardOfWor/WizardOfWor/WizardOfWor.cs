using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class WizardOfWor : Monster
    {

        public WizardOfWor(Maze maze)
            : base(maze, ConsoleColor.Magenta, 9, 10, (char)2, 15)
        {
        }

    }
}
