using System.Security.Cryptography;

Console.WriteLine("--- Genius ---\n");

Console.Write("Escolha o nível de dificuldade (1 a 4)...: ");
int dificuldade;
if (!Int32.TryParse(Console.ReadLine(), out dificuldade) || dificuldade < 1 || dificuldade > 4) return;
Console.WriteLine();

Console.CursorVisible = false;

var jogo = new Genius(dificuldade);

bool errou = false;
for (int rodada = 0; rodada < jogo.TamanhoSequencia; rodada++)
{
    // Exibe a sequência a ser repetida
    for (int i = 0; i <= rodada; i++)
        UI.AtivaBotao(jogo.SequenciaSorteada[i], i, rodada);

    // Lê a sequência informada pelo usuário
    List<Botao> sequenciaEntrada = new();
    for (int i = 0; i <= rodada; i++)
    {
        var botaoEntrada = UI.AguardaPressionamentoBotao(jogo);
        if (botaoEntrada != jogo.SequenciaSorteada[i])
        {
            errou = true;
            break;
        }
    }

    // Se errou, sai do jogo
    if (errou) break;

    // Aguarda e continua
    UI.Pausa(800);
}

if (errou)
{
    Console.WriteLine($"Errou! Tente novamente.");
    UI.SomDerrota();
}
else
{
    Console.WriteLine($"Você venceu na dificuldade {jogo.Dificuldade}.");
    UI.SomVitoria(jogo);
}

Console.CursorVisible = true;

class UI
{
    public static void Pausa(int milis)
    {
        Thread.Sleep(milis);
    }

    public static void AtivaBotao(Botao botao, int posicao = 1, int tamanho = 1)
    {
        // Reduz o tempo de exibição conforme a sequência aumenta de tamanho
        int tempo = 1000; // 420;
        if (posicao < tamanho)
        {
            if (tamanho > 5 && tamanho <= 13)
                tempo = 840; // 320;
            else if (tamanho > 13)
                tempo = 420; // 220;
        }

        var colunaInicial = Console.CursorLeft;
        Console.ResetColor();
        Console.BackgroundColor = (ConsoleColor)botao.Cor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($" {botao.Simbolo} ");
        Console.ResetColor();
        BeepBotao(botao, tempo);
        Console.SetCursorPosition(colunaInicial, Console.CursorTop);
        Console.Write($"   ");
        Console.SetCursorPosition(colunaInicial, Console.CursorTop);
    }

    public static void SomDerrota()
    {
        BeepErro(1500);
    }

    public static void SomVitoria(Genius jogo)
    {
        if (jogo.Dificuldade == 4)
        {
            for (int i = 1; i <= 3; i++)
            {
                BeepBotao(jogo.Botoes.Single(b => b.Cor == (int)ConsoleColor.Red), 200);
                BeepBotao(jogo.Botoes.Single(b => b.Cor == (int)ConsoleColor.Yellow), 200);
                BeepBotao(jogo.Botoes.Single(b => b.Cor == (int)ConsoleColor.Blue), 200);
                BeepBotao(jogo.Botoes.Single(b => b.Cor == (int)ConsoleColor.Green), 200);
            }
            BeepBotao(jogo.Botoes.Single(b => b.Cor == (int)ConsoleColor.Red), 200);
            BeepBotao(jogo.Botoes.Single(b => b.Cor == (int)ConsoleColor.Yellow), 200);
            BeepErro(800);
        }
        else
        {
            var ultimoBotao = jogo.SequenciaSorteada.Last();
            Pausa(800);
            BeepBotao(ultimoBotao, 200);
            for (int i = 1; i <= 5; i++)
            {
                BeepBotao(ultimoBotao, 700);
                Pausa(200);
            }
        }
    }

    private static void BeepErro(int milis)
    {
#pragma warning disable CA1416
        Console.Beep(42, milis);
#pragma warning restore CA1416
        Pausa(milis);
    }

    private static void BeepBotao(Botao botao, int milis)
    {
#pragma warning disable CA1416
        Console.Beep(botao.Frequencia, milis);
#pragma warning restore CA1416
    }

    public static Botao AguardaPressionamentoBotao(Genius jogo)
    {
        int teclaPressionada;
        while (true)
        {
            // Limpa o buffer do teclado
            while (Console.KeyAvailable) Console.ReadKey(true);

            // Por simplicidade, aguardamos indefinidamente (o Genius aguarda somente 3s)
            teclaPressionada = (int)Console.ReadKey(true).Key;

            var botaoPressionado = jogo.Botoes.FirstOrDefault(b => b.Tecla == teclaPressionada);
            if (botaoPressionado != null)
            {
                AtivaBotao(botaoPressionado);
                return botaoPressionado;
            }
        }
    }
}

class Genius
{
    public List<Botao> Botoes { get; }
    public int Dificuldade { get; }
    public int TamanhoSequencia { get => SequenciaSorteada.Count(); }
    public Genius(int dificuldade = 1)
    {
        Botoes = new List<Botao>
        {
            new Botao
            {
                Cor = (int)ConsoleColor.Red,
                Simbolo = "↑",
                Frequencia = 329,
                // Frequencia = 1975, // B6
                Tecla = (int)ConsoleKey.UpArrow,
            },
            new Botao
            {
                Cor = (int)ConsoleColor.Green,
                Simbolo = "<",
                Frequencia = 392,
                // Frequencia = 1661, // G#6
                Tecla = (int)ConsoleKey.LeftArrow,
            },
            new Botao
            {
                Cor = (int)ConsoleColor.Blue,
                Simbolo = ">",
                Frequencia = 196,
                // Frequencia = 3322, // G#7
                Tecla = (int)ConsoleKey.RightArrow,
            },
            new Botao
            {
                Cor = (int)ConsoleColor.Yellow,
                Simbolo = "↓",
                Frequencia = 261,
                // Frequencia = 2489, // D#7
                Tecla = (int)ConsoleKey.DownArrow,
            },
        };

        if (dificuldade < 1 || dificuldade > 4)
            throw new ArgumentException("Dificuldade inválida");

        Dificuldade = dificuldade;

        int tamanhoSequencia = dificuldade switch { 1 => 8, 2 => 14, 3 => 20, _ => 31 };

        for (int i = 0; i < tamanhoSequencia; i++)
            SequenciaSorteada.Add(Botoes[RandomNumberGenerator.GetInt32(0, 4)]);
    }
    public List<Botao> SequenciaSorteada { get; } = new();
}

class Botao
{
    public int Cor { get; set; } = default!;
    public string Simbolo { get; set; } = default!;
    public int Frequencia { get; set; } = default!;
    public int Tecla { get; set; } = default!;
}
