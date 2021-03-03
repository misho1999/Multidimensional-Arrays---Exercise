using System;
using System.Collections.Generic;
using System.Linq;

namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbers = Enumerable.Range(1, end).ToList();
            //Func<int, int, bool> predicate =
            //    (num, d) => num % d == 0;

            foreach (int num in numbers)
            {
                //if (dividers .All(d => predicate(num, d)))
                if (dividers.All(d => num % d == 0))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
