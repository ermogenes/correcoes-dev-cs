using System.Security.Cryptography;

const int DezenasPorJogada = 6;
const int MaxValorSorteio = 60;

Console.WriteLine("--- Surpresinha ---\n");

Console.Write("Quantas jogadas? ");
int numeroJogadas = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

// Inicia uma lista de jogadas, sem nenhuma jogada
int[][] jogadas = new int[numeroJogadas][];

// Laço para as jogadas
for (int jogadaAtual = 0; jogadaAtual < numeroJogadas; jogadaAtual++)
{
    // Inicia uma jogada com 6 dezenas
    int[] dezenasJogadaAtual = new int[DezenasPorJogada];

    // Laço para as dezenas na jogada
    int dezenaAtual = 0;
    while (dezenaAtual < DezenasPorJogada)
    {
        // Sorteia uma dezena
        int dezenaSorteada = RandomNumberGenerator.GetInt32(1, MaxValorSorteio + 1);
        dezenasJogadaAtual[dezenaAtual] = dezenaSorteada;

        // Verifica se dezena já foi sorteada
        bool dezenaRepetida = false;
        for (int dezenaAnterior = 0; dezenaAnterior < dezenaAtual; dezenaAnterior++)
        {
            if (dezenasJogadaAtual[dezenaAnterior] == dezenaSorteada)
            {
                dezenaRepetida = true;
                break;
            }
        }

        // Resorteia dezena se foi duplicada
        if (dezenaRepetida) continue;

        // Segue para sorteio da próxima dezena
        dezenaAtual++;
    }

    // Ordena dezenas sorteadas em ordem crescente
    Array.Sort(dezenasJogadaAtual);

    // Grava a jogada
    jogadas[jogadaAtual] = dezenasJogadaAtual;
}

// Exibe as jogadas com suas dezenas
for (int jogada = 0; jogada < numeroJogadas; jogada++)
{
    for (int dezena = 0; dezena < DezenasPorJogada; dezena++)
    {
        Console.Write($"{jogadas[jogada][dezena].ToString("D2")}");
        if (dezena < 5) Console.Write($" - ");
    }
    Console.WriteLine();
}
