const double RaioVermelho = 1;
const double RaioAzul = 3;
const double RaioAmarelo = 5;

double x, y, distanciaX, distanciaY, distanciaDardo;

Console.WriteLine("--- Dardos ---\n");

Console.Write("Digite a coordenada X..: ");
x = Convert.ToDouble(Console.ReadLine());

Console.Write("Digite a coordenada Y..: ");
y = Convert.ToDouble(Console.ReadLine());

distanciaX = Math.Abs(x);
distanciaY = Math.Abs(y);

distanciaDardo = Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));

Console.WriteLine($"\nDistância do centro: {distanciaDardo:N2}\n");

if (distanciaDardo <= RaioVermelho)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Acertou na mosca!");
}
else if (distanciaDardo <= RaioAzul)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Arremesso bom.");
}
else if (distanciaDardo <= RaioAmarelo)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Arremesso ruim...");
}
else
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Errou :(");
}

Console.ResetColor();
