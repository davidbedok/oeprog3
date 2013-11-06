using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceLibraryDemo.Model;
using WCFServiceLibraryDemo.Holder;

namespace WCFServiceLibraryDemo
{
    public class QwaeviszDemoService : IQwaeviszDemoService
    {

        public int numberOfCars()
        {
            return Cars.getInstance().numberOfCars();
        }

        public double averageEngineCapacity(Manufacturer manufacturer)
        {
            return Cars.getInstance().averageEngineCapacity(manufacturer);
        }

        public Car findCar(Manufacturer manufacturer, String name)
        {
            return Cars.getInstance().find(manufacturer, name);
        }

    }
}
