using System.Security.Cryptography;

Console.Clear();
Console.WriteLine("--- 36 vs. CPU ---\n");

// 50% chances da CPU começar
bool ehTurnoCPU = RandomNumberGenerator.GetInt32(0, 2) == 1;

Console.WriteLine($"Sorteando o jogador inicial... {DescricaoJogador(ehTurnoCPU)}.\n");

int pontosCPU = 0, pontosHumano = 0;
while (true)
{
    string jogador = DescricaoJogador(ehTurnoCPU);
    string adversario = DescricaoJogador(!ehTurnoCPU);
    int pontos = ehTurnoCPU ? pontosCPU : pontosHumano;

    Console.ForegroundColor = ehTurnoCPU ? ConsoleColor.Red : ConsoleColor.Blue;

    Console.WriteLine($"--- {jogador} ---");
    Console.WriteLine($"Pontos = {pontos}");

    Console.Write($"Dados: ");
    int dados;
    if (ehTurnoCPU)
    {
        dados = DecideDadosCPU(pontos);
        Console.WriteLine(dados);
    }
    else
    {
        dados = EntraDadosHumano();
    }

    pontos += SomaRolagemDados(dados);

    Console.WriteLine($"\nPontos = {pontos}");
    Console.WriteLine();

    Console.ResetColor();

    if (pontos == 36)
    {
        Console.WriteLine($"{jogador} VENCEU!");
        break;
    }
    else if (pontos > 36)
    {
        Console.WriteLine($"{adversario} VENCEU!");
        break;
    }

    if (ehTurnoCPU)
    {
        pontosCPU = pontos;
    }
    else
    {
        pontosHumano = pontos;
    }

    ehTurnoCPU = !ehTurnoCPU;
}

string DescricaoJogador(bool ehCPU)
{
    return ehCPU ? "CPU" : "HUMANO";
}

int DecideDadosCPU(int pontosAtuais)
{
    if (pontosAtuais <= 20) return 3;
    if (pontosAtuais <= 27) return 2;
    return 1;
}

int EntraDadosHumano()
{
    int dados = 0;
    while (dados < 1 || dados > 3)
    {
        dados = Convert.ToInt32(Console.ReadLine());
    }
    return dados;
}

int SomaRolagemDados(int dados)
{
    int soma = 0;
    for (int i = 1; i <= dados; i++)
    {
        int dado = RandomNumberGenerator.GetInt32(1, 7);
        Console.Write($"{dado} ");
        soma += dado;
    }
    return soma;
}
