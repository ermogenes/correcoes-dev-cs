Console.WriteLine("--- Forca ---\n");

Console.Write("Qual a palavra secreta? ");
string palavraSecreta = Console.ReadLine()!;

Console.Write("Qual a letra? ");
string letra = Console.ReadLine()!
    .Trim()
    .Substring(0, 1)
    .ToLower();

bool letraExiste = palavraSecreta
    .ToLower()
    .Contains(letra);

Console.WriteLine($"\nA letra \"{letra}\" existe na palavra secreta => {letraExiste}");
