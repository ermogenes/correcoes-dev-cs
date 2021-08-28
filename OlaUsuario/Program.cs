using System;

namespace OlaUsuario
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomeUsuario;
            Console.Write("Digite seu nome: ");
            nomeUsuario = Console.ReadLine();

            Console.WriteLine($"Olá, {nomeUsuario}!");
        }
    }
}
