using System;

namespace _01ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> actionPrint = Print;
            actionPrint(names);
        }
        static void Print(string[] name)
        {
            for (int i = 0; i < name.Length; i++)
            {
            Console.WriteLine(name[i]);
            }
        }

    }
}
