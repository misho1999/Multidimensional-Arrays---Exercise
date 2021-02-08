using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string pattern = @"(=|\/)(?<location>[A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            int travelPoints = 0;
            List<string> destinations = new List<string>();

            foreach (Match destination in matches)
            {
                destinations.Add(destination.Groups["location"].Value);
                travelPoints += destination.Groups["location"].Value.Length;
            }
            Console.WriteLine("Destinations: " + string.Join(", ", destinations));
            Console.WriteLine($"Travel Points: {travelPoints}");

        }
    }
}
