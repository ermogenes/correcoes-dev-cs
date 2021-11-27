using System;

namespace Elefante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantos elefantes: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            if (quantidade <= 2 || quantidade % 2 == 1)
            {
                Console.WriteLine("\nSomente serão aceitos números pares de elefantes, maiores do que 2.");
            }
            else
            {
                int elefantesAtuais = 1;

                while (elefantesAtuais <= quantidade)
                {
                    if (elefantesAtuais == 1)
                    {
                        Console.WriteLine($"\n{elefantesAtuais} elefante incomoda muita gente");
                    }
                    else
                    {
                        Console.WriteLine($"\n{elefantesAtuais} elefantes incomodam muita gente");
                    }

                    elefantesAtuais += 1;

                    Console.Write($"{elefantesAtuais} elefantes ");

                    int incomoda = 1;
                    while (incomoda <= elefantesAtuais)
                    {
                        Console.Write("incomodam ");
                        incomoda += 1;
                    }                    
                    
                    Console.WriteLine("muito mais");
                    elefantesAtuais += 1;
                }
            }
        }
    }
}