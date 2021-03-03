using System;
using System.Collections.Generic;

namespace SetsAndDictionariesAdvanced_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
            string input = Console.ReadLine();
                usernames.Add(input);
            }
            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
