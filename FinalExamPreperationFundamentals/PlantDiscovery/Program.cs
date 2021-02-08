using System;
using System.Linq;
using System.Collections.Generic;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> plant =
                new Dictionary<string, Dictionary<string, double>>();

            int n = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split("<->");
            string arrPlant = string.Empty;

            for (int i = 0; i < n; i++)
            {
                arrPlant = input[0];
                int arrRarity = int.Parse(input[1]);
                double arrRate = 0;
                if (!plant.ContainsKey(input[0]))
                {
                    plant.Add(arrPlant, new Dictionary<string, double>()
                    {
                        {"Rarity", arrRarity},
                        { "Rate", arrRate}
                    });
                }
                else
                {
                    plant[arrPlant]["Rarity"] = arrRarity;
                }
                if (i == n - 1)
                {
                    break;
                }
                input = Console.ReadLine()
                .Split("<->");

            }

            string[] command = Console.ReadLine()
                .Split(": ");


            


            while (command[0] != "Exhibition")
            {
                if (command[0] == "Rate")
                {
                    string[] locationIndex = command[1].Split(" - ");
                    int index = int.Parse(locationIndex[1]);
                    foreach (var item in plant)
                    {
                        if (item.Key.Contains(locationIndex[0]))
                        {
                            item.Value["Rate"] += index;
                        }
                        if (!plant.ContainsKey(item.Key))
                        {
                            Console.WriteLine("error");
                        }
                    }

                }
                else if (command[0] == "Update")
                {
                    string[] locationIndex = command[1].Split(" - ");
                    int index = int.Parse(locationIndex[1]);
                    foreach (var item in plant)
                    {
                        if (item.Key.Contains(locationIndex[0]))
                        {
                            item.Value["Rarity"] = index;
                        }
                        if (!plant.ContainsKey(item.Key))
                        {
                            Console.WriteLine("error");
                        }
                    }
                }
                else if (command[0] == "Reset")
                {
                    if (command.Contains(command[1]))
                    {
                        plant[command[1]]["Rate"] = 0;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "Exhibition")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("error");
                }



                command = Console.ReadLine()
               .Split(": ");
            }
            foreach (var item in plant)
            {

                plant[item.Key]["Rate"] = plant[item.Key]["Rate"] / 2;
            }
            plant[arrPlant]["Rate"] = plant[arrPlant]["Rate"] / 2;
            plant = plant
                .OrderByDescending(r => r.Value["Rarity"])
                .ThenBy(f => f.Value["Rate"])
                .ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plant)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value["Rarity"]}; Rating: {item.Value["Rate"]:F2}");
            }
        }
    }
}
