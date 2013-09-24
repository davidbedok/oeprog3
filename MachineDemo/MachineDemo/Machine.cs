using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDemo
{
    public class Machine
    {

        private MachineState state;
        private MachineRegister register;

        public MachineRegister Register
        {
            get { return this.register; }
        }

        public Machine()
        {
            this.state = MachineState.IDLE;
            this.register = new MachineRegister(0, 0, 0);
        }

        public int process( Work work, String message )
        {
            int result = -1;
            if (this.state == MachineState.IDLE)
            {
                work(this.register, message);
                this.state = MachineState.WORK;
            }
            return result;
        }

        public void restart()
        {
            this.state = MachineState.IDLE;
        }

        public override string ToString()
        {
            return "Machine (" + this.state + ", " + this.register + ")";
        }

    }
}
