using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> commands = new Stack<int>();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                if (input[0] == 1)
                {
                    commands.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    if (commands.Count > 0)
                    {
                    commands.Pop();
                    }
                }
                else if (input[0] == 3)
                {
                    if (commands.Count > 0)
                    {
                    Console.WriteLine(commands.Max());
                    }
                }
                else if (input[0] == 4)
                {
                    if (commands.Count > 0)
                    {
                        Console.WriteLine(commands.Min());
                    }
                }
                if (i < n - 1)
                {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                }
            }
            Console.WriteLine(string.Join(", ", commands));
        }
    }
}
