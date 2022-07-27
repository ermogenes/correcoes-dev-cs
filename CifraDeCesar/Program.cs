const string AlfabetoClaro = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
const string AlfabetoCifra = "NOPQRSTUVWXYZABCDEFGHIJKLM";

Console.WriteLine("--- Cifra de César ---\n");

Console.Write("Texto claro.....: ");
string textoClaro = Console.ReadLine()!;

if (String.IsNullOrEmpty(textoClaro)) return;

int tamanho = textoClaro.Length;

char[] caracteresTextoClaro = textoClaro.ToUpper().ToCharArray();
char[] caracteresTextoCifrado = new char[tamanho];

for (int c = 0; c < tamanho; c++)
{
    char entrada = caracteresTextoClaro[c];
    char saida = entrada;

    if (AlfabetoClaro.Contains(entrada))
    {
        int posicaoNoAlfabetoClaro = AlfabetoClaro.IndexOf(entrada);
        saida = AlfabetoCifra[posicaoNoAlfabetoClaro];
    }
    caracteresTextoCifrado[c] = saida;
}

string textoCifrado = String.Join("", caracteresTextoCifrado);

Console.Write("Texto cifrado...: ");
Console.WriteLine(textoCifrado);
