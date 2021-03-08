using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            SmartPhone smartPhone = new SmartPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var item in numbers)
            {
                try
                {
                    string result = item.Length == 10
                ? smartPhone.Call(item)
                    : stationaryPhone.Call(item);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
            foreach (var url in urls)
            {
                try
                {
                    string result = smartPhone.Browse(url);
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
