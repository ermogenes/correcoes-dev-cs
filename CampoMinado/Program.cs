using System.Security.Cryptography;

int tamanho = 10;
double dificuldade = 0.1;

do
{
    UI.ExibeTelaInicial();

    tamanho = UI.RecebeTamanho(padrao: tamanho);
    dificuldade = UI.RecebeDificuldade(padrao: dificuldade);

    var jogo = new CampoMinado(tamanho, dificuldade);
    var interfaceDoJogo = new UI(jogo);

    bool venceu = false;
    bool final = false;
    do
    {
        bool explodiu = false;

        interfaceDoJogo.ExibeNovaRodada();
        string acao = interfaceDoJogo.RecebeAcaoDesejada(padrao: UI.ACAO_ABRIR);

        if (acao == UI.ACAO_DESISTIR)
            final = true;
        else
        {
            int linha = interfaceDoJogo.RecebeLinha();
            int coluna = interfaceDoJogo.RecebeColuna();

            if (acao == UI.ACAO_ABRIR)
            {
                if (!jogo.PodeAbrir(linha, coluna))
                {
                    UI.ExibeMensagemErro($"Não é possível abrir o local ({linha}, {coluna}). Deve ser um local fechado não sinalizado.");
                    continue;
                }

                explodiu = jogo.AbreLocal(linha, coluna);
            }
            else if (acao == UI.ACAO_ABRIR_VARIOS)
            {
                if (!jogo.PodeAbrirLocaisVizinhos(linha, coluna))
                {
                    UI.ExibeMensagemErro($"Não é possível abrir os locais vizinhos a ({linha}, {coluna}). Deve ser um local com número não sinalizado.");
                    continue;
                }

                explodiu = jogo.AbreTodosLocaisVizinhos(linha, coluna);
            }
            else if (acao == UI.ACAO_SINALIZAR)
            {
                if (!jogo.PodeSinalizar(linha, coluna))
                {
                    UI.ExibeMensagemErro($"Não é possível sinalizar em ({linha}, {coluna}).");
                    continue;
                }

                jogo.InverteSinalizacao(linha, coluna);
            }
        }

        if (explodiu)
        {
            venceu = false;
            final = true;
        }

        if (jogo.SituacaoDeVitoria)
        {
            venceu = true;
            final = true;
        }
    }
    while (!final);

    interfaceDoJogo.ExibeResultado(terminouEmVitoria: venceu);

} while (!UI.DesejaSair());

