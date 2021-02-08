using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            bool isFound = false;

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string[] splitted = input[1].Split(",");
                int count = 1;
                if (wardrobe.Count >= 1)
                {
                    for (int j = 0; j < splitted.Length; j++)
                    {
                        if (wardrobe.Count >= 1)
                        {
                            if (wardrobe.ContainsKey(input[0]))
                            {
                                foreach (var item in wardrobe)
                                {
                                    if (item.Key == input[0])
                                    {
                                        if (item.Value.ContainsKey(splitted[j]))
                                        {
                                            item.Value[splitted[j]] += 1;
                                        }
                                        else
                                        {
                                            item.Value.Add(splitted[j], count);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                wardrobe.Add(input[0], new Dictionary<string, int>()
                            {
                                { splitted[j], count }


                            });
                            }

                        }
                        else
                        {
                            wardrobe.Add(input[0], new Dictionary<string, int>()
                            {
                                { splitted[j], count }


                            });
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < splitted.Length; j++)
                    {
                        if (wardrobe.Count >= 1)
                        {
                            if (wardrobe.ContainsKey(input[0]))
                            {
                                foreach (var item in wardrobe.Values)
                                {
                                    if (item.ContainsKey(splitted[j]))
                                    {
                                        item[splitted[j]] += 1;
                                    }
                                    else
                                    {
                                        item.Add(splitted[j], count);
                                    }

                                }
                            }
                            else
                            {
                                wardrobe.Add(input[0], new Dictionary<string, int>()
                            {
                                { splitted[j], count }


                            });
                            }

                        }
                        else
                        {
                            wardrobe.Add(input[0], new Dictionary<string, int>()
                            {
                                { splitted[j], count }


                            });
                        }
                    }
                }
            }
            string[] lastInput = Console.ReadLine().Split();
            

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                if (isFound != true)
                {
                    foreach (var items in item.Value)
                    {
                        if (items.Key.Contains(lastInput[1]) && isFound != true)
                        {
                        Console.WriteLine($"* {items.Key} - {items.Value} (found!)");
                        isFound = true;
                        }
                        else
                        {
                            Console.WriteLine($"* {items.Key} - {items.Value}");
                        }
                    }
                }
                else
                {
                    foreach (var items in item.Value)
                    {
                        Console.WriteLine($"* {items.Key} - {items.Value}");
                        
                    }
                }
                

            }
        }
    }
}
