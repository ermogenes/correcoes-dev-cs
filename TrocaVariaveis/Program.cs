string nome1, nome2, auxiliar;

Console.WriteLine("--- Troca de Valores ---\n");

Console.Write("Nome 1..: ");
nome1 = Console.ReadLine()!;

Console.Write("Nome 2..: ");
nome2 = Console.ReadLine()!;

auxiliar = nome1;
nome1 = nome2;
nome2 = auxiliar;

Console.WriteLine("\nApós trocar os valores temos:\n");

Console.WriteLine($"Nome 1 = {nome1}");
Console.WriteLine($"Nome 2 = {nome2}");
