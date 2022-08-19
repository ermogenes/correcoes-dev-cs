using Figgle;
using System.Security.Cryptography;

UI.Inicio();

// Obtém parâmetros para o início do jogo
int qtdBots = UI.SelecaoNumeroJogadores() - 1;
string nomeHumano = UI.SelecaoNomeJogador();

// Prepara o início do jogo (setup)
var jogo = new Jogo(nomeHumano, qtdBots);

UI.JogadorQueDaraAsCartas(jogo);
UI.Destaque("As cartas foram dadas e os pares baixados. Ficou assim:");
UI.SituacaoAtual(jogo);
UI.Destaque("Começou!");

// O Jogo segue até que não possam se formar mais pares
while (jogo.EmAndamento)
{
    if (jogo.JogadorAEsquerda.PossuiCartasNaMao)
    {
        // Humano escolhe uma, bot sorteia uma
        int posicaoCartaEscolhida = jogo.JogadorDaVez.Bot
            ? Bot.EscolherCarta(jogo.JogadorAEsquerda)
            : UI.SelecaoDeCarta(jogo);

        Carta carta = jogo.JogadorAEsquerda.MaoDeCartas[posicaoCartaEscolhida];

        // Pega a carta e baixa par, se existir
        jogo.JogadorAEsquerda.EntregarCarta(carta);
        jogo.JogadorDaVez.ReceberCarta(carta);
        bool algumParBaixado = jogo.JogadorDaVez.BaixarPares();

        if (algumParBaixado)
            UI.CartaBaixada(jogo.JogadorDaVez, carta);
        else
            UI.NaoBaixada(jogo.JogadorDaVez, carta);
    }
    else
        UI.NaoHaCartas(jogo.JogadorDaVez);

    // Seleciona o próximo jogador
    jogo.SelecionarProximoJogador();
}

UI.FimDeJogo(jogo);

class Jogo
{
    public BaralhoSolteirona Baralho { get; } = new BaralhoSolteirona();
    public List<Jogador> Jogadores { get; } = new();
    public int QtdJogadores { get; }
    public Jogador JogadorHumano { get; private set; } = default!;
    public Jogador JogadorQueDaAsCartas { get => Jogadores.Single(j => j.Ordem == 0); }
    public Jogador JogadorDaVez { get; private set; } = default!;
    public Jogador JogadorAEsquerda
    {
        get
        {
            int anterior = (JogadorDaVez.Ordem > 0 ? JogadorDaVez.Ordem : QtdJogadores);
            int ordemJogadorAEsquerda = anterior - 1;

            return Jogadores.Single(j => j.Ordem == ordemJogadorAEsquerda);
        }
    }
    public Jogador Perdedor { get => Jogadores.SingleOrDefault(j => !EmAndamento && j.QtdCartasNaMao == 1)!; }
    public bool EmAndamento { get => Jogadores.Where(j => j.PossuiCartasNaMao).Count() != 1; }
    public Jogo(string nomeHumano, int qtdBots)
    {
        QtdJogadores = 1 + qtdBots;

        // Adiciona humano
        JogadorHumano = new Jogador(0, nomeHumano);
        Jogadores.Add(JogadorHumano);

        // Adiciona os bots
        for (int id = 1; id <= qtdBots; id++)
            Jogadores.Add(new Jogador(id, bot: true));

        SortearSequenciaDeJogadores();
        DarAsCartas();
        BaixarParesIniciais();
    }
    private void SortearSequenciaDeJogadores()
    {
        int posicaoPrimeiroJogador = Engine.SortearNumero(QtdJogadores);

        for (int i = 0; i < QtdJogadores; i++)
        {
            Jogadores[i].Ordem = (posicaoPrimeiroJogador + i) % QtdJogadores;
            if (Jogadores[i].Ordem == 1) JogadorDaVez = Jogadores[i];
        }
    }
    public void DarAsCartas()
    {
        int qtdCartasDistribuidas = 0;
        while (Baralho.PossuiCartas)
        {
            int posicao = qtdCartasDistribuidas % QtdJogadores;

            var jogador = Jogadores.Single(j => j.Ordem == posicao);
            jogador.ReceberCarta(Baralho.RetirarCartaDoTopo());

            qtdCartasDistribuidas++;
        }
    }
    private void BaixarParesIniciais()
    {
        foreach (var jogador in Jogadores)
            jogador.BaixarPares();
    }
    public void SelecionarProximoJogador()
    {
        int proximo = JogadorDaVez.Ordem + 1;
        int ordemProximoJogador = proximo == QtdJogadores ? 0 : proximo;

        JogadorDaVez = Jogadores.Single(j => j.Ordem == ordemProximoJogador);
    }
}

