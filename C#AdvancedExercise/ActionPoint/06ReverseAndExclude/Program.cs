using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            numbers.Reverse();

            Func<int, bool> predicate = num => num % n != 0;
            //numbers = numbers.Where(n => n % n != 0).ToList();
            //numbers = numbers.Where(n => predicate(n)).ToList();
            numbers = numbers.Where(predicate).ToList();

            Action<List<int>> print = num => Console.WriteLine(string.Join(" ", num));
            print(numbers);
        }
    }
}
