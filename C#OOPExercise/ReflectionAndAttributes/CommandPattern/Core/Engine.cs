using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();

                string result = this.commandInterpreter.Read(line);

                if (result == null)
                {
                    break;
                }
                Console.WriteLine(result);
            }
        }
    }
}
