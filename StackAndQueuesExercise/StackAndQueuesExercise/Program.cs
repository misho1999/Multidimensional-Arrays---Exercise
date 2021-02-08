using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueuesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = data[0];
            int y = data[1];
            int x = data[2];

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                numbers.Push(input[i]);
            }

            for (int i = 0; i < y; i++)
            {
                numbers.Pop();
            }

            bool isFound = numbers.Contains(x);

            if (isFound)
            {
                Console.WriteLine("true");
            }
            else if (!numbers.Any())
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }


        }
    }
}
