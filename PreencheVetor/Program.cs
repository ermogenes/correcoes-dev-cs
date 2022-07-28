Console.WriteLine("--- Preenche Vetor ---\n");

Console.Write("Digite um número: ");
int n = Convert.ToInt32(Console.ReadLine());

int[] vetor = new int[100];

int valorAtual = n % 2 == 0 ? n : n + 1;

for (int i = 0; i < vetor.Length; i++)
{
    vetor[i] = valorAtual;
    valorAtual += 2;
}

Console.WriteLine();

for (int i = 0; i < 5; i++)
{
    Console.Write($"{vetor[i]} ");
}

Console.Write("(...) ");

for (int i = vetor.Length - 5; i < vetor.Length; i++)
{
    Console.Write($"{vetor[i]} ");
}
