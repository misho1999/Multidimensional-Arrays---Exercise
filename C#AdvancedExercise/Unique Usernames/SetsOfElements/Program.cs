using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];
            HashSet<int> nLines = new HashSet<int>();
            HashSet<int> mLines = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int command = int.Parse(Console.ReadLine());
                nLines.Add(command);
            }

            for (int i = 0; i < m; i++)
            {
                int command = int.Parse(Console.ReadLine());
                mLines.Add(command);
            }
            foreach (var item in nLines)
            {
                if (mLines.Contains(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
