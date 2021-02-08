using System;
using System.Collections.Generic;
using System.Linq;


namespace _07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, bool> func = name => name.Length <= n;
            names = names.Where(func).ToList();
            //names = names.Where(name => name.Length <= n).ToList();
            Action<List<string>> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));
            print(names);
        }
    }
}
