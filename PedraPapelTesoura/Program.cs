using System.Security.Cryptography;

Console.WriteLine("--- Pedra, Papel e Tesoura ---\n");
Console.WriteLine("Pedra = 0, Papel = 1, Tesoura = 2\n");

string[,] mensagens = {
    {"Houve um empate.","A pedra é coberta pelo papel.","A pedra quebra a tesoura."},
    {"O papel cobre a pedra.","Houve um empate.","O papel é cortado pela tesoura."},
    {"A tesoura é quebrada pela pedra.","A tesoura corta o papel.","Houve um empate."},
};

int[,] resultado = {
    {0, -1, 1},
    {1, 0, -1},
    {-1, 1, 0},
};

const int Pedra = 0;

string[] opcoes = { "Pedra", "Papel", "Tesoura" };

const int MaosParaVencer = 5;

int vitoriasJogador = 0, vitoriasCPU = 0;

int jogadaHumano = -1, jogadaCPU = -1;
int jogadaAnteriorHumano, jogadaAnteriorCPU;

string mensagemResultado = "";
ConsoleColor corResultado = ConsoleColor.White;

while (vitoriasJogador < MaosParaVencer && vitoriasCPU < MaosParaVencer)
{
    jogadaAnteriorHumano = jogadaHumano;
    jogadaAnteriorCPU = jogadaCPU;

    // Jogada do Humano
    Console.Write("Sua mão: ");
    string entrada = Console.ReadLine()!.Trim();

    // Jogada inválida?
    if (entrada != "0" && entrada != "1" && entrada != "2")
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Pedra = 0, Papel = 1, Tesoura = 2");
        Console.ResetColor();

        jogadaHumano = jogadaAnteriorHumano;
        continue;
    }
    jogadaHumano = Convert.ToInt32(entrada);

    // Jogou pedra duas vezes seguidas?
    if (jogadaHumano == Pedra && jogadaAnteriorHumano == Pedra)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Não pode jogar pedra duas vezes seguidas.");
        Console.ResetColor();

        continue;
    }

    // Jogada da CPU (IA)
    jogadaCPU = EscolherJogadaCPU(jogadaAnteriorCPU != Pedra);

    // Atualização do placar ("estado atual do jogo")
    if (resultado[jogadaHumano, jogadaCPU] == 1)
    {
        corResultado = ConsoleColor.Green;
        mensagemResultado = "Você venceu!";
        vitoriasJogador++;
    }
    else if (resultado[jogadaHumano, jogadaCPU] == -1)
    {
        corResultado = ConsoleColor.Red;
        mensagemResultado = "Você perdeu...";
        vitoriasCPU++;
    }
    else
    {
        corResultado = ConsoleColor.White;
        mensagemResultado = "";
    }

    // Atualiza interface ("gráfico do jogo")
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"Humano => {opcoes[jogadaHumano]}");

    Console.ResetColor();
    Console.Write(", ");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\tCPU => {opcoes[jogadaCPU]}");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(mensagens[jogadaHumano, jogadaCPU]);

    Console.ForegroundColor = corResultado;
    Console.WriteLine($" {mensagemResultado}");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"Humano  = {vitoriasJogador}");

    Console.ResetColor();
    Console.Write(", ");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\t\tCPU  = {vitoriasCPU}");

    Console.ResetColor();
    Console.WriteLine();
}

// Game Over

// Exibe interface de resultado final
if (vitoriasJogador == MaosParaVencer)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Você venceu a partida. Parabéns!");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Você perdeu para a CPU. Se esforce mais na próxima vez...");
}

Console.ResetColor();

int EscolherJogadaCPU(bool permitirPedra)
{
    if (permitirPedra) return RandomNumberGenerator.GetInt32(0, 3);
    return RandomNumberGenerator.GetInt32(1, 3);
}