class Engine
{
    public static string GerarNomeAleatorio()
    {
        string[] nomes =
        {
            "Maria",
            "Ana",
            "Vitória",
            "Julia",
            "Letícia",
            "Amanda",
            "Beatriz",
            "Larissa",
            "Gabriela",
            "Mariana",
            "João",
            "Gabriel",
            "Lucas",
            "Pedro",
            "Mateus",
            "José",
            "Gustavo",
            "Guilherme",
            "Carlos",
            "Vitor",
        };

        string[] sobrenomes = {
            "Almeida",
            "Alves",
            "Andrade",
            "Barbosa",
            "Barros",
            "Batista",
            "Borges",
            "Campos",
            "Cardoso",
            "Carvalho",
            "Castro",
            "Costa",
            "Dias",
            "Duarte",
            "Freitas",
            "Fernandes",
            "Ferreira",
            "Garcia",
            "Gomes",
            "Gonçalves",
            "Lima",
            "Lopes",
            "Machado",
            "Marques",
            "Martins",
            "Medeiros",
            "Melo",
            "Mendes",
            "Miranda",
            "Monteiro",
            "Moraes",
            "Moreira",
            "Moura",
            "Nascimento",
            "Nunes",
            "Oliveira",
            "Pereira",
            "Ramos",
            "Reis",
            "Ribeiro",
            "Rocha",
            "Santana",
            "Santos",
            "Silva",
            "Soares",
            "Souza",
            "Teixeira",
            "Vieira",
        };

        string nome = nomes[SortearNumero(nomes.Length)];
        string sobrenome = sobrenomes[SortearNumero(sobrenomes.Length)];

        return $"{nome} {sobrenome}";
    }
    public static int SortearNumero(int menorQue) => RandomNumberGenerator.GetInt32(0, menorQue);
    public static int SortearNumero(int minimo, int menorQue) => RandomNumberGenerator.GetInt32(minimo, menorQue);
}

class Bot
{
    public static int EscolherCarta(Jogador jogador) => Engine.SortearNumero(jogador.QtdCartasNaMao);
}

