using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceLibraryDemo.Model;

namespace WCFServiceLibraryDemo
{
    [ServiceContract(Namespace = "http://david.bedok.hu/qwaeviszDemoService", Name="QwaeviszDemoService")]
    public interface IQwaeviszDemoService
    {

        [OperationContract(Name="NumberOfCars")]
        int numberOfCars();

        [OperationContract(Name="AverageEngineCapacity")]
        double averageEngineCapacity(Manufacturer manufacturer);

        [OperationContract(Name = "FindCar")]
        Car findCar(Manufacturer manufacturer, String name);

    }

}
