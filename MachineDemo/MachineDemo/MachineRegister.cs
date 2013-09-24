using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDemo
{
    public class MachineRegister
    {
        private int registerA;
        private int registerB;
        private int registerC;

        public int A
        {
            get { return this.registerA; }
            set { this.registerA = value; }
        }

        public int B
        {
            get { return this.registerB; }
            set { this.registerB = value; }
        }

        public int C
        {
            get { return this.registerC; }
            set { this.registerC = value; }
        }

        public MachineRegister( int a, int b, int c)
        {
            this.init(a, b, c);
        }

        public void init(int a, int b, int c)
        {
            this.registerA = a;
            this.registerB = b;
            this.registerC = c;
        }

        public override string ToString()
        {
            return "[A " + this.A + "] [B " + this.B + "] [C " + this.C + "]";
        }

    }
}
