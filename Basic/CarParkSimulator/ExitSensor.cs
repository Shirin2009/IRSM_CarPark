using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class ExitSensor : Sensor       // inherits from Sensor
    {
        private CarPark carpark;

        public ExitSensor(CarPark carpark) : base()   // constructor also calls parent (base) constructor
        {// this function instantiates the ExitSensor:Sensor class
            carOnSensor = false;
            this.carpark = carpark;
        }

        public override void CarDetected()
        {
            carOnSensor = true;
            carpark.CarArrivedAtExit();
        }

        public override void CarLeftSensor()
        {
            carOnSensor = false;
        }
    }
}
