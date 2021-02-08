using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SympleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> exppresion = new Stack<string>(input.Reverse());


            while (exppresion.Count > 1)
            {
                int leftNumber = int.Parse(exppresion.Pop());
                string sign = exppresion.Pop();
                int rightNumber = int.Parse(exppresion.Pop());

                if (sign == "+")
                {
                    exppresion.Push((leftNumber + rightNumber).ToString());
                }
                else if (sign == "-")
                {
                    exppresion.Push((leftNumber - rightNumber).ToString());
                }
            }
            Console.WriteLine(exppresion.Pop());

            
        }
    }
}
