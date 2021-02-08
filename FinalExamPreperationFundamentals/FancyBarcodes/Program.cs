using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\A@#+)([A-Z][A-Za-z\d]{4,}[A-Z])@#+$";
            string numPattern = @"\d+";
            Regex validBarcode = new Regex(pattern);
            Regex numReg = new Regex(numPattern);

            int numBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numBarcodes; i++)
            {
                string input = Console.ReadLine();
                var check = validBarcode.Match(input);


                if (check.Success)
                {
                    var numCheck = numReg.Match(input);
                    if (numCheck.Success)
                    {

                        var countCheck = numReg.Matches(input);
                            if (numCheck.Length != 0)
                            {
                                
                            Console.WriteLine($"Product group: {string.Join("", countCheck)}");
                            }
                            else
                            {

                            Console.WriteLine($"Product group: 0");
                            }
                        

                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
