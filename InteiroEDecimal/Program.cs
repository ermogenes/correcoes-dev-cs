double numeroReal, parteInteira, parteDecimal;

Console.WriteLine("--- Inteiro e Decimal ---\n");

Console.Write("Digite um número: ");
numeroReal = Convert.ToDouble(Console.ReadLine());

parteInteira = (int)numeroReal;
parteDecimal = numeroReal % 1;

Console.WriteLine();

Console.WriteLine($"Parte inteira: {parteInteira}");
Console.WriteLine($"Parte decimal: {parteDecimal:N4}");
