using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFServiceLibraryDemo;

namespace WCFServiceHostDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Console Based WCF Host");
            using (ServiceHost host = new ServiceHost(typeof(QwaeviszDemoService))) {
                host.Open();
                Console.WriteLine("The QwaeviszDemo service is ready.");
                Console.WriteLine("Press the Enter to terminate the service.");
                Console.ReadLine();
            }
        }
    }
}
