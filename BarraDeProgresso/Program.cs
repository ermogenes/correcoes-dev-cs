using System.Security.Cryptography;

Console.WriteLine("--- Cópia de Arquivo ---\n");

Console.Write("Tamanho (em bytes)...: ");
int tamanho = Convert.ToInt32(Console.ReadLine());

int loteMinimo = Convert.ToInt32(tamanho * 0.02);
int loteMaximo = Convert.ToInt32(tamanho * 0.1);

int tempoMinimo = 100;
int tempoMaximo = 2000;

int transmitidos = 0;
int tempoDecorrido = 0;

int blocosExibidos = 0;

Console.WriteLine("\n...10...20...30...40...50...60...70...80...90..100");

while (transmitidos < tamanho)
{
    int restante = tamanho - transmitidos;
    int lote = RandomNumberGenerator.GetInt32(loteMinimo, loteMaximo);
    if (lote > restante) lote = restante;

    int tempo = RandomNumberGenerator.GetInt32(tempoMinimo, tempoMaximo);
    Thread.Sleep(tempo);

    tempoDecorrido += tempo;
    transmitidos += lote;

    double percentual = Convert.ToDouble(transmitidos) / Convert.ToDouble(tamanho);
    int blocoAtual = Convert.ToInt32(percentual * 50);

    int blocosAExibir = blocoAtual - blocosExibidos;
    for (int c = 0; c < blocosAExibir; c++)
    {
        Console.Write("*");
    }
    blocosExibidos = blocoAtual;
}

double tempoSegundos = tempoDecorrido / 1000;
double taxa = (double)transmitidos / (double)tempoSegundos;

Console.WriteLine($"\n\nTaxa = {taxa:N2}bps");
Console.WriteLine($"Tempo = {tempoSegundos}s");
