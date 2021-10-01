using System;

namespace GrausCF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a temperatura em graus Celsius: ");
            double tempC = Convert.ToDouble(Console.ReadLine());

            double tempF = tempC * 1.8 + 32;

            Console.WriteLine($"{tempC}°C equivalem a {tempF}°F");
        }
    }
}
