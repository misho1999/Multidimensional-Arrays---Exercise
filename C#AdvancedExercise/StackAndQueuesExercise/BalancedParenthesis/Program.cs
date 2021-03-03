using System;
using System.Collections;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> open = new Stack<char>();
            string input = Console.ReadLine();
            bool isValid = true;
            foreach (char item in input)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    open.Push(item);
                }
                else
                {
                    bool isFirstValid = item == ')' && open.Pop() == '(';
                    bool isSecondValid = item == '}' && open.Pop() == '{';
                    bool isThirdValid = item == ']' && open.Pop() == '[';
                    if (!isFirstValid && isSecondValid && isThirdValid)
                    {
                        isValid = false;
                        Console.WriteLine("NO");
                        break;
                    }

                }
            }
            Console.WriteLine("YES");
        }
    }
}
