using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Car[] cars = new Car[count];

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int speed = int.Parse(tokens[1]);
                int power = int.Parse(tokens[2]);
                int weight = int.Parse(tokens[3]);
                string type = tokens[4];
                double tyre1Pressure = double.Parse(tokens[5]);
                int tyre1Age = int.Parse(tokens[6]);
                double tyre2Pressure = double.Parse(tokens[7]);
                int tyre2Age = int.Parse(tokens[8]);
                double tyre3Pressure = double.Parse(tokens[9]);
                int tyre3Age = int.Parse(tokens[10]);
                double tyre4Pressure = double.Parse(tokens[11]);
                int tyre4Age = int.Parse(tokens[12]);

                cars[i] = new Car(model, new Engine(speed, power), new Cargo(type, weight), new List<Tire> { new Tire(tyre1Pressure, tyre1Age), new Tire(tyre2Pressure, tyre2Age), new Tire(tyre3Pressure, tyre3Age), new Tire(tyre4Pressure, tyre4Age) });
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars.Where(c => c.Cargo.type == "fragile").Where(c => c.Tires.Any(t => t.pressure < 1)).Select(c => c.Model).ToList().ForEach(m => Console.WriteLine(m));
            }
            else if (command == "flamable")
            {
                cars.Where(c => c.Cargo.type == "flamable").Where(c => c.Engine.power > 250).Select(c => c.Model).ToList().ForEach(m => Console.WriteLine(m));
            }
            //string date1 = Console.ReadLine();
            //string date2 = Console.ReadLine();

            //DateModifier dateModifier = new DateModifier();

            //Console.WriteLine(dateModifier.CalculateDifference(date1, date2));
            // int numberOfFamily = int.Parse(Console.ReadLine());

            // Family family = new Family();
            // int count = 0;
            // for (int i = 0; i < numberOfFamily; i++)
            // {
            //     string[] personsArr = Console.ReadLine().Split();
            //     Person member = new Person(personsArr[0], int.Parse(personsArr[1]));
            //     family.AddMember(member);
            //     count++;
            // }

            // List<Person> ageMoreThan30 = family.PrintPersonsAgeMoreThan30();
            //var ageMoreThan30Years = ageMoreThan30.OrderBy(n => n.Name);

            // foreach (var item in ageMoreThan30Years)
            // {
            //     Console.WriteLine($"{item.Name} - {item.Age}");
            // }
            //Person oldestPerson = family.GetOldestMember();
            //Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);

        }
    }
}
