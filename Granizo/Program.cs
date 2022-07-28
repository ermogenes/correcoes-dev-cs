Console.WriteLine("--- Sequência de Collatz (Números de granizo) ---");

Console.WriteLine($"\n--- x = {10}:"); ExibeSequenciaCollatz(10);
Console.WriteLine($"\n--- x = {100}:"); ExibeSequenciaCollatz(100);
Console.WriteLine($"\n--- x = {127}:"); ExibeSequenciaCollatz(127);
Console.WriteLine($"\n--- x = {77031}:"); ExibeSequenciaCollatz(77031);

void ExibeSequenciaCollatz(int x)
{
    while (x > 1)
    {
        x = x % 2 == 0 ? x / 2 : x * 3 + 1;
        Console.Write($"{x} ");
    }
}
