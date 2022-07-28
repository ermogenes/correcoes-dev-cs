Console.WriteLine("--- Alinhamento à direita ---\n");

Console.Write("Digite a primeira palavra...: ");
string palavra1 = Console.ReadLine()!.Trim();

Console.Write("Digite a segunda palavra....: ");
string palavra2 = Console.ReadLine()!.Trim();

Console.Write("Digite a terceira palavra...: ");
string palavra3 = Console.ReadLine()!.Trim();

Console.WriteLine();

Console.WriteLine($"{palavra1.PadLeft(20, ' ')}");
Console.WriteLine($"{palavra2.PadLeft(20, ' ')}");
Console.WriteLine($"{palavra3.PadLeft(20, ' ')}");
