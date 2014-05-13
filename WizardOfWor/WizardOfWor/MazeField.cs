using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardOfWor
{
    public class MazeField
    {

        private int column;
        private int row;

        public int Column
        {
            get { return this.column; }
            set { this.column = value; }
        }

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        public MazeField(int column, int row)
        {
            this.column = column;
            this.row = row;
        }

        public override string ToString()
        {
            return "["+this.column+"x"+this.row+"]";
        }

    }
}
