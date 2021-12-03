using System;

namespace EstimaEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Estimador de Euler --");

            Console.Write("Quantas iterações (<=33)? ");
            int numeroIteracoes = Convert.ToInt32(Console.ReadLine());

            if (numeroIteracoes <= 0 || numeroIteracoes > 33)
            {
                Console.WriteLine("Digite um número entre 1 e 33.");
            }
            else
            {
                int n = 0;
                int fatorialN = 1;
                double estimativaE = 0;

                while (n <= numeroIteracoes)
                {
                    if (n > 0)
                    {
                        fatorialN = fatorialN * n;
                    }

                    estimativaE += 1d / fatorialN;
                    n += 1;
                }

                Console.WriteLine($"Estimativa: {estimativaE:N10}");
            }
        }
    }
}
