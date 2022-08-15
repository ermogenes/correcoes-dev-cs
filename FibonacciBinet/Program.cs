Console.WriteLine("--- Sequência de Fibonacci usando Binet ---");

for (int i = 1; i <= 70; i++)
    Console.WriteLine($"F({i}) = {Fibonacci(i):N0} ");

double Fibonacci(int n)
{
    if (n < 1 || n > 70)
        throw new ArgumentOutOfRangeException("O argumento 'n' deve estar entre 1 e 70.");

    const double Phi = 1.61803_39887_49894_84820;
    return (Math.Pow(Phi, n) - Math.Pow(-Phi, -n)) / (2 * Phi - 1);
}
