using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public bool Drive(double DistanceTravelled)
        {
            double needFuel = DistanceTravelled * this.FuelConsumptionPerKilometer;

            if (needFuel > this.FuelAmount)
            {
                return false;
            }

            this.FuelAmount -= needFuel;
            this.TravelledDistance += DistanceTravelled;
            return true;
        }
    }
}
