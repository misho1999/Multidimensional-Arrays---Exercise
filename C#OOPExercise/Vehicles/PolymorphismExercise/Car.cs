using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption += fuelConsumption;
        }
        public override double FuelQuantity { get; set; }

        public override double FuelConsumption { get; set; }



        public override string Driving(double distance)
        {
            if (this.FuelQuantity > distance * (FuelConsumption + 0.9))
            {
                this.FuelQuantity -= distance * (FuelConsumption + 0.9);
                return $"Car travelled {distance} km";
                
            }
            return $"Car needs refueling";
        }

        public override void Refueling(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
