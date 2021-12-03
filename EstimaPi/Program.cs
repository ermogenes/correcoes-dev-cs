using System;

namespace EstimaPi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Estimador do valor de pi pelo método de Leibniz --");

            Console.Write("Quantas iterações? ");
            int numeroIteracoes = Convert.ToInt32(Console.ReadLine());

            int n = 0;
            double estimativaPi = 0;
            while(n <= numeroIteracoes)
            {
                estimativaPi += Math.Pow(-1, n) * ( 4D / (2 * n + 1) );
                n += 1;
            }

            Console.WriteLine($"O resultado esperado é se aproximar de: {Math.PI:N8}\n");

            Console.WriteLine($"Estimativa com {numeroIteracoes} iterações: {estimativaPi:N8}");
        }
    }
}
