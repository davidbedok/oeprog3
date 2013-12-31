using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFServiceLibraryDemo.Model;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFServiceLibraryDemo.Error
{
    [DataContract]
    public class CarNotFoundError
    {

        private const String FAULT_REASON = "Car not found.";
        private const int FAULT_CODE = 1001;

        private Manufacturer manufacturer;
        private String name;

        [DataMember]
        public Manufacturer Manufacturer
        {
            get { return this.manufacturer; }
            internal set { this.manufacturer = value; }
        }

        [DataMember]
        public String Name
        {
            get { return this.name; }
            internal set { this.name = value; }
        }

        public CarNotFoundError(Manufacturer manufacturer, String name)
        {
            this.manufacturer = manufacturer;
            this.name = name;
        }

        public static FaultException<CarNotFoundError> create(Manufacturer manufacturer, String name)
        {
            CarNotFoundError error = new CarNotFoundError(manufacturer, name);
            return new FaultException<CarNotFoundError>(error, CarNotFoundError.getFaultReason(), CarNotFoundError.getFaultCode());
        }

        public static FaultReason getFaultReason()
        {
            return new FaultReason(CarNotFoundError.FAULT_REASON);
        }

        public static FaultCode getFaultCode()
        {
            return new FaultCode(CarNotFoundError.FAULT_CODE.ToString());
        }

    }
}
