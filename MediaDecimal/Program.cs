﻿Console.Write("Quantos números: ");
int quantidade = Convert.ToInt32(Console.ReadLine());

decimal numeroDigitado;
int contador = 0;

decimal soma = 0;
decimal maiorNumero = 999999.99M;
decimal menorNumero = 999999.99M;

while (contador < quantidade)
{
    contador += 1;
    Console.Write($"Número #{contador}: ");
    numeroDigitado = Convert.ToDecimal(Console.ReadLine());
    soma = soma + numeroDigitado;

    if (contador == 1)
    {
        maiorNumero = numeroDigitado;
        menorNumero = numeroDigitado;
    }

    if (numeroDigitado > maiorNumero)
    {
        maiorNumero = numeroDigitado;
    }

    if (numeroDigitado < menorNumero)
    {
        menorNumero = numeroDigitado;
    }
}

if (contador > 0)
{
    decimal media = soma / quantidade;

    Console.WriteLine($"\nSoma...: {soma:N2}");
    Console.WriteLine($"Média..: {media:N2}");
    Console.WriteLine($"Menor..: {menorNumero:N2}");
    Console.WriteLine($"Maior..: {maiorNumero:N2}");
}