class UI
{
    private static void SomInicio()
    {
        Console.Beep(1650, 180);
        Console.Beep(1759, 180);
        Console.Beep(1980, 180);
        Thread.Sleep(300);
        Console.Beep(1320, 180);
        Console.Beep(1485, 180);
        Thread.Sleep(300);
    }
    private static void SomVitoria()
    {
        Console.Beep(1980, 180);
        Console.Beep(2200, 180);
        Console.Beep(1650, 180);
        Thread.Sleep(300);
        Console.Beep(1320, 180);
        Console.Beep(1485, 580);
        Console.Beep(1485, 180);
        Console.Beep(1485, 180);
        Thread.Sleep(300);
    }
    private static void SomDerrota()
    {
        Console.Beep(1650, 180);
        Console.Beep(2200, 180);
        Console.Beep(1980, 180);
        Thread.Sleep(300);
        Console.Beep(1320, 180);
        Console.Beep(1320, 580);
        Console.Beep(1980, 180);
        Console.Beep(1485, 180);
        Thread.Sleep(300);
    }
    private static void SomCartaBaixada()
    {
        Console.Beep(1650, 180);
        Console.Beep(2200, 180);
        Thread.Sleep(300);
    }
    private static void SomCartaNaoBaixada()
    {
        Console.Beep(2200, 180);
        Console.Beep(1650, 180);
        Thread.Sleep(300);
    }
    private static void SomNaoHaCartas()
    {
        Console.Beep(1759, 180);
        Console.Beep(1759, 180);
        Thread.Sleep(300);
    }
    public static void Inicio()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(FiggleFonts.Crazy.Render("Solteirona"));
        Console.ResetColor();
        SomInicio();
    }
    public static void JogadorQueDaraAsCartas(Jogo jogo)
    {
        Console.WriteLine($"{jogo.JogadorQueDaAsCartas.Nome} dará as cartas.");
    }
    public static void Destaque(string titulo)
    {
        Console.WriteLine($"\n_.~\"~._.~\"~._.~\"~._.~\"~._ {titulo} _.~\"~._.~\"~._.~\"~._.~\"~._\n");
    }
    public static void FimDeJogo(Jogo jogo)
    {
        UI.Destaque("Fim de Jogo");
        UI.SituacaoAtual(jogo);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Destaque(jogo.Perdedor.Bot ? "Você venceu." : "Tente novamente.");

        var cor = jogo.Perdedor.Bot
            ? ConsoleColor.Green
            : ConsoleColor.Red;

        Console.ForegroundColor = cor;
        Console.WriteLine(FiggleFonts.Cricket.Render(jogo.Perdedor.NomeSemAcentuacao));
        Console.Write("ficou com a Solteirona ");
        Carta(jogo.Perdedor.MaoDeCartas.Single());
        Console.ForegroundColor = cor;
        Console.WriteLine(" e perdeu o jogo.");
        Console.ResetColor();

        if (jogo.Perdedor.Bot)
            SomVitoria();
        else
            SomDerrota();
    }
    private static void Carta(Carta carta)
    {
        Console.ForegroundColor = carta.Cor switch
        {
            "vermelho" => ConsoleColor.Red,
            "preto" => ConsoleColor.Black,
            _ => ConsoleColor.Yellow,
        };
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write($" {carta} ");
        Console.ResetColor();
    }
    public static void SituacaoAtual(Jogo jogo)
    {
        foreach (var j in jogo.Jogadores.OrderBy(j => j.Ordem))
        {
            Console.ForegroundColor = j.Bot ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"{j.ToString().PadRight(25, ' ')} [na mão = {j.QtdCartasNaMao}]");
            Console.ResetColor();

            Console.Write(" Mesa: ");
            ParesDeCartas(j.ParesBaixados.OrderBy(p => p.Carta1.Valor).ToList());
            Console.WriteLine();
        }

        Console.Write($"\nSua mão: ");
        foreach (var c in jogo.JogadorHumano.MaoDeCartas.OrderBy(c => c.Valor))
        {
            Console.Write($" ");
            Carta(c);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
    private static void ParDeCartas(ParDeCartas par)
    {
        Carta(par.Carta1);
        Console.Write("+");
        Carta(par.Carta2);
    }
    private static void ParesDeCartas(List<ParDeCartas> pares)
    {
        foreach (var par in pares)
        {
            Console.Write("(");
            ParDeCartas(par);
            Console.Write(") ");
        }
    }
    public static void CartaBaixada(Jogador jogador, Carta carta)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"\t{jogador,30} pegou e baixou a carta  ");
        Carta(carta);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($" [na mão = {jogador.QtdCartasNaMao}]");
        Console.WriteLine();
        Console.ResetColor();
        SomCartaBaixada();
    }
    public static void NaoBaixada(Jogador jogador, Carta carta)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"\t{jogador,30} pegou e manteve a carta ");
        Carta(carta);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" [na mão = {jogador.QtdCartasNaMao}]");
        Console.WriteLine();
        Console.ResetColor();
        SomCartaNaoBaixada();
    }
    public static void NaoHaCartas(Jogador jogador)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"\t{jogador,30} não teve cartas para pegar   ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($" [na mão = {jogador.QtdCartasNaMao}]");
        Console.WriteLine();
        Console.ResetColor();
        SomNaoHaCartas();
    }
    public static int SelecaoDeCarta(Jogo jogo)
    {
        Destaque("É a sua vez");
        SituacaoAtual(jogo);
        Console.WriteLine();

        int qtdCartasPossiveis = jogo.JogadorAEsquerda.QtdCartasNaMao;
        int cartaEscolhida;
        string valorDigitado;
        bool valido = false;
        do
        {
            Console.Write($"Qual carta quer pegar (1 a {qtdCartasPossiveis}, ENTER para aleatória)? ");
            valorDigitado = Console.ReadLine()?.Trim() ?? "";

            if (String.IsNullOrEmpty(valorDigitado))
            {
                valorDigitado = Engine.SortearNumero(1, qtdCartasPossiveis + 1).ToString();
                Console.WriteLine($"\tSorteada a carta {valorDigitado}");
            }

            valido = Int32.TryParse(valorDigitado, out cartaEscolhida)
                        && cartaEscolhida > 0
                        && cartaEscolhida <= qtdCartasPossiveis;

        } while (!valido);
        Console.WriteLine();

        return cartaEscolhida - 1;
    }
    public static string SelecaoNomeJogador()
    {
        string nome;
        Console.Write($"Qual seu nome (ENTER para aleatório)? ");
        nome = Console.ReadLine()?.Trim() ?? "";

        if (String.IsNullOrEmpty(nome))
        {
            nome = Engine.GerarNomeAleatorio();
            Console.WriteLine($"\tSeu nome é {nome}");
        }
        Console.WriteLine();

        return nome;
    }
    public static int SelecaoNumeroJogadores()
    {
        const int MaxJogadores = 12;
        int qtdEscolhida;
        string valorDigitado;
        bool valido = false;
        do
        {
            Console.Write($"Quantos jogadores (2 a {MaxJogadores}, ENTER para aleatório)? ");
            valorDigitado = Console.ReadLine()?.Trim() ?? "";

            if (String.IsNullOrEmpty(valorDigitado))
            {
                valorDigitado = Engine.SortearNumero(2, MaxJogadores + 1).ToString();
                Console.WriteLine($"\tSorteado {valorDigitado} jogadores");
            }

            valido = Int32.TryParse(valorDigitado, out qtdEscolhida)
                        && qtdEscolhida > 1
                        && qtdEscolhida <= MaxJogadores;

        } while (!valido);
        Console.WriteLine();

        return qtdEscolhida;
    }
}

