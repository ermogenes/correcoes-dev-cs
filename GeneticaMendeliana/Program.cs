string individuo1Alelo1, individuo1Alelo2, individuo2Alelo1, individuo2Alelo2;
string cruzamento11, cruzamento12, cruzamento21, cruzamento22;
string descricaoAA, descricaoAa, descricaoaa;

double percentualAA, percentualAa, percentualaa;

Console.WriteLine("--- Genética Mendeliana ---\n");

// Obtém informações sobe os indivíduos
Console.Write("Alelos do indivíduo 1 (AA, Aa ou aa)...: ");
string individuo1 = NormalizaAlelo(Console.ReadLine()!.Trim().Substring(0, 2));

Console.Write("Alelos do indivíduo 2 (AA, Aa ou aa)...: ");
string individuo2 = NormalizaAlelo(Console.ReadLine()!.Trim().Substring(0, 2));

// Obtém o tipo de dominância da característica
Console.Write("Tipo de dominância (C/I)...............: ");
string dominancia = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if (dominancia != "C" && dominancia != "I")
{
    Console.WriteLine("Tipo de dominância inválido.");
    return;
}

// Separa os alelos dos indivíduos
individuo1Alelo1 = individuo1.Substring(0, 1);
individuo1Alelo2 = individuo1.Substring(1, 1);
individuo2Alelo1 = individuo2.Substring(0, 1);
individuo2Alelo2 = individuo2.Substring(1, 1);

// Faz os cruzamentos
cruzamento11 = NormalizaAlelo($"{individuo1Alelo1}{individuo2Alelo1}");
cruzamento12 = NormalizaAlelo($"{individuo1Alelo1}{individuo2Alelo2}");
cruzamento21 = NormalizaAlelo($"{individuo1Alelo2}{individuo2Alelo1}");
cruzamento22 = NormalizaAlelo($"{individuo1Alelo2}{individuo2Alelo2}");

// Exibe tabela
Console.WriteLine();
Console.WriteLine($"  | {individuo1Alelo1}  |  {individuo1Alelo2}");
Console.WriteLine($"-----------");
Console.WriteLine($"{individuo2Alelo1} | {cruzamento11} | {cruzamento21}");
Console.WriteLine($"-----------");
Console.WriteLine($"{individuo2Alelo2} | {cruzamento12} | {cruzamento22}");

// Conta cada tipo de alelo nos cruzamentos
percentualAA = 100 * (
    (cruzamento11 == "AA" ? 1 : 0) +
    (cruzamento12 == "AA" ? 1 : 0) +
    (cruzamento21 == "AA" ? 1 : 0) +
    (cruzamento22 == "AA" ? 1 : 0)
) / 4;

percentualAa = 100 * (
    (cruzamento11 == "Aa" ? 1 : 0) +
    (cruzamento12 == "Aa" ? 1 : 0) +
    (cruzamento21 == "Aa" ? 1 : 0) +
    (cruzamento22 == "Aa" ? 1 : 0)
) / 4;

percentualaa = 100 * (
    (cruzamento11 == "aa" ? 1 : 0) +
    (cruzamento12 == "aa" ? 1 : 0) +
    (cruzamento21 == "aa" ? 1 : 0) +
    (cruzamento22 == "aa" ? 1 : 0)
) / 4;

// Ajusta as mensagens a exibir conforme o tipo de dominância
if (dominancia == "C")
{
    descricaoAA = "não apresenta a característica recessiva";
    descricaoAa = "não apresenta a característica recessiva";
    descricaoaa = "apresenta a característica recessiva";
}
else
{
    descricaoAA = "apresenta a característica de `A`";
    descricaoAa = "apresenta característica distinta de `A` e de `a`";
    descricaoaa = "apresenta a característica de `a`";
}

// Exibe percentuais
Console.WriteLine();
Console.WriteLine($"AA: {percentualAA,3}% - {descricaoAA}");
Console.WriteLine($"Aa: {percentualAa,3}% - {descricaoAa}");
Console.WriteLine($"aa: {percentualaa,3}% - {descricaoaa}");

// Normaliza um alelo, colocando o "a" após o "A" (ex: "aA" vira "Aa")  
string NormalizaAlelo(string alelo)
{
    string alelo1 = alelo.Substring(0, 1);
    string alelo2 = alelo.Substring(1, 1);

    if (alelo1 == "a")
    {
        string auxiliar = alelo1;
        alelo1 = alelo2;
        alelo2 = auxiliar;
    }

    return $"{alelo1}{alelo2}";
}
