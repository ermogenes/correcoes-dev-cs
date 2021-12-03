using System;

namespace Fatorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Número: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            if (numero < 0 || numero >= 32)
            {
                Console.WriteLine("Digite um número natural positivo menor do que 32.");
            }
            else
            {
                int fatorial = 1;

                if (numero >= 2)
                {
                    int i = 2;

                    while(i <= numero)
                    {
                        fatorial = fatorial * i;
                        i += 1;
                    }
                }

                Console.WriteLine($"{numero}! = {fatorial}");
            }
        }
    }
}
