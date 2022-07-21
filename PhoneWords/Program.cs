Console.WriteLine("--- Conversor de Phone Words ---\n");

Console.Write("Telefone...: ");
string phoneWord = Console.ReadLine()!;

string fone = phoneWord.ToLower()
    .Replace("a", "2")
    .Replace("b", "2")
    .Replace("c", "2")

    .Replace("d", "3")
    .Replace("e", "3")
    .Replace("f", "3")

    .Replace("g", "4")
    .Replace("h", "4")
    .Replace("i", "4")

    .Replace("j", "5")
    .Replace("k", "5")
    .Replace("l", "5")

    .Replace("m", "6")
    .Replace("n", "6")
    .Replace("o", "6")

    .Replace("p", "7")
    .Replace("q", "7")
    .Replace("r", "7")
    .Replace("s", "7")

    .Replace("t", "8")
    .Replace("u", "8")
    .Replace("v", "8")

    .Replace("w", "9")
    .Replace("x", "9")
    .Replace("y", "9")
    .Replace("z", "9")
;

Console.WriteLine($"\nO número digitado é {fone}.");
