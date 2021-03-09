using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public abstract class Vehicle
    {
        public abstract double TankCapacity { get; set; }
        public abstract double FuelQuantity { get; set; }
    public abstract double FuelConsumption { get; set; }
        public abstract string Driving(double distance);
        public abstract void Refueling(double liters);
        public abstract string DrivingEmpty(double distance);
    }
}
