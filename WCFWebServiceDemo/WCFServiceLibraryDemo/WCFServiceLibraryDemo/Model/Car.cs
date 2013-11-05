using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WCFServiceLibraryDemo.Model
{
    [DataContract(Name="CarType")]
    public class Car
    {

        private Manufacturer manufacturer;
        private String name;
        private double engineCapacity;
        private Fuel fuel;
        private Dimension dimension;

        [DataMember]
        public Manufacturer Manufacturer
        {
            get { return this.manufacturer; }
            internal set { this.manufacturer = value; }
        }

        [DataMember(Name="CarName")]
        public String Name
        {
            get { return this.name; }
            internal set { this.name = value; }
        }

        [DataMember]
        public double EngineCapacity
        {
            get { return this.engineCapacity; }
            internal set { this.engineCapacity = value; }
        }

        [DataMember]
        public Fuel Fuel
        {
            get { return this.fuel; }
            internal set { this.fuel = value; }
        }

        [DataMember]
        public Dimension Dimension
        {
            get { return this.dimension; }
            internal set { this.dimension = value; }
        }

        public Car(Manufacturer manufacturer, String name, double engineCapacity, Fuel fuel, int width, int height, int length)
        {
            this.manufacturer = manufacturer;
            this.name = name;
            this.engineCapacity = engineCapacity;
            this.fuel = fuel;
            this.dimension = new Dimension(width, height, length);
        }

        public override string ToString()
        {
            return String.Join(" ,", this.manufacturer, ": ", this.name, " (", this.engineCapacity, ") ", this.fuel, " ", this.dimension);
        }

    }
}
