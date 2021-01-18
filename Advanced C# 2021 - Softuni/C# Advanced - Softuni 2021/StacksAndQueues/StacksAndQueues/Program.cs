using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reverse = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reverse.Push(input[i]);
            }

            while (reverse.Count > 0)
            {
                Console.Write(reverse.Pop());
            }
            Console.WriteLine();
        }
    }
}