class BaralhoSolteirona : BaralhoPadrao
{
    private Carta _rainhaExcluida;
    public BaralhoSolteirona()
    {
        _rainhaExcluida = RetirarCartaAleatoria();
        Embaralhar();
    }
}

class BaralhoPadrao
{
    private List<string> _naipesValidos = "♣=0,♥=0,♠=0,♦=0".Split(",").ToList();
    private List<string> _numerosValidos = "A=1,2=2,3=3,4=4,5=5,6=6,7=7,8=8,9=9,10=10,J=11,Q=12,K=13".Split(",").ToList();
    public Stack<Carta> Cartas { get; private set; } = new();
    public int QtdCartasRestantes { get => Cartas.Count(); }
    public bool PossuiCartas { get => QtdCartasRestantes > 0; }
    public BaralhoPadrao()
    {
        foreach (var naipe in _naipesValidos)
            foreach (var numero in _numerosValidos)
            {
                var dadosNumero = numero.Split("=");
                var dadosNaipe = naipe.Split("=");
                int valorCarta = Int32.Parse(dadosNumero[1]) + Int32.Parse(dadosNaipe[1]);
                Cartas.Push(new Carta(dadosNumero[0], dadosNaipe[0], valorCarta));
            }
    }
    public Carta RetirarCartaAleatoria()
    {
        var rainhas = Cartas.Where(c => c.Numero == "Q").ToList();
        var rainhaSorteada = rainhas.ElementAt(Engine.SortearNumero(rainhas.Count));

        var cartasQuePermanecem = Cartas.ToList();
        cartasQuePermanecem.Remove(rainhaSorteada);

        Cartas = new(cartasQuePermanecem);

        return rainhaSorteada;
    }
    public void Embaralhar()
    {
        List<Carta> baralhoAtual = Cartas.ToList();
        Stack<Carta> cartasEmbaralhadas = new();

        while (baralhoAtual.Count() > 0)
        {
            int posicao = Engine.SortearNumero(baralhoAtual.Count());
            cartasEmbaralhadas.Push(baralhoAtual.ElementAt(posicao));
            baralhoAtual.RemoveAt(posicao);
        }

        Cartas = cartasEmbaralhadas;
    }
    public Carta RetirarCartaDoTopo() => Cartas.Pop();
}

