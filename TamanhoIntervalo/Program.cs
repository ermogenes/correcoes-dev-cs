Console.WriteLine("--- Tamanho do Intervalo ---\n");

Console.Write($"Quantos números? ");
int qtdNumeros = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

int max = 0, min = 0;

int i = 0;
do
{
    Console.Write($"Digite o {i + 1}º número: ");
    int numero = Convert.ToInt32(Console.ReadLine());

    if (i == 0)
    {
        min = numero;
        max = numero;
    }

    min = numero < min ? numero : min;
    max = numero > max ? numero : max;

    i++;
} while (i < qtdNumeros);

int tamanhoIntervalo = max - min;

Console.WriteLine($"\nO tamanho do intervalo entre {min} e {max} é {tamanhoIntervalo}.");
