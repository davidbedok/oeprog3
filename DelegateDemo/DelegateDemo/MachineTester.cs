using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class MachineTester
    {

        private int counter;
        private MachineRegister register;

        public MachineRegister Register
        {
            get { return this.register; }
        }

        public MachineTester()
        {
            this.register = new MachineRegister();
            this.counter = 0;
        }

        public int test(Work work)
        {
            return work(this.register, "Test process " + ++this.counter+ ".");
        }

        public override string ToString()
        {
            return "MachineTester (counter: "+this.counter+", "+ this.register + ")";
        }

    }
}
