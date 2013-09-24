using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
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
            this.register = new MachineRegister();
            this.state = MachineState.IDLE;
        }

        public int process( Work work, String message )
        {
            int result = 0;
            if (this.state == MachineState.IDLE)
            {
                result = work(this.register, message);
                this.state = MachineState.WORK;
            }
            return result;
        }

        public int process(Work work, InformationProvider provider)
        {
            return work(provider(), "From provider.");
        }

        public void restart()
        {
            this.state = MachineState.IDLE;
        }

        public override string ToString()
        {
            return "Machine (" + this.register + ", state: " + this.state + ")";
        }


    }
}
