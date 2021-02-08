using System;
using System.Linq;

namespace Mirrorwords
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string[] input = Console.ReadLine()
                .Split(" ");

            while (input[0] != "Sign")
            {
                if (input[0] == "Case")
                {
                    if (input[1] == "lower")
                    {
                        username = username.ToLower();
                    }
                    else if (input[1] == "upper")
                    {
                        username = username.ToUpper();
                    }
                }
                if (input[0] == "Reverse")
                {
                    int firstIndex = int.Parse(input[1]);
                    int secondIndex = int.Parse(input[2]);
                    if (username.Length > firstIndex && username.Length >= secondIndex)
                    {
                        string substring = username.Substring(firstIndex, secondIndex);
                        char[] reverse = substring.ToCharArray();
                        string reverseSubstring = string.Empty;
                        for (int i = substring.Length; i > 0; i--)
                        {
                            reverseSubstring += reverse[i - 1];
                        }
                        Console.WriteLine(reverseSubstring);
                        input = Console.ReadLine()
                    .Split(" ");
                        if (input[0] == "Sign")
                        {
                            break;
                        }
                        continue;
                    }

                }
                if (input[0] == "Cut")
                {
                    if (username.Contains(input[1]))
                    {
                        int index = username.IndexOf(input[1]);
                        int lastIndex = username.IndexOf(input[1]);
                        lastIndex -= 1;
                        username = username.Remove(index, input[1].Count());
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {input[1]}.");
                        input = Console.ReadLine()
                    .Split(" ");
                        if (input[0] == "Sign")
                        {
                            break;
                        }
                        continue;
                    }
                }
                if (input[0] == "Replace")
                {
                    if (username.Contains(input[1]))
                    {

                        string star = "*";
                        username = username.Replace(input[1], star);

                    }
                }
                if (input[0] == "Check")
                {
                    if (username.Contains(input[1]))
                    {
                        Console.WriteLine("Valid");
                        input = Console.ReadLine()
                    .Split(" ");
                        if (input[0] == "Sign")
                        {
                            break;
                        }
                        continue;
                    }
                    else
                    {

                        Console.WriteLine($"Your username must contain {input[1]}.");
                        input = Console.ReadLine()
                    .Split(" ");
                        if (input[0] == "Sign")
                        {
                            break;
                        }
                        continue;
                    }
                }

                Console.WriteLine(username);

                input = Console.ReadLine()
                    .Split(" ");
            }
        }
    }
}
