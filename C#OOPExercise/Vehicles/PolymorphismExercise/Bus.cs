using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;

            if (this.FuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }
        public override double TankCapacity { get; set; }
        public override double FuelQuantity { get; set; }
        public override double FuelConsumption { get; set; }
        public override string Driving(double distance)
        {
            if (this.FuelQuantity > distance * (this.FuelConsumption + 1.4))
            {
                this.FuelQuantity -= distance * (this.FuelConsumption + 1.4);
                return $"Bus travelled {distance} km";
            }
            return $"Bus needs refueling";
        }
        public override string DrivingEmpty(double distance)
        {
            if (this.FuelQuantity > distance * this.FuelConsumption)
            {
                this.FuelQuantity -= distance * FuelConsumption;
                return $"Bus travelled {distance} km";
            }
            return $"Bus needs refueling";
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
