using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMassege = Console.ReadLine();

            string[] input = Console.ReadLine()
                .Split(":|:");

            while (input[0] != "Reveal")
            {
                if (input[0] == "InsertSpace")
                {
                    string space = " ";
                    int index = int.Parse(input[1]);
                    secretMassege = secretMassege.Insert(index, space);

                }
                if (input[0] == "Reverse")
                {
                    if (secretMassege.Contains(input[1]))
                    {
                        string command = string.Empty;
                        int index = 0;
                        index = secretMassege.IndexOf(input[1]);
                        int count = 0;
                        count = input[1].Count();
                        command = input[1];
                        char[] reverse = command.ToCharArray();
                            string reverseCommand = string.Empty;
                        for (int i = command.Length; i > 0; i--)
                        {
                             reverseCommand += reverse[i - 1];
                        }
                        secretMassege = secretMassege.Remove(index, count);
                        int secondCount = secretMassege.Count();
                        secretMassege = secretMassege.Insert(secondCount, reverseCommand);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        break;
                    }
                }
                if (input[0] == "ChangeAll")
                {
                    if (secretMassege.Contains(input[1]))
                    {
                        secretMassege = secretMassege.Replace(input[1], input[2]);
                    }
                }

                Console.WriteLine(secretMassege);

                input = Console.ReadLine()
               .Split(":|:");
            }
            Console.WriteLine($"You have a new text message: { secretMassege}");
        }
    }
}
