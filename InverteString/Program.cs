Console.WriteLine("--- Inversor de strings ---\n");

Console.Write("Digite algo: ");
string textoDigitado = Console.ReadLine()!;

char[] arranjoLetras = textoDigitado.ToCharArray();

Array.Reverse(arranjoLetras);

string textoInvertido = String.Join("", arranjoLetras);

Console.WriteLine(textoInvertido);
