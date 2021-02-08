using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> ranking =
                new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> contestPass = new Dictionary<string, string>();
            int points = 0;
            string name = string.Empty;
            string[] input = Console.ReadLine()
                .Split(":");

            while (input[0] != "end of contests")
            {

                contestPass.Add(input[0], input[1]);
                input = Console.ReadLine()
                .Split(":");
            }

            input = Console.ReadLine()
                .Split("=>");

            while (input[0] != "end of submissions")
            {
                name = input[2];
                points = int.Parse(input[3]);
                if (contestPass.ContainsKey(input[0]) && contestPass.ContainsValue(input[1]))
                {
                    if (ranking.ContainsKey(input[0]))
                    {

                        if (ranking[input[0]].ContainsKey(input[2]))
                        {
                            foreach (var item in ranking)
                            {
                                if (item.Key.Contains(input[0]))
                                {
                                    if (item.Value.Keys.Contains(input[2]))
                                    {
                                        if (item.Value[name] < points)
                                        {
                                            item.Value[name] = points;
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            ranking[input[0]].Add(name, points);
                        }
                    }
                    else
                    {
                        points = int.Parse(input[3]);
                        ranking.Add(input[0], new Dictionary<string, int>
                    {


                        {name, points}

                    });
                    }

                }
                input = Console.ReadLine()
           .Split("=>");
            }
            points = 0;
            Dictionary<string, int> sum = new Dictionary<string, int>();
            foreach (var item in ranking)
            {
                sum[item.Key] = item.Value.Values.Sum();

            }
            string bestCandidate = sum
            .Keys
            .Max();
            int bestPoints = sum
                .Values
                .Max();
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var kvp in ranking)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(string.Join(Environment.NewLine, kvp.Value
                    .OrderByDescending(x => x.Value)
                    .Select(a => $"#  {a.Key} -> {a.Value}")
                    ));
            }
        }
    }
}
