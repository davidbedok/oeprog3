using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDemo
{
    public class Program
    {

        private static void Main(string[] args)
        {
            Machine machine = new Machine();
            machine.Register.init(3, 4, 0);
            Console.WriteLine(machine);

            int result = machine.process(Program.summation, "Summation C = A + B");
            Console.WriteLine(machine);

            machine.restart();
            machine.process(Program.subtraction, "Subtraction A = B - C");
            Console.WriteLine(machine);

            Console.ReadKey();
        }

        private static int summation( MachineRegister register, String message )
        {
            Console.WriteLine("  > " + message);
            register.C = register.A + register.B;
            return register.C;
        }

        private static int subtraction(MachineRegister register, String message)
        {
            Console.WriteLine("  > " + message);
            register.A = register.B - register.C;
            return register.A;
        }

    }
}
