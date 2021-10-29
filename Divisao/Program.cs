using System;

namespace Divisao
{
    class Program
    {
        static void Main(string[] args)
        {
            double numerador, denominador, quociente;

            Console.Write("Digite o numerador......: ");
            numerador = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o denominador....: ");
            denominador = Convert.ToDouble(Console.ReadLine());

            if (denominador == 0)
            {
                Console.WriteLine("Não é possível dividir por zero.");
            }
            else
            {
                quociente = numerador / denominador;

                Console.WriteLine($"{numerador:N1} dividido por {denominador:N1} é {quociente:N1}.");
            }
        }
    }
}