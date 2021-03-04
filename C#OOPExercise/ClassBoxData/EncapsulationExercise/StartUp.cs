using System;

namespace EncapsulationExercise
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lenght = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            try
            {
                var box = new Box(lenght, width, height);

                Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.CalculateVolume():F2}");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
