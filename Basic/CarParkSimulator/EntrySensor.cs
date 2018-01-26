using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class EntrySensor : Sensor          // inherits from Sensor
    {
        private CarPark carpark;

        public EntrySensor(CarPark carpark) : base()   // constructor also calls parent (base) constructor
        {// this function instantiates the EntrySensor:Sensor class
            carOnSensor = false;
            this.carpark = carpark;
        }

        public override void CarDetected()
        {
            carOnSensor = true;
            carpark.CarArrivedAtEntrance();
        }

        public override void CarLeftSensor()
        {
            carOnSensor = false;
        }
    }
}