using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Done")
            {

                if (input[0] == "TakeOdd")
                {
                    List<char> newPassword = new List<char>();

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            char v = password[i];
                            newPassword.Add(v);


                        }
                    }
                    password = string.Empty;
                    foreach (var item in newPassword)
                    {
                        password += item;
                    }
                    Console.WriteLine(password);
                }
                else if (input[0] == "Cut")
                {
                    int firstIndex = int.Parse(input[1]);
                    int secondIndex = int.Parse(input[2]);
                    password = password.Remove(firstIndex, secondIndex);
                    Console.WriteLine(password);
                }
                else if (input[0] == "Substitute")
                {
                    if (password.Contains(input[1]))
                    {
                        password = password.Replace(input[1], input[2]);

                        Console.WriteLine(password);

                    }
                    else
                    {
                        Console.WriteLine($"Nothing to replace!");
                    }
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
