using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    abstract class Sensor
    {
        protected bool carOnSensor;
        protected bool carOnSensor2;

        public Sensor()
        {

        }

        public abstract void CarDetected();


        public abstract void CarDetected2();

        public abstract void CarLeftSensor();

        public abstract void CarLeftSensor2();

        public bool IsCarOnSensor()
        {
            return carOnSensor;
        }

        public bool IsCarOnSensor2()
        {
            return carOnSensor2;
        }
    }
}
