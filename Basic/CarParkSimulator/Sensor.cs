using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    abstract class Sensor
    {
        protected bool carOnSensor;

        public Sensor()
        {

        }

        public abstract void CarDetected();

        public abstract void CarLeftSensor();

        public bool IsCarOnSensor()
        {
            return carOnSensor;
        }
    }
}
