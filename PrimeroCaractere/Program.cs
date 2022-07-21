Console.WriteLine("--- Primero Caractere ---\n");

Console.Write("Digite algo...: ");
string textoDigitado = Console.ReadLine()!;

Console.WriteLine(textoDigitado.Trim().Substring(0, 1));
