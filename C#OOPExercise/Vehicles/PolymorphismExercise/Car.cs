using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
            if (this.FuelQuantity > distance * (FuelConsumption + 0.9))
            {
                this.FuelQuantity -= distance * (FuelConsumption + 0.9);
                return $"Car travelled {distance} km";
                
            }
            return $"Car needs refueling";
        }

        public override string DrivingEmpty(double distance)
        {
            throw new NotImplementedException();
        }

        public override void Refueling(double liters)
        {
            Validator.ThrowIfNumbersIsNegative(liters);
            if (this.FuelQuantity + liters < this.TankCapacity)
            {
                this.FuelQuantity += liters;
            }
            else
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
        }
    }
}
