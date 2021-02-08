using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondExamProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> Heroes = new Dictionary<string, Dictionary<string, string>>();

            string[] input = Console.ReadLine().Split(" ");
            string heroName = string.Empty;
            string spellName = string.Empty;

            while (input[0] != "End")
            {

                if (input[0] == "Enroll")
                {
                    heroName = input[1];
                    if (!Heroes.ContainsKey(heroName))
                    {
                        Heroes.Add(heroName, new Dictionary<string, string>());
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                if (input[0] == "Learn")
                {
                    heroName = input[1];
                    spellName = input[2];
                    if (Heroes.ContainsKey(heroName))
                    {
                        if (!Heroes[heroName].ContainsValue(spellName))
                        {
                            Heroes[heroName].Add(spellName, spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
                if (input[0] == "Unlearn")
                {
                    heroName = input[1];
                    spellName = input[2];
                    if (Heroes.ContainsKey(heroName))
                    {
                        if (Heroes[heroName].ContainsValue(spellName))
                        {
                            Heroes[heroName].Remove(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }

                input = Console.ReadLine().Split(" ");
            }

            Heroes = Heroes
                .OrderByDescending(c => c.Value.Count())
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Heroes:");
            int counter = 0;
            foreach (var item in Heroes)
            {
                Console.Write($"== {item.Key}: ");
                    counter = item.Value.Count();
                foreach (var kvp in item.Value)
                {
                    if (counter == 1)
                    {
                    Console.Write($"{kvp.Key}");
                        
                    }
                    else
                    {
                        Console.Write($"{kvp.Key}, ");
                        counter--;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
