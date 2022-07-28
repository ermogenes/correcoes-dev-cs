Console.Write("Digite um número inteiro positivo: ");
int numero = Convert.ToInt32(Console.ReadLine());

if (numero <= 0)
{
    Console.WriteLine("Somente números maiores que zero.");
}
else
{
    Console.Write("\nDígitos: ");

    int somaDigitos = 0;

    while (numero > 0)
    {
        int proximoNumero = numero / 10;
        int digitoAtual = numero % 10;

        somaDigitos += digitoAtual;
        numero = proximoNumero;

        Console.Write($"{digitoAtual} ");
    }

    Console.WriteLine($"\n\nSoma = {somaDigitos}");
}