class CampoMinado
{
    public const int VAZIO = 0;
    public const int MINA = -1;
    public int Tamanho { get; }
    public double Dificuldade { get; }
    public int RodadaAtual { get; private set; }
    public int NumeroDeMinas { get; }
    public int NumeroDeSinais
    {
        get
        {
            int quantidade = 0;
            foreach (var sinal in Sinalizado)
                if (sinal) quantidade++;
            return quantidade;
        }
    }
    public int[,] Campo { get; }
    public bool[,] Aberto { get; }
    public bool[,] Sinalizado { get; }
    public bool SituacaoDeVitoria
    {
        get
        {
            for (int linha = 0; linha < Tamanho; linha++)
                for (int coluna = 0; coluna < Tamanho; coluna++)
                    if (Campo[linha, coluna] != MINA
                        && PodeAbrir(linha, coluna)
                    ) return false;
            return true;
        }
    }
    public CampoMinado(int tamanho, double dificuldade)
    {
        if (tamanho < 3 || tamanho > 20)
            throw new ArgumentOutOfRangeException("Tamanho deve estar entre 3 e 20.");

        if (dificuldade < 0 || dificuldade > 1)
            throw new ArgumentOutOfRangeException("Dificuldade deve estar entre 0 e 1.");

        Tamanho = tamanho;
        Dificuldade = dificuldade;
        RodadaAtual = 1;
        int maxMinas = Convert.ToInt32(Math.Pow(Tamanho - 1, 2));
        NumeroDeMinas = (int)(maxMinas * Dificuldade);
        Campo = new int[Tamanho, Tamanho];
        Aberto = new bool[Tamanho, Tamanho];
        Sinalizado = new bool[Tamanho, Tamanho];

        GeraMinaAleatoria();
    }
    private void GeraMinaAleatoria()
    {
        // Preenche com as minas em posições aleatórias
        int minasPosicionadas = 0;
        do
        {
            int colunaSorteada = RandomNumberGenerator.GetInt32(0, Tamanho);
            int linhaSorteada = RandomNumberGenerator.GetInt32(0, Tamanho);

            if (Campo[linhaSorteada, colunaSorteada] == VAZIO)
            {
                Campo[linhaSorteada, colunaSorteada] = MINA;
                minasPosicionadas++;
            }
        }
        while (minasPosicionadas < NumeroDeMinas);

        // Calcula as numerações pela quantidadde de minas adjacentes
        for (int linha = 0; linha < Tamanho; linha++)
            for (int coluna = 0; coluna < Tamanho; coluna++)
            {
                int colunaInicio = Math.Max(coluna - 1, 0);
                int colunaLimite = Math.Min(coluna + 2, Tamanho);

                int linhaInicio = Math.Max(linha - 1, 0);
                int linhaLimite = Math.Min(linha + 2, Tamanho);

                int qtdMinasAdjacentes = 0;

                for (int l = linhaInicio; l < linhaLimite; l++)
                    for (int c = colunaInicio; c < colunaLimite; c++)
                        if (Campo[l, c] == MINA) qtdMinasAdjacentes++;

                if (Campo[linha, coluna] != MINA)
                    Campo[linha, coluna] = qtdMinasAdjacentes;
            }
    }
    public void InverteSinalizacao(int linha, int coluna)
    {
        Sinalizado[linha, coluna] = !Sinalizado[linha, coluna];
    }
    private bool AbreLocalEExpande(int linha, int coluna)
    {
        bool minaEncontrada = false;

        if (!PodeAbrir(linha, coluna))
            return minaEncontrada;

        // Marca como aberto
        Aberto[linha, coluna] = true;

        // Verifica se é mina
        minaEncontrada = Campo[linha, coluna] == MINA;

        // Se não for vazio, não expande
        // Também garante que não explodirá, (não há minas com vizinhos vazios)
        if (Campo[linha, coluna] != VAZIO)
            return minaEncontrada;

        // Expandindo...

        // Encontra os limites da vizinhança
        int colunaInicioVz = Math.Max(coluna - 1, 0);
        int colunaLimiteVz = Math.Min(coluna + 2, Tamanho);
        int linhaInicioVz = Math.Max(linha - 1, 0);
        int linhaLimiteVz = Math.Min(linha + 2, Tamanho);

        // Se um vizinho pode ser aberto, abre e expande
        for (int linhaVz = linhaInicioVz; linhaVz < linhaLimiteVz; linhaVz++)
            for (int colunaVz = colunaInicioVz; colunaVz < colunaLimiteVz; colunaVz++)
                if (PodeAbrir(linhaVz, colunaVz))
                    minaEncontrada = minaEncontrada              // anteriormente
                        || AbreLocalEExpande(linhaVz, colunaVz); // ou nas próximas expansões

        return minaEncontrada;
    }
    public bool AbreLocal(int linha, int coluna)
    {
        IncrementaRodada();
        return AbreLocalEExpande(linha, coluna);
    }
    public bool AbreTodosLocaisVizinhos(int linha, int coluna)
    {
        bool minaEncontrada = false;

        // Se não for um número aberto não sinalizado, não abre
        if (!PodeAbrirLocaisVizinhos(linha, coluna))
            return minaEncontrada;

        // Executando ações nos vizinhos...

        // Encontra os limites da vizinhança
        int colunaInicioVz = Math.Max(coluna - 1, 0);
        int colunaLimiteVz = Math.Min(coluna + 2, Tamanho);
        int linhaInicioVz = Math.Max(linha - 1, 0);
        int linhaLimiteVz = Math.Min(linha + 2, Tamanho);

        // Se um vizinho pode ser aberto, executa ação de abertura
        for (int linhaVz = linhaInicioVz; linhaVz < linhaLimiteVz; linhaVz++)
            for (int colunaVz = colunaInicioVz; colunaVz < colunaLimiteVz; colunaVz++)
                if (PodeAbrir(linhaVz, colunaVz))
                {
                    IncrementaRodada(); // Cada abertura conta como uma ação
                    minaEncontrada = minaEncontrada              // anteriormente
                        || AbreLocalEExpande(linhaVz, colunaVz); // ou nas próximas expansões
                }
        return minaEncontrada;
    }
    private void IncrementaRodada()
    {
        RodadaAtual++;
    }
    public bool PodeAbrir(int linha, int coluna) =>
        !Aberto[linha, coluna] &&
        !Sinalizado[linha, coluna];
    public bool PodeAbrirLocaisVizinhos(int linha, int coluna) =>
        Aberto[linha, coluna] &&
        !Sinalizado[linha, coluna] &&
        Campo[linha, coluna] >= 1;
    public bool PodeSinalizar(int linha, int coluna) =>
        !Aberto[linha, coluna];
}

class UI
{
    public const string ACAO_ABRIR = "a";
    public const string ACAO_ABRIR_VARIOS = "t";
    public const string ACAO_SINALIZAR = "s";
    public const string ACAO_DESISTIR = "d";
    public List<string> AcoesPossiveis { get; } = new() {
        ACAO_ABRIR, ACAO_ABRIR_VARIOS, ACAO_SINALIZAR, ACAO_DESISTIR
    };
    private CampoMinado Jogo { get; }
    public UI(CampoMinado jogo)
    {
        Jogo = jogo;
    }
    private void ExibeLocal(int linha, int coluna, bool finalDeJogo = false)
    {
        string simbolo;
        ConsoleColor cor;

        if (Jogo.Sinalizado[coluna, linha])
        {
            cor = ConsoleColor.Yellow;
            if (!finalDeJogo)
                simbolo = "!";
            else if (Jogo.Campo[coluna, linha] == CampoMinado.MINA)
                simbolo = "*";
            else
                simbolo = "x";
        }
        else if (!Jogo.Aberto[coluna, linha] && !finalDeJogo)
        {
            simbolo = "-";
            cor = ConsoleColor.Gray;
        }
        else
        {
            simbolo = Jogo.Campo[coluna, linha] switch
            {
                CampoMinado.VAZIO => " ",
                CampoMinado.MINA => "*",
                > 0 => $"{Jogo.Campo[coluna, linha]}",
                _ => "?"
            };

            cor = Jogo.Campo[coluna, linha] switch
            {
                CampoMinado.MINA => ConsoleColor.Red,
                1 => ConsoleColor.Blue,
                2 => ConsoleColor.Green,
                > 2 => ConsoleColor.Red,
                _ => ConsoleColor.White,
            };
        }

        var corAnterior = Console.ForegroundColor;
        Console.ForegroundColor = cor;
        Console.Write($" {simbolo} ");
        Console.ForegroundColor = corAnterior;
    }
    private void ExibeCampo(bool finalDeJogo = false)
    {
        string bordaHorizontal = $"+{"".PadLeft(Jogo.Tamanho * 3, '-')}+";
        string bordaVertical = "|";

        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.WriteLine($"\n      {bordaHorizontal}");

        for (int linha = 0; linha < Jogo.Campo.GetLength(0); linha++)
        {
            // Régua vertical
            Console.Write($"{linha,5} ");

            Console.Write(bordaVertical);

            for (int coluna = 0; coluna < Jogo.Campo.GetLength(1); coluna++)
                ExibeLocal(coluna, linha, finalDeJogo);

            Console.WriteLine(bordaVertical);
        }

        Console.WriteLine($"      {bordaHorizontal}");

        // Régua horizontal
        Console.Write("      ");
        for (int c = 0; c < Jogo.Tamanho; c++)
            Console.Write($"{c,3}");

        Console.WriteLine();
        Console.ResetColor();
    }
    public string RecebeAcaoDesejada(string padrao)
    {
        string acao = padrao;
        bool entradaValida;
        do
        {
            Console.WriteLine();
            foreach (var acaoPossivel in AcoesPossiveis)
                Console.WriteLine($"[{acaoPossivel}{(acaoPossivel == acao ? " ou ENTER" : "")}] = {DescricaoAcao(acaoPossivel)}");

            Console.Write("\nO que deseja fazer? ");
            string entrada = (Console.ReadLine() ?? "").ToLower().PadRight(1).Substring(0, 1).Trim();

            if (String.IsNullOrEmpty(entrada))
                break;

            entradaValida = AcoesPossiveis.Contains(entrada);

            if (entradaValida) acao = entrada;
        } while (!entradaValida);

        ExibeAcaoEscolhida(acao);
        return acao;
    }
    public int RecebeNumeroCoordenada(string mensagem, int tempoDePausa = 0)
    {
        int coordenada = 0;
        bool entradaValida;
        do
        {
            Console.Write(mensagem);
            string entrada = (Console.ReadLine() ?? "").Trim();

            if (String.IsNullOrEmpty(entrada))
            {
                coordenada = RandomNumberGenerator.GetInt32(Jogo.Tamanho);
                ExibeMensagemInformativa($"\tsorteio = {coordenada}", tempoDePausa);
                break;
            }

            entradaValida = Int32.TryParse(entrada, out coordenada)
                && coordenada >= 0
                && coordenada < Jogo.Tamanho;
        } while (!entradaValida);
        return coordenada;
    }
    public int RecebeLinha() => RecebeNumeroCoordenada("Linha  [ENTER = aleatório]...: ");
    public int RecebeColuna() => RecebeNumeroCoordenada("Coluna [ENTER = aleatório]...: ", tempoDePausa: 1000);
    public static int RecebeTamanho(int padrao)
    {
        int tamanho = padrao;
        bool entradaValida;
        do
        {
            Console.Write($"Tamanho do campo (3 a 20) [ENTER = {tamanho,3}]...: ");
            string entrada = (Console.ReadLine() ?? "").Trim();

            if (String.IsNullOrEmpty(entrada))
                break;

            entradaValida = Int32.TryParse(entrada, out tamanho)
                && tamanho >= 3
                && tamanho <= 20;
        } while (!entradaValida);
        return tamanho;
    }
    public static double RecebeDificuldade(double padrao)
    {
        int dificuldade = (int)(padrao * 100);
        bool entradaValida;
        do
        {
            Console.Write($"Dificuldade     (1 a 100) [ENTER = {dificuldade,3:N0}]...: ");
            string entrada = (Console.ReadLine() ?? "").Trim();

            if (String.IsNullOrEmpty(entrada))
                break;

            entradaValida = Int32.TryParse(entrada, out dificuldade)
                && dificuldade >= 1
                && dificuldade <= 100;
        } while (!entradaValida);
        return (double)dificuldade / 100;
    }
    public static void ExibeTelaInicial()
    {
        Console.Clear();
        Console.WriteLine("--- Campo Minado ---\n");
    }
    public void ExibeNovaRodada()
    {
        Console.Clear();
        Console.WriteLine($"--- Campo Minado ---\n");

        Console.WriteLine($"Minas sinalizadas: {Jogo.NumeroDeSinais}");
        Console.WriteLine($"Minas restantes  : {Jogo.NumeroDeMinas - Jogo.NumeroDeSinais}");
        Console.WriteLine($"\nRodada #{Jogo.RodadaAtual}");

        ExibeCampo();
    }
    public void ExibeResultado(bool terminouEmVitoria)
    {
        Console.WriteLine("\nFim de jogo.");
        Thread.Sleep(500);

        ExibeCampo(finalDeJogo: true);

        if (terminouEmVitoria)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nVocê venceu! Tente aumentar a dificuldade.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nVocê perdeu. Tente reduzir a dificuldade.");
        }

        Console.ResetColor();
    }
    public static void ExibeMensagemErro(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine(mensagem);
        Console.ResetColor();
        Console.Write("\nPressione uma tecla para continuar...");
        Console.ReadKey();
    }
    public static void ExibeMensagemInformativa(string mensagem, int tempoDePausa = 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(mensagem);
        Console.ResetColor();
        Thread.Sleep(tempoDePausa);
    }
    public string DescricaoAcao(string acao) => acao switch
    {
        ACAO_ABRIR => "Abrir",
        ACAO_SINALIZAR => "Sinalizar",
        ACAO_DESISTIR => "Desistir",
        ACAO_ABRIR_VARIOS => "Abrir todos os adjacentes a um número",
        _ => ""
    };
    public void ExibeAcaoEscolhida(string acaoEscolhida)
    {
        UI.ExibeMensagemInformativa($"Ação = {DescricaoAcao(acaoEscolhida)}\n", tempoDePausa: 0);
    }
    public static bool DesejaSair()
    {
        Console.WriteLine();
        Console.Write("\nPressione uma tecla para jogar novamente (ESC para finalizar o jogo)...");
        return Console.ReadKey().Key == ConsoleKey.Escape;
    }
}
