Console.Write("Quantos patinhos? ");
int quantidade = Convert.ToInt32(Console.ReadLine());

if (quantidade >= 2)
{
    int patinhosAtuais = quantidade;

    while (patinhosAtuais >= 1)
    {
        if (patinhosAtuais > 1)
        {
            Console.WriteLine($"\n{patinhosAtuais} patinhos foram passear");
        }
        else
        {
            Console.WriteLine($"\n{patinhosAtuais} patinho foi passear");
        }

        Console.WriteLine("Além das montanhas");
        Console.WriteLine("Para brincar");
        Console.WriteLine("A mamãe gritou: Quá, quá, quá, quá");

        patinhosAtuais = patinhosAtuais - 1;

        if (patinhosAtuais == 0)
        {
            Console.WriteLine($"Mas nenhum patinho voltou de lá.");
        }
        else if (patinhosAtuais == 1)
        {
            Console.WriteLine($"Mas só {patinhosAtuais} patinho voltou de lá.");
        }
        else
        {
            Console.WriteLine($"Mas só {patinhosAtuais} patinhos voltaram de lá.");
        }
    }

    Console.WriteLine("\nA mamãe patinha foi procurar");
    Console.WriteLine("Além das montanhas");
    Console.WriteLine("Na beira do mar");
    Console.WriteLine("A mamãe gritou: Quá, quá, quá, quá");
    Console.WriteLine($"E os {quantidade} patinhos voltaram de lá.");
}
else
{
    Console.WriteLine("São necessários 2 ou mais patinhos.");
}
