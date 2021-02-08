using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> towns =
                new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "Sail")
            {
                string[] tokens = command.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string town = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);

                if (towns.ContainsKey(town))
                {
                    towns[town]["population"] += population;
                    towns[town]["gold"] += gold;
                }
                else
                {
                    towns.Add(town, new Dictionary<string, int>()
                    {
                        {"population", population },
                        { "gold", gold }

                    });
                }

                command = Console.ReadLine();

            }
            command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string town = tokens[1];
                int people;
                int gold;
                switch (tokens[0])
                {
                    case "Plunder":
                        people = int.Parse(tokens[2]);
                        gold = int.Parse(tokens[3]);

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        towns[town]["population"] -= people;
                        towns[town]["gold"] -= gold;

                        if (towns[town]["population"] <= 0 || towns[town]["gold"] <=0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            towns.Remove(town);
                        }
                        break;
                    case "Prosper":
                        gold = int.Parse(tokens[2]);

                        if (gold < 0)
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                        }
                        else
                        {
                            towns[town]["gold"] += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town]["gold"]} gold.");
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            if (towns.Count > 0)
            {
                towns = towns
                    .OrderByDescending(t => t.Value["gold"])
                    .ThenBy(t => t.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in towns)
                {
                    int population = town.Value["population"];
                    int gold = town.Value["gold"];
                    Console.WriteLine($"{town.Key} -> Population: {population} citizens, Gold: {gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
