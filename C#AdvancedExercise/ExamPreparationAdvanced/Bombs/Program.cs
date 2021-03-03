using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>();
            Stack<int> bombCasing = new Stack<int>();

            List<int> effectsInput = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            List<int> casingInput = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            foreach (var item in effectsInput)
            {
                bombEffects.Enqueue(item);
            }
            foreach (var item in casingInput)
            {
                bombCasing.Push(item);
            }
            //Dictionary<string, int> createdBombs = new Dictionary<string, int>();
            SortedDictionary<string, int> createdBombs = new SortedDictionary<string, int>();
            createdBombs.Add("Datura Bombs", 0);
            createdBombs.Add("Cherry Bombs", 0);
            createdBombs.Add("Smoke Decoy Bombs", 0);
            bool isBombPouch = false;


            while (bombEffects.Count > 0 && bombCasing.Count > 0)
            {
                int currentEffect = bombEffects.Peek();
                int currentCasing = bombCasing.Peek();
                int mixBombs = currentEffect + currentCasing;

                if (mixBombs == 40)
                {

                    createdBombs["Datura Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                }
                else if (mixBombs == 60)
                {

                    createdBombs["Cherry Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                }
                else if (mixBombs == 120)
                {

                    createdBombs["Smoke Decoy Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    currentCasing -= 5;
                    bombCasing.Pop();
                    bombCasing.Push(currentCasing);
                }

                if (createdBombs["Datura Bombs"] >= 3 && createdBombs["Cherry Bombs"] >= 3 && createdBombs["Smoke Decoy Bombs"] >= 3)
                {
                    Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
                    Console.Write($"Bomb Effects: ");
                    int count = 0;
                    if (bombEffects.Count > 0)
                    {
                        foreach (var item in bombEffects)
                        {
                            count++;
                            if (count == bombEffects.Count)
                            {
                                Console.Write($"{item}");
                            }
                            else
                            {
                                Console.Write($"{item}, ");
                            }
                        }
                        //Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("empty");
                    }
                    Console.WriteLine();
                    Console.Write($"Bomb Casings: ");
                    count = 0;
                    if (bombCasing.Count > 0)
                    {
                        foreach (var item in bombCasing)
                        {
                            count++;
                            if (count == bombCasing.Count)
                            {
                                Console.Write($"{item}");
                            }
                            else
                            {
                                Console.Write($"{item}, ");
                            }
                        }
                        //Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("empty");
                    }
                    Console.WriteLine();

                    foreach (var item in createdBombs)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    isBombPouch = true;
                    break;
                }

            }
            if (isBombPouch == false)
            {
            int count = 0;
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
                Console.Write($"Bomb Effects: ");
                if (bombEffects.Count > 0)
                {
                    foreach (var item in bombEffects)
                    {
                        count++;
                        if (count == bombEffects.Count)
                        {
                            Console.Write($"{item}");
                        }
                        else
                        {
                            Console.Write($"{item}, ");
                        }
                    }
                    //Console.WriteLine();
                }
                else
                {
                    Console.Write("empty");
                }
                Console.WriteLine();
                Console.Write($"Bomb Casings: ");
                count = 0;
                if (bombCasing.Count > 0)
                {
                    foreach (var item in bombCasing)
                    {
                        count++;
                        if (count == bombCasing.Count)
                        {
                            Console.Write($"{item}");
                        }
                        else
                        {
                            Console.Write($"{item}, ");
                        }
                    }
                    //Console.WriteLine();
                }
                else
                {
                    Console.Write("empty");
                }
                Console.WriteLine();
                foreach (var item in createdBombs)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

            }

        }
    }
}
