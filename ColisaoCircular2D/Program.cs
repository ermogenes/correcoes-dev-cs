Console.WriteLine("--- Colisão Circular 2D ---\n");

Console.WriteLine($"({-2},{0}) com raio {4} e ({4},{4}) com raio {2} ==> Colisão? {ColisaoCircular2D(-2, 0, 4, 4, 4, 2)}");
Console.WriteLine($"({-2},{0}) com raio {4} e ({2},{4}) com raio {2} ==> Colisão? {ColisaoCircular2D(-2, 0, 4, 2, 4, 2)}");

bool ColisaoCircular2D(double x1, double y1, double r1, double x2, double y2, double r2)
{
    double distanciaX = Math.Abs(x1 - x2);
    double distanciaY = Math.Abs(y1 - y2);
    double distancia = Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));
    double distanciaMinima = r1 + r2;
    return distancia <= distanciaMinima;
}
