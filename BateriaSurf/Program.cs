Console.WriteLine("--- Bateria de Surf ---");

// Uma nova bateria
var bateria = new Bateria();

// Obtém quantas ondas o surfista desejar
string maisUmaOnda = "S";
while (maisUmaOnda == "S")
{
    // Uma nova onda
    var ondaAtual = new Onda();

    Console.WriteLine($"\n-- {bateria.QuantidadeDeOndas() + 1}ª onda --");

    // Obtém as notas dos 5 juízes em uma onda
    while (!ondaAtual.TodosJuizesDeramNotas())
    {
        Console.Write($"Juiz {ondaAtual.QuantidadeDeNotas() + 1}: ");

        string valorDigitado = Console.ReadLine()!;
        double notaOnda;
        if (!Double.TryParse(valorDigitado, out notaOnda))
            continue;

        ondaAtual.AdicionarNota(notaOnda);
    }

    Console.WriteLine($"Nota obtida = {ondaAtual.Nota():N2}");
    bateria.AdicionarOnda(ondaAtual);

    Console.WriteLine();
    while (true)
    {
        Console.Write("Mais uma onda (S/N)? ");
        maisUmaOnda = (Console.ReadLine() ?? "").Trim().PadLeft(1, ' ').Substring(0, 1).ToUpper();

        if (maisUmaOnda == "S" || maisUmaOnda == "N")
            break;
    }
}

Console.WriteLine($"\nPontos na bateria = {bateria.Pontos():N2}");

if (bateria.BateriaPerfeita())
    Console.WriteLine("\nBATERIA PERFEITA!");

class Bateria
{
    private List<Onda> ondas = new();

    public void AdicionarOnda(Onda novaOnda)
    {
        if (!novaOnda.TodosJuizesDeramNotas())
            throw new ArgumentException("São necessárias 5 notas.");

        ondas.Add(novaOnda);
    }
    public int QuantidadeDeOndas() => ondas.Count();
    public bool BateriaPerfeita() => Pontos() == 20;
    public double Pontos() => ondas
        .OrderByDescending(onda => onda.Nota())
        .Take(2)
        .Sum(onda => onda.Nota());
}

class Onda
{
    private List<double> notas = new();

    public void AdicionarNota(double notaDadaPorJuiz)
    {
        if (TodosJuizesDeramNotas())
            throw new ArgumentException("Limite 5 notas atingido.");

        notas.Add(notaDadaPorJuiz);
    }
    public int QuantidadeDeNotas() => notas.Count();
    public bool TodosJuizesDeramNotas() => QuantidadeDeNotas() >= 5;
    public double Nota()
    {
        if (!TodosJuizesDeramNotas())
            return 0;

        return notas
            .OrderBy(nota => nota)
            .Skip(1)
            .Reverse()
            .Skip(1)
            .Average();
    }
}
