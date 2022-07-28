Console.WriteLine("Máximo Divisor Comum (método iterativo)");

Console.Write("Digite o 1º número (a): ");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("Digite o 2º número (b): ");
int b = Convert.ToInt32(Console.ReadLine());

int resto;
do
{
    resto = a % b;
    a = b;
    b = resto;
}
while (resto != 0);

Console.WriteLine($"MDC(a, b) = {a}");
