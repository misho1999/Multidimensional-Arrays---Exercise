using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> guests =
               new Dictionary<string, Dictionary<string, string>>();
            string[] input = Console.ReadLine()
                .Split("-");
            int count = 0;
            string nameGuest = string.Empty;
            string like = string.Empty;
            string unlike = string.Empty;
            string meal = string.Empty;

            while (input[0] != "Stop")
            {
                like = input[0];
                nameGuest = input[1];
                meal = input[2];



                if (input[0] == "Like")
                {
                    if (count == 0)
                    {
                        guests.Add(like, new Dictionary<string, string>()
                            {
                            {"nameGuest", nameGuest},
                                {"meal", meal }
                            });
                        count++;
                    }
                    foreach (var item in guests)
                    {

                        if (!guests[like].ContainsKey(item.Value["nameGuest"]))
                        {
                            guests[like].Add(item.Value["nameGuest"], nameGuest);
                            guests[like].Add(item.Value["meal"], meal);
                        }
                        else if (!guests[like].ContainsValue(meal))
                        {
                            guests[like].Add(item.Value["meal"], meal);


                        }
                    }

                }
                else if (input[0] == "Unlike")
                {

                }
                input = Console.ReadLine()
                .Split("-");
            }
        }
    }
}
