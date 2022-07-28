double lado1, lado2, lado3;
double p; // Semiperímetro
double area;

Console.WriteLine("Digite os lados do triângulo desejado.\n");

Console.Write("Lado 1..: ");
lado1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Lado 2..: ");
lado2 = Convert.ToDouble(Console.ReadLine());

Console.Write("Lado 3..: ");
lado3 = Convert.ToDouble(Console.ReadLine());

p = (lado1 + lado2 + lado3) / 2;
area = Math.Sqrt(p * (p - lado1) * (p - lado2) * (p - lado3));

Console.WriteLine($"Semiperímetro..: {p}");
Console.WriteLine($"Área...........: {area}");
