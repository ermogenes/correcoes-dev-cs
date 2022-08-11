Console.WriteLine("--- Inverte Frase ---\n");

Console.Write("Digite uma frase: ");
string frase = Console.ReadLine()!;

var fraseInvertida = String.Join(" ", frase.Split().Reverse());

Console.WriteLine();
Console.WriteLine(fraseInvertida);
