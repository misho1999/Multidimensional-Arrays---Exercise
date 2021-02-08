using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> heroes =
               new Dictionary<string, Dictionary<string, int>>();
            string nameHeroe = string.Empty;
            int hpHeroe = 100;
            int mpHeroe = 200;
            int numHeroes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numHeroes; i++)
            {
                string[] partyHeroes = Console.ReadLine().Split(" ");
                nameHeroe = partyHeroes[0];
                hpHeroe = int.Parse(partyHeroes[1]);
                mpHeroe = int.Parse(partyHeroes[2]);

                if (hpHeroe <= 100 && mpHeroe <= 200)
                {
                    heroes.Add(nameHeroe, new Dictionary<string, int>()
                {
                    {"hpHeroe", hpHeroe },
                    {"mpHeroe", mpHeroe }
                });
                }

            }

            string[] command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {

                if (command[0] == "CastSpell")
                {


                    foreach (var item in heroes)
                    {

                        if (item.Key.Contains(command[1]))
                        {

                            int neededMp = int.Parse(command[2]);
                            if (item.Value["mpHeroe"] >= neededMp)
                            {

                                item.Value["mpHeroe"] -= neededMp;
                                Console.WriteLine($"{item.Key} has successfully cast {command[3]} and now has {item.Value["mpHeroe"]} MP!");
                            }
                            else if (item.Value["mpHeroe"] < neededMp)
                            {
                                Console.WriteLine($"{item.Key} does not have enough MP to cast {command[3]}!");
                            }
                        }
                    }

                }
                else if (command[0] == "TakeDamage")
                {
                    foreach (var item in heroes)
                    {
                        if (item.Key.Contains(command[1]))
                        {
                            int demage = int.Parse(command[2]);
                            item.Value["hpHeroe"] -= demage;
                            if (item.Value["hpHeroe"] > 0)
                            {
                                Console.WriteLine($"{item.Key} was hit for {demage} HP by {command[3]} and now has {item.Value["hpHeroe"]} HP left!");
                            }
                            else
                            {
                                Console.WriteLine($"{item.Key} has been killed by {command[3]}!");
                                heroes.Remove(item.Key);
                            }
                        }
                    }
                }
                else if (command[0] == "Recharge")
                {
                    int check = int.Parse(command[2]);
                    foreach (var item in heroes)
                    {
                        if (item.Key.Contains(command[1]))
                        {
                            if (item.Value["mpHeroe"] + check <= 200)
                            {
                                item.Value["mpHeroe"] += check;
                                Console.WriteLine($"{item.Key} recharged for {check} MP!");
                            }
                            else if (item.Value["mpHeroe"] + check > 200)
                            {
                                check = 200 - item.Value["mpHeroe"];
                                item.Value["mpHeroe"] = 200;
                                Console.WriteLine($"{item.Key} recharged for {Math.Abs(check)} MP!");
                            }
                        }
                    }
                }
                else if (command[0] == "Heal")
                {
                    int check = int.Parse(command[2]);
                    foreach (var item in heroes)
                    {
                        if (item.Key.Contains(command[1]))
                        {
                            if (item.Value["hpHeroe"] + check <= 100)
                            {
                                item.Value["hpHeroe"] += check;
                                Console.WriteLine($"{item.Key} healed for {check} HP!");
                            }
                            else if (item.Value["hpHeroe"] + check > 100)
                            {
                                check = 100 - item.Value["hpHeroe"];
                                item.Value["hpHeroe"] = 100;
                                Console.WriteLine($"{item.Key} healed for {Math.Abs(check)} HP!");
                            }
                        }
                    }
                }
                command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (heroes.Count > 0)
            {
                heroes = heroes
                    .OrderByDescending(h => h.Value["hpHeroe"])
                    .ThenBy(n => n.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                foreach (var item in heroes)
                {
                    Console.WriteLine($"{item.Key}");
                    Console.WriteLine($"  HP: {item.Value["hpHeroe"]}");
                    Console.WriteLine($"  MP: {item.Value["mpHeroe"]}");
                }
            }
        }
    }
}