class Carta
{
    private List<string> _naipesValidos = "♣,♥,♠,♦".Split(",").ToList();
    private List<string> _numerosValidos = "A,2,3,4,5,6,7,8,9,10,J,Q,K".Split(",").ToList();
    public string Numero { get; }
    public string Naipe { get; }
    public int Valor { get; }
    public string Face { get => $"{Numero}{Naipe}"; }
    public string Cor
    {
        get => Naipe switch
        {
            "♥" => "vermelho",
            "♦" => "vermelho",
            "♣" => "preto",
            "♠" => "preto",
            _ => "",
        };
    }
    public Carta(string numero, string naipe, int valor)
    {
        numero = numero.ToUpper();
        if (!_numerosValidos.Contains(numero))
            throw new ArgumentException("Número inválido");

        naipe = naipe.ToUpper();
        if (!_naipesValidos.Contains(naipe))
            throw new ArgumentException("Naipe inválido");

        Numero = numero;
        Naipe = naipe;
        Valor = valor;
    }
    public override string ToString() => Face.PadLeft(3);
}

record ParDeCartas(Carta Carta1, Carta Carta2);

class Jogador
{
    public bool Bot { get; }
    public int Id { get; }
    public string Nome { get; }
    public string NomeSemAcentuacao
    {
        get => Nome
            .Replace("á", "a")
            .Replace("à", "a")
            .Replace("ã", "a")
            .Replace("â", "a")
            .Replace("é", "e")
            .Replace("ê", "e")
            .Replace("í", "i")
            .Replace("ó", "o")
            .Replace("õ", "o")
            .Replace("ô", "o")
            .Replace("ú", "u")
            .Replace("û", "u")
            .Replace("ç", "c");
    }
    public int Ordem { get; set; }
    public List<Carta> MaoDeCartas { get; } = new();
    public int QtdCartasNaMao { get => MaoDeCartas.Count(); }
    public bool PossuiCartasNaMao { get => QtdCartasNaMao > 0; }
    public List<ParDeCartas> ParesBaixados { get; } = new();
    public int QtdParesBaixados { get => ParesBaixados.Count(); }
    public Jogador(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Bot = false;
    }
    public Jogador(int id, bool bot)
    {
        Id = id;
        Nome = EscolherNomeAleatorio();
        Bot = bot;
    }
    private string EscolherNomeAleatorio() => Engine.GerarNomeAleatorio();
    private void BaixarPar(Carta carta1, Carta carta2)
    {
        ParesBaixados.Add(new ParDeCartas
        (
            Carta1: carta1,
            Carta2: carta2
        ));
        MaoDeCartas.Remove(carta1);
        MaoDeCartas.Remove(carta2);
    }
    public bool BaixarPares()
    {
        bool algumParBaixado = false;
        var gruposComUmParOuMais = MaoDeCartas
            .OrderBy(c => c.Valor)
            .GroupBy(c => c.Valor)
                .Where(g => g.Count() > 1);

        foreach (var grupoPorValor in gruposComUmParOuMais)
        {
            var cartasDeMesmoValor = MaoDeCartas
                .Where(c => c.Valor == grupoPorValor.Key);

            // Se possui dois pares, baixa as 2 últimas
            if (cartasDeMesmoValor.Count() == 4)
                BaixarPar(cartasDeMesmoValor.ElementAt(2), cartasDeMesmoValor.ElementAt(3));

            // Baixa as duas primeiras
            BaixarPar(cartasDeMesmoValor.ElementAt(0), cartasDeMesmoValor.ElementAt(1));

            algumParBaixado = true;
        }
        return algumParBaixado;
    }
    public void EntregarCarta(Carta carta) => MaoDeCartas.Remove(carta);
    public void ReceberCarta(Carta carta) => MaoDeCartas.Add(carta);
    public override string ToString() => $"{Nome} #{Ordem}";
}
