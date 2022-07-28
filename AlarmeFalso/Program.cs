Console.WriteLine("--- Alarme Falso ---\n");

Console.WriteLine($"precisão = {0.87,6} com incidência = {0.01,6} implica falso = {ProbabilidadeAlarmeFalso(0.87, 0.01),6:N3}");
Console.WriteLine($"precisão = {0.999,6} com incidência = {0.01,6} implica falso = {ProbabilidadeAlarmeFalso(0.999, 0.01),6:N3}");
Console.WriteLine($"precisão = {0.999,6} com incidência = {0.0001,6} implica falso = {ProbabilidadeAlarmeFalso(0.999, 0.0001),6:N3}");

double ProbabilidadeAlarmeFalso(double p, double i)
{
    return (1 - p) * (1 - i) / (p * i + (1 - p) * (1 - i));
}
