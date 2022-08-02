Console.WriteLine("--- Composição Musical ---\n");

Console.WriteLine("Digite nota e tempo em milissegundos separados por vírgula.\n");
Console.WriteLine("do | re | mi | fa | sol | la | si | (qualquer outra entrada para pausa) | parar\n");
Console.WriteLine("tocar | parar\n");

var composicao = new Composicao();

while (true)
{
    try
    {
        Console.Write("Entrada: ");
        List<string> entradas = Console.ReadLine()!.Trim().Split(",").ToList();

        if (entradas[0] == "parar") break;
        if (entradas[0] == "tocar")
        {
            composicao.Tocar();
            Console.WriteLine();
            continue;
        }

        string nota = entradas[0];
        int tempo = Convert.ToInt32(entradas[1]);

        composicao.AdicionarTom(new Tom(nota, tempo));
    }
    catch (System.Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

composicao.Tocar();

class Composicao
{
    private Queue<Tom> Tons = new();
    public bool ExibirNotaTocada = true;

    public void AdicionarTom(Tom tom)
    {
        Tons.Enqueue(tom);
    }

    public void Tocar()
    {
        while (Tons.Count() > 0)
        {
            var tom = Tons.Dequeue();

            if (ExibirNotaTocada)
            {
                string textoNota = tom.frequencia switch
                {
                    1320 => "do",
                    1485 => "re",
                    1650 => "mi",
                    1759 => "fa",
                    1980 => "sol",
                    2200 => "la",
                    2475 => "si",
                    0 => "...",
                    _ => tom.frequencia.ToString(),
                };
                Console.Write($"{textoNota} ");
            }

            if (tom.frequencia == 0)
                Thread.Sleep(tom.tempo);
            else
                Console.Beep(tom.frequencia, tom.tempo);
        }
    }
}

class Tom
{
    public int frequencia { get; set; }
    public int tempo { get; set; }
    public Tom(string nota, int milis)
    {
        frequencia = nota switch
        {
            "do" => 1320,
            "re" => 1485,
            "mi" => 1650,
            "fa" => 1759,
            "sol" => 1980,
            "la" => 2200,
            "si" => 2475,
            _ => 0,
        };
        tempo = milis;
    }
}
