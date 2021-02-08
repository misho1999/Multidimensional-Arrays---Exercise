using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carsData = Console.ReadLine().Split();

                string model = carsData[0];
                double fuelAmount = double.Parse(Console.ReadLine());
                double fuelConsumptionForOneKm = double.Parse(Console.ReadLine());

                Car currCar = new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionForOneKm
                        
                };
            }
        string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandData = command.Split(" ");
                string model = commandData[1];

                double distanceTravelled = double.Parse(commandData[2]);
                //Car cars = cars.FirstOrDefault
            }
        }

    }
}
