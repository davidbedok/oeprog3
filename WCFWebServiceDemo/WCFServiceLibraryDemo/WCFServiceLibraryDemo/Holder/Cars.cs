using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFServiceLibraryDemo.Model;

namespace WCFServiceLibraryDemo.Holder
{
    public class Cars
    {

        private List<Car> items;

        public Cars()
        {
            this.items = new List<Car>();
            this.add(Manufacturer.OPEL, "Zafira", 2.0, Fuel.DIESEL, 455, 170, 205);
            this.add(Manufacturer.TOYOTA, "Verso", 1.8, Fuel.GASOLINE, 440, 175, 208);
            this.add(Manufacturer.OPEL, "Astra", 1.6, Fuel.GASOLINE, 380, 160, 195);
            this.add(Manufacturer.ROVER, "45i", 1.6, Fuel.GASOLINE, 430, 165, 187);
            this.add(Manufacturer.TOYOTA, "Corolla", 1.6, Fuel.DIESEL, 410, 160, 190);
            this.add(Manufacturer.TOYOTA, "Auris", 2.2, Fuel.DIESEL, 420, 170, 195);
        }

        public void add(Manufacturer manufacturer, String name, double engineCapacity, Fuel fuel, int width, int height, int length)
        {
            this.items.Add(new Car(manufacturer, name, engineCapacity, fuel, width, height, length));
        }

        public int numberOfCars()
        {
            return this.items.Count;
        }

        public double averageEngineCapacity(Manufacturer manufacturer)
        {
            return this.items.Where(x => x.Manufacturer == manufacturer).Average(x => x.EngineCapacity);
        }

        public Car findCar(Manufacturer manufacturer, String name)
        {
            Car ret = null;
            IEnumerable<Car> results = this.items.Where(x => x.Manufacturer == manufacturer && x.Name.Equals(name));
            if (results.Count() > 0)
            {
                ret = results.First();
            }
            return ret;
        }

        // ----

        private static Cars INSTANCE;

        public static Cars getInstance()
        {
            if (Cars.INSTANCE == null)
            {
                Cars.INSTANCE = new Cars();
            }
            return Cars.INSTANCE;
        }

    }
}
