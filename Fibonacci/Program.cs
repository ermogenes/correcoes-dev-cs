Console.WriteLine("Sequência de Fibonacci");

Console.Write("Quantos termos (>=2)? ");
int numeroTermos = Convert.ToInt32(Console.ReadLine());

if (numeroTermos < 2 || numeroTermos > 47)
{
    Console.WriteLine("Digite um número entre 2 e 47.");
}
else
{
    int anterior = 0;
    int atual = 1;
    Console.Write($"{anterior} {atual} ");

    int i = 3;
    while (i <= numeroTermos)
    {
        int termo = atual + anterior;
        Console.Write($"{termo} ");

        anterior = atual;
        atual = termo;

        i += 1;
    }
}
