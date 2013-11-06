using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFServiceLibraryDemo;
using System.Collections.ObjectModel;

namespace WCFServiceHostDemo
{
    public class Program
    {
        private static void Main(string[] args) 
        {
            Console.WriteLine("Console Based WCF Host");
            using (ServiceHost host = new ServiceHost(typeof(QwaeviszDemoService))) {
                host.Open();
                ReadOnlyCollection<Uri> hosts = host.BaseAddresses;
                Console.WriteLine("The QwaeviszDemo service is ready.");
                Console.WriteLine("Address: " + hosts.First());
                Console.WriteLine("Press the Enter to terminate the service.");
                Console.ReadLine();
            }
        }
    }
}
