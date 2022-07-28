Console.WriteLine("--- Escada ---\n");

Console.WriteLine($"uma escada de {4}m a {70}° alcança {AlturaEscadaNaParede(4, 70):N2}m");
Console.WriteLine($"uma escada de {4}m a {45}° alcança {AlturaEscadaNaParede(4, 45):N2}m");
Console.WriteLine($"uma escada de {5}m a {70}° alcança {AlturaEscadaNaParede(5, 70):N2}m");

double AlturaEscadaNaParede(double comprimentoEscada, double anguloChaoGraus)
{
    double anguloChaoRadianos = Math.PI * anguloChaoGraus / 180;
    return comprimentoEscada * Math.Sin(anguloChaoRadianos);
}
