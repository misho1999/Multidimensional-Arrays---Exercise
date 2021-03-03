using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int wreathes = 0;
            int flowers = 0;

            while (roses.Count > 0 && lilies.Count > 0)
            {
                int lili = lilies.Pop();
                int rose = roses.Dequeue();

                while (true)
                {
                int sum = lili + rose;
                   
                    if (sum == 15)
                    {
                        wreathes++;
                        break;
                    }
                    else if (sum < 15)
                    {
                        flowers += sum;
                        break;
                    }
                    else
                    {
                        lili -= 2;
                    }
                }


            }
            wreathes += flowers / 15;

            if (wreathes >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathes} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathes} wreaths more!");
            }
        }
    }
}
