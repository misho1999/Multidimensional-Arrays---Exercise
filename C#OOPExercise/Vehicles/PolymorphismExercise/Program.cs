using System;
using System.Collections.Generic;

namespace PolymorphismExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            input = Console.ReadLine().Split();

            Vehicle truck = new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            input = Console.ReadLine().Split();

            Vehicle bus = new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string result = string.Empty;
                    string[] command = Console.ReadLine().Split();
                    if (command[1] == "Car")
                    {
                        if (command[0] == "Drive")
                        {
                            result = car.Driving(double.Parse(command[2]));
                            Console.WriteLine(result);
                        }
                        else if (command[0] == "Refuel")
                        {
                            car.Refueling(double.Parse(command[2]));
                        }


                    }
                    else if (command[1] == "Truck")
                    {
                        if (command[0] == "Drive")
                        {
                            result = truck.Driving(double.Parse(command[2]));
                            Console.WriteLine(result);
                        }
                        else if (command[0] == "Refuel")
                        {
                            truck.Refueling(double.Parse(command[2]));
                        }
                    }
                    else if (command[1] == "Bus")
                    {
                        if (command[0] == "Drive")
                        {
                            result = bus.Driving(double.Parse(command[2]));
                            Console.WriteLine(result);
                        }
                        else if (command[0] == "DriveEmpty")
                        {
                            result = bus.DrivingEmpty(double.Parse(command[2]));
                            Console.WriteLine(result);
                        }
                        else if (command[0] == "Refuel")
                        {
                            bus.Refueling(double.Parse(command[2]));
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
               

            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");


        }
    }
}
