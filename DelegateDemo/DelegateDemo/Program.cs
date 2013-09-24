using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {

            Machine machine = new Machine();
            machine.Register.init(1, 2, 0);
            Console.WriteLine(machine);

            Console.WriteLine("Result of 'summation': " + machine.process(Program.summation, "Add 'A' and 'B' register, and put the result into register 'C'."));
            Console.WriteLine(machine);
            machine.restart();
            Console.WriteLine("Result of 'subtraction': " + machine.process(Program.subtraction, "Deduct 'B' from 'C' register, and put the result into register 'A'."));
            Console.WriteLine(machine);

            MachineTester tester = new MachineTester();
            tester.Register.init(3, 4, 0);
            Console.WriteLine(tester);

            tester.test(Program.summation);
            Console.WriteLine(tester);

            Console.WriteLine("Add + Random (undefined result): " + machine.process(Program.summation, Program.randomRegister));
            Console.WriteLine("Add + Mock (result: 12): " + machine.process(Program.summation, Program.mockRegister));

        }

        private static int summation(MachineRegister register, String message)
        {
            Console.WriteLine("  - " + message);
            register.C = register.A + register.B;
            return register.C;
        }

        private static int subtraction(MachineRegister register, String message)
        {
            Console.WriteLine(message);
            register.A = register.B - register.C;
            return register.A;
        }

        private static MachineRegister randomRegister()
        {
            Random random = new Random();
            MachineRegister register = new MachineRegister();
            register.init(random.Next(0, 5), random.Next(0, 5), random.Next(0, 5));
            return register;
        }

        private static MachineRegister mockRegister()
        {
            MachineRegister register = new MachineRegister();
            register.init(5, 7, 0);
            return register;
        }


    }
}
