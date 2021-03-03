using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();

            string commandInput = Console.ReadLine();

            while (commandInput != "END")
            {
                string[] commandData = commandInput.Split(new string[] {" ", ", "}, StringSplitOptions.RemoveEmptyEntries);
                string command = commandData[0];
                if (command == "Push")
                {
                    for (int i = 1; i < commandData.Length; i++)
                    {
                        int item = int.Parse(commandData[i]);
                        myStack.Push(item);
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                commandInput = Console.ReadLine();
            }

            foreach (int item in myStack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(Environment.NewLine, myStack));
        }
    }
}
