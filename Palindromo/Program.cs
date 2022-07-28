Console.WriteLine("-- Palíndromo --\n");

Console.Write("Digite algo: ");
string textoDigitado = Console.ReadLine()!;

string textoSanitizado = textoDigitado
    .Replace(".", "")
    .Replace("!", "")
    .Replace("?", "")
    .Replace(":", "")
    .Replace(",", "")
    .Replace(";", "")
    .Replace("-", "")

    .Replace(" ", "")

    .ToLower()

    .Replace("á", "a")
    .Replace("à", "a")
    .Replace("ã", "a")
    .Replace("â", "a")
    .Replace("é", "e")
    .Replace("ê", "e")
    .Replace("ó", "o")
    .Replace("õ", "o")
    .Replace("ô", "o")
    .Replace("ú", "u")
    .Replace("û", "u")
    .Replace("ç", "c")
;

char[] arranjoLetras = textoSanitizado.ToCharArray();

Array.Reverse(arranjoLetras);

string textoInvertido = String.Join("", arranjoLetras);

if (textoSanitizado.ToLower() == textoInvertido)
{
    Console.WriteLine($"\nÉ um palíndromo ({textoSanitizado}).");
}
else
{
    Console.WriteLine($"\nNão é um palíndromo ({textoSanitizado}).");
}
