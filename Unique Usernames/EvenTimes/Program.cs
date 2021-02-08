using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            HashSet<int> evenNumber = new HashSet<int>();
            List<int> numbers = new List<int>();

            for (int i = 0; i < lines; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (numbers.Contains(input))
                {
                    evenNumber.Add(input);
                    
                }
                numbers.Add(input);
            }
            if (evenNumber.Count > 0)
            {
                foreach (var item in evenNumber)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
