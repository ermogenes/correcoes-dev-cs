Console.WriteLine("--- Texto Vazio ---\n");

Console.Write("Digite um texto qualquer: ");
string texto = Console.ReadLine()!;

Console.WriteLine(String.IsNullOrEmpty(texto.Trim()));
