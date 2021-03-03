using System;
using System.Linq;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            SortedSet<string> chemicalCompounds = new SortedSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 1)
                {
                    chemicalCompounds.Add(input[0]);
                }
                else
                {
                    foreach (var item in input)
                    {
                        chemicalCompounds.Add(item);
                    }
                }
             
            }
            foreach (var item in chemicalCompounds)
            {
                Console.Write(item + " ");
            }
        }
    }
}
