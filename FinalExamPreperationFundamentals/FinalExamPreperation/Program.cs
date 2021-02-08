using System;

namespace FinalExamPreperation
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] tokens = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Contains":
                        if (activationKey.IndexOf(tokens[1]) != -1)
                        {
                            Console.WriteLine($"{activationKey} contains {tokens[1]}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }
                        break;
                    case "Flip":
                        int startIndex = int.Parse(tokens[2]);
                        int endIndex = int.Parse(tokens[3]);
                        string firstPart = activationKey.Substring(0, startIndex);
                        string secondPart = activationKey.Substring(startIndex, endIndex - startIndex);
                        string thirdPart = activationKey.Substring(endIndex);
                        if (tokens[1].ToUpper() == "UPPER")
                        {
                            secondPart = secondPart.ToUpper();
                        }
                        else
                        {
                            secondPart = secondPart.ToLower();
                        }
                        activationKey = firstPart + secondPart + thirdPart;
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        startIndex = int.Parse(tokens[1]);
                        endIndex = int.Parse(tokens[2]);

                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(activationKey);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
