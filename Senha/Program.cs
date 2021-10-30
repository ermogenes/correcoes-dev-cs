using System;

namespace Senha
{
    class Program
    {
        static void Main(string[] args)
        {
            const string SenhaCorreta = "1234abcd";
            string senha, permissaoAcesso;

            Console.Write("Olá, usuário. Por favor, digite sua senha: ");
            senha = Console.ReadLine();

            permissaoAcesso = senha == SenhaCorreta ? "permitido" : "negado";

            Console.WriteLine($"Acesso { permissaoAcesso }");
        }
    }
}
