using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFServiceClientDemo.QwaeviszDemoServiceReference;

namespace WCFServiceClientDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            QwaeviszDemoServiceClient client = new QwaeviszDemoServiceClient();
            int numberOfCars = client.NumberOfCars();

            Console.WriteLine("Number of cars: " + numberOfCars);
            double avg = client.AverageEngineCapacity(Manufacturer.TOYOTA);
            Console.WriteLine("Avg: " + avg);


            CarType car = client.FindCar(Manufacturer.ROVER, "45i");
            Console.WriteLine("CarName: " + car.CarName);
            Console.WriteLine("EngineCapacity: " + car.EngineCapacity);
            Console.WriteLine("Fuel: " + car.Fuel);
            Console.WriteLine("Manufacturer: " + car.Manufacturer);
            Console.WriteLine("Dimension-Width: " + car.Dimension.Width);
            Console.WriteLine("Dimension-Height: " + car.Dimension.Height);
            Console.WriteLine("Dimension-Length: " + car.Dimension.Length);
        }
    }
}
