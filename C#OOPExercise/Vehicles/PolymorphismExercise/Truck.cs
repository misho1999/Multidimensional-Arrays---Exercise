using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption += fuelConsumption;
        }
        public override double FuelQuantity { get; set; }
        public override double FuelConsumption { get; set; }
        public override string Driving(double distance)
        {
            if (this.FuelQuantity > distance * (FuelConsumption + 1.6))
            {
                this.FuelQuantity -= distance * (FuelConsumption + 1.6);
               return $"Truck travelled {distance} km";
            }
           return $"Truck needs refueling";
        }

        public override void Refueling(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }
    }
}
