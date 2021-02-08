using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ThirdExamProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(([|])([A-Z]{4,})([|]):([#])([A-Za-z]+) ([A-Za-z]+)([#]))";
            int times = int.Parse(Console.ReadLine());
            for (int i = 0; i < times; i++)
            {

                string command = Console.ReadLine();
                Regex boss = new Regex(pattern);
                var check = boss.Match(command);
                if (check.Success)
                {
                    string[] input = command
                        .Split(":");
                    string bossName = input[0];
                    string bossTitle = input[1];
                    int strength;
                    int armour;
                    for (int k = 0; k < bossName.Length; k++)
                    {
                        if (bossName.Contains("|"))
                        {
                            int index = bossName.IndexOf("|");
                            bossName = bossName.Remove(index, 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int l = 0; l < bossTitle.Length; l++)
                    {
                        if (bossTitle.Contains("#"))
                        {
                            int index = bossTitle.IndexOf("#");
                            bossTitle = bossTitle.Remove(index, 1);
                        }
                    }

                    strength = bossName.Length;
                    armour = bossTitle.Length;

                    Console.WriteLine($"{bossName}, The {bossTitle}");
                    Console.WriteLine($">> Strength: {strength}");
                    Console.WriteLine($">> Armour: {armour}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
