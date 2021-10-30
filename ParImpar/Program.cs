using System;

namespace ParImpar
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;
            string paridade;

            Console.Write("Digite um número: ");
            numero = Convert.ToInt32(Console.ReadLine());

            paridade = (numero % 2) == 0 ? "par" : "ímpar";

            Console.WriteLine($"{numero} é {paridade}");
        }
    }
}
