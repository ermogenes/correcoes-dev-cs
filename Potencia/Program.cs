Console.WriteLine("--- Potência ---\n");

int @base, expoente;

Console.Write("Digite a base.......: ");
@base = Convert.ToInt32(Console.ReadLine());

Console.Write("Digite o expoente...: ");
expoente = Convert.ToInt32(Console.ReadLine());

// Validação
if (@base < 0 || expoente < 0) return;

// Resultados são dados para base 0, e para primeira iteração
int potencia = expoente == 0 ? 1 : @base;

int i = 2;
int potenciaAnterior = potencia;
// Caso tenha mais de 1 iteração, repete até [expoente]-iterações
while (expoente > 1 && i <= expoente)
{
    potencia *= @base;

    if (potencia < potenciaAnterior)
    {
        Console.WriteLine($"\nNúmero muito grande, finalizado na {i}ª iteração.");
        return;
    }

    i++;
}

Console.WriteLine($"\n{@base:N0} elevado a {expoente:N0} é {potencia:N0}.");
