using System;
using System.Linq;

namespace FirstExamProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            int index;
            int count;
            string[] input = Console.ReadLine()
                .Split(" ");

            while (input[0] != "For")
            {
                if (input[0] == "GladiatorStance")
                {
                    skill = skill.ToUpper();

                }
                else if (input[0] == "DefensiveStance")
                {
                    skill = skill.ToLower();

                }
                else if (input[0] == "Dispel")
                {
                    index = int.Parse(input[1]);
                    count = skill.Count();
                    if (count > index)
                    {
                        skill = skill.Remove(index, 1);
                        skill = skill.Insert(index, input[2]);

                        Console.WriteLine("Success!");
                        input = Console.ReadLine()
                .Split(" ");
                        if (input[0] == "For")
                        {
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                        input = Console.ReadLine()
                .Split(" ");
                        if (input[0] == "For")
                        {
                            break;
                        }
                        continue;
                    }
                }
                else if (input[0] == "Target")
                {
                    if (input[1] == "Change")
                    {
                        if (skill.Contains(input[2]))
                        {
                            count = input[2].Count();
                            index = skill.IndexOf(input[2]);
                            skill = skill.Remove(index, count);
                            skill = skill.Insert(index, input[3]);
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                            input = Console.ReadLine()
                    .Split(" ");
                            if (input[0] == "For")
                            {
                                break;
                            }
                            continue;
                        }

                    }
                    else if (input[1] == "Remove")
                    {
                        if (skill.Contains(input[2]))
                        {
                            count = input[2].Count();
                            index = skill.IndexOf(input[2]);
                            skill = skill.Remove(index, count);
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                            input = Console.ReadLine()
                    .Split(" ");
                            if (input[0] == "For")
                            {
                                break;
                            }
                            continue;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist!");
                        input = Console.ReadLine()
                .Split(" ");
                        if (input[0] == "For")
                        {
                            break;
                        }
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                    input = Console.ReadLine()
            .Split(" ");
                    if (input[0] == "For")
                    {
                        break;
                    }
                    continue;
                }


                Console.WriteLine(skill);
                input = Console.ReadLine()
                .Split(" ");
            }
        }
    }
}
