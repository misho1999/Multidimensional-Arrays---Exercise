using System;
using WarCroft.Core;
using WarCroft.Core.IO;
using WarCroft.Core.IO.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            HealthPotion healthPotion = new HealthPotion();
            FirePotion firePotion = new FirePotion();
            FirePotion firePotion2 = new FirePotion();
            Bag bag = new Bag(70);
            bag.AddItem(firePotion);
            bag.AddItem(healthPotion);
            bag.AddItem(firePotion2);

            string item = firePotion.ToString();
            string items = healthPotion.ToString();
            double sum = (firePotion.Weight + healthPotion.Weight + firePotion2.Weight) / 3;
            bag.GetItem(items);
            Console.WriteLine(sum);
            Console.WriteLine(bag.Load);
            //var engine = new Engine(reader, writer);
            //engine.Run();

                /* Use the below configuration instead of the usual one if you wish to print all output messages together after the inputs for easier comparison with the example output. */

            //IReader reader = new ConsoleReader();
            //var sbWriter = new StringBuilderWriter();

            //var engine = new Engine(reader, sbWriter);
            //engine.Run();

            //Console.WriteLine(sbWriter.sb.ToString().Trim());
        }
	}
}