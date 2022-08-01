using System.Security.Cryptography;

Console.WriteLine("--- Mão de Truco ---\n");

var baralho = new BaralhoLimpo();

for (int jogador = 1; jogador <= 4; jogador++)
{
    Console.Write($"{jogador}º jogador: ");
    for (int carta = 1; carta <= 3; carta++)
    {
        Console.Write($"{baralho.CartaDoTopo.Face} ");
    }
    Console.WriteLine();
}

Console.WriteLine($"\nVira: {baralho.CartaDoTopo.Face}");

// while (baralho.CartasRestantes > 0) Console.Write($"{baralho.CartaDoTopo.Face} ");

class BaralhoLimpo
{
    private const string NaipesValidos = "♣♥♠♦";
    private const string NumerosValidos = "A23QJK";
    private Stack<Carta> cartas = new();
    public BaralhoLimpo()
    {
        foreach (var naipe in NaipesValidos)
            foreach (var numero in NumerosValidos)
                cartas.Push(new Carta(numero.ToString(), naipe.ToString()));

        Embaralhar();
    }

    public void Embaralhar()
    {
        List<Carta> baralhoAtual = cartas.ToList();
        Stack<Carta> cartasEmbaralhadas = new();

        while (baralhoAtual.Count() > 0)
        {
            int posicao = RandomNumberGenerator.GetInt32(0, baralhoAtual.Count());
            cartasEmbaralhadas.Push(baralhoAtual.ElementAt(posicao));
            baralhoAtual.RemoveAt(posicao);
        }

        cartas = cartasEmbaralhadas;
    }

    public int CartasRestantes { get => cartas.Count(); }
    public Carta CartaDoTopo { get => cartas.Pop(); }
}

class Carta
{
    private const string NumerosValidos = "A23QJK";
    private const string NaipesValidos = "♣♥♠♦";
    public string Numero { get; private set; }
    public string Naipe { get; private set; }
    public string Face
    {
        get => $"{Numero}{Naipe}";
    }

    public Carta(string numero, string naipe)
    {
        numero = numero.ToUpper();
        if (numero.Length != 1 || !NumerosValidos.Contains(numero))
            throw new ArgumentException("Número inválido");

        naipe = naipe.ToUpper();
        if (naipe.Length != 1 || !NaipesValidos.Contains(naipe))
            throw new ArgumentException("Naipe inválido");

        Numero = numero;
        Naipe = naipe;
    }
}
