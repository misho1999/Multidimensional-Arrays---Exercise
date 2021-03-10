using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption += fuelConsumption;
            this.TankCapacity = tankCapacity;
            if (this.FuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }
        public override double FuelQuantity { get; set; }
        public override double FuelConsumption { get; set; }
        public override double TankCapacity { get; set; }

        public override string Driving(double distance)
        {
            if (this.FuelQuantity > distance * (FuelConsumption + 1.6))
            {
                this.FuelQuantity -= distance * (FuelConsumption + 1.6);
               return $"Truck travelled {distance} km";
            }
           return $"Truck needs refueling";
        }

        public override string DrivingEmpty(double distance)
        {
            throw new NotImplementedException();
        }

        public override void Refueling(double liters)
        {
            Validator.ThrowIfNumbersIsNegative(liters);
            if (this.FuelQuantity + liters * 0.95 < this.TankCapacity)
            {
            this.FuelQuantity += liters * 0.95;
            }
            else
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }

        }
    }
}
