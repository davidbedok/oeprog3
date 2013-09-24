using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
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

        public MachineRegister()
        {
            this.registerA = 0;
            this.registerB = 0;
            this.registerC = 0;
        }

        public void init( int a, int b, int c)
        {
            this.registerA = a;
            this.registerB = b;
            this.registerC = c;
        }

        public override string ToString()
        {
            return "[A " + this.registerA + "] [B " + this.registerB + "] [C " + this.registerC + "]";
        }

    }
}
