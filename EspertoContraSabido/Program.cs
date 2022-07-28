Console.WriteLine("--- Esperto Contra Sabido ---\n");

Console.Write("Quantos alimentos serão distribuídos? ");
int total = Convert.ToInt32(Console.ReadLine());

if (total <= 0) return;

Console.WriteLine();

int restantes = total;
int picaPau = 0, raposinha = 0;

int contadorParaVoce = 0, contadorParaMim = 0;
while (restantes > 0)
{
    contadorParaVoce++;
    picaPau += 1;
    restantes -= 1;

    Console.Write($"{picaPau} para você. ");

    contadorParaMim = 0;
    while (restantes > 0 && contadorParaMim < contadorParaVoce)
    {
        contadorParaMim++;
        raposinha += 1;
        restantes -= 1;

        Console.Write($"{contadorParaMim}");

        if (restantes > 0 && contadorParaMim < contadorParaVoce)
        {
            Console.Write(",");
        }

        Console.Write(" ");
    }

    if (contadorParaMim > 0)
    {
        Console.WriteLine("para mim.");
    }
}

if (contadorParaMim == 0)
{
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine($"Pica-pau recebeu {picaPau} alimento(s).");
Console.WriteLine($"Raposinha recebeu {raposinha} alimento(s).");
