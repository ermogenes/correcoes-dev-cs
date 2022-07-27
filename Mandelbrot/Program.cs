Console.WriteLine("--- Série de Mandelbrot ---\n");

Console.Write("Entre com o valor de [c] (entre 0 e 10)...: ");
double c = Convert.ToDouble(Console.ReadLine());

if (c <= 0 || c > 10) return;

double[] z = new double[10];

z[0] = 0;
for (int i = 1; i < z.Length; i++)
{
    z[i] = Math.Pow(z[i - 1], 2) + c;
}

Console.WriteLine($"\nPara c = {c}:\n");

for (int i = 0; i < z.Length; i++)
{
    Console.WriteLine($"z({i}) = {z[i]:N4}");
}
