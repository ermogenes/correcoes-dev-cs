Console.WriteLine("--- No Thanks ---\n");

int[] sequencia = new int[10];

int posicaoAtual = 0;
while (posicaoAtual < 10)
{
    Console.Write($"{posicaoAtual + 1}º número (-1 para finalizar): ");
    int proximoNumero = Convert.ToInt32(Console.ReadLine());

    if (proximoNumero == -1)
    {
        sequencia[posicaoAtual] = proximoNumero;
        break;
    }

    if (proximoNumero < 3 || proximoNumero > 35)
    {
        Console.WriteLine("Somente números únicos entre 3 e 35.");
        continue;
    }

    if (ExisteNaSequencia(proximoNumero, sequencia))
    {
        Console.Write("Número já está na sequência. Entradas: ");
        ExibeSequencia(sequencia);
        Console.WriteLine();
        continue;
    }

    sequencia[posicaoAtual] = proximoNumero;
    posicaoAtual++;
}

Array.Sort(sequencia);

Console.Write("\nSequência: ");
ExibeSequencia(sequencia);

int pontosNaSequencia = PontuacaoSequenciaOrdenada(sequencia);
Console.WriteLine($"\nPontos na sequência = {pontosNaSequencia}");

void ExibeSequencia(int[] sequencia)
{
    foreach (int numero in sequencia)
    {
        if (numero != -1 && numero != 0) Console.Write($"{numero} ");
    }
}

bool ExisteNaSequencia(int numeroProcurado, int[] sequencia)
{
    bool encontrado = false;
    foreach (int numero in sequencia)
    {
        if (numero == -1 || numero == 0) break;

        if (numero == numeroProcurado)
        {
            encontrado = true;
            break;
        }
    }
    return encontrado;
}

int PontuacaoSequenciaOrdenada(int[] sequenciaOrdenada)
{
    int pontos = 0;
    int anterior = 0;
    foreach (int atual in sequenciaOrdenada)
    {
        if (atual == -1 || atual == 0) continue;
        if (atual - anterior > 1) pontos += atual;
        anterior = atual;
    }
    return pontos;
}
