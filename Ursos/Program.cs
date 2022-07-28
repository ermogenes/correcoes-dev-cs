Console.WriteLine("--- Ursos ---\n");
Console.WriteLine("Digite um valor inválido para finalizar.");

double peso;
string sexo;

int qtd = 0, qtdMachos = 0, qtdFemeas = 0;

int qtdML = 0, qtdL = 0, qtdM = 0, qtdP = 0, qtdMP = 0;
int qtdMachosML = 0, qtdMachosL = 0, qtdMachosM = 0, qtdMachosP = 0, qtdMachosMP = 0;
int qtdFemeasML = 0, qtdFemeasL = 0, qtdFemeasM = 0, qtdFemeasP = 0, qtdFemeasMP = 0;

double percentualML = 0, percentualL = 0, percentualM = 0, percentualP = 0, percentualMP = 0;
double percentualMachos = 0, percentualMachosML = 0, percentualMachosL = 0, percentualMachosM = 0, percentualMachosP = 0, percentualMachosMP = 0;
double percentualFemeas = 0, percentualFemeasML = 0, percentualFemeasL = 0, percentualFemeasM = 0, percentualFemeasP = 0, percentualFemeasMP = 0;

string sexoMaiorPeso = "";
double maiorPeso = 0;

double somaPesos = 0, somaPesosMachos = 0, somaPesosFemeas = 0;
double mediaPeso, mediaPesoMachos = 0, mediaPesoFemeas = 0;

while (true)
{
    Console.WriteLine($"\n-- Urso #{qtd + 1} ---");

    Console.Write("Peso (até 250kg)...: ");
    peso = Convert.ToDouble(Console.ReadLine());

    if (peso <= 0 || peso > 250) break;

    Console.Write("Sexo (M/F).....: ");
    sexo = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

    if (sexo != "M" && sexo != "F") break;

    qtd++;

    switch (sexo)
    {
        case "M": qtdMachos++; somaPesosMachos += peso; break;
        case "F": qtdFemeas++; somaPesosFemeas += peso; break;
    }

    if (peso <= 50 && sexo == "M") qtdMachosML++;
    else if (peso <= 100 && sexo == "M") qtdMachosL++;
    else if (peso <= 150 && sexo == "M") qtdMachosM++;
    else if (peso <= 200 && sexo == "M") qtdMachosP++;
    else if (peso <= 250 && sexo == "M") qtdMachosMP++;
    else if (peso <= 50 && sexo == "F") qtdFemeasML++;
    else if (peso <= 100 && sexo == "F") qtdFemeasL++;
    else if (peso <= 150 && sexo == "F") qtdFemeasM++;
    else if (peso <= 200 && sexo == "F") qtdFemeasP++;
    else if (peso <= 250 && sexo == "F") qtdFemeasMP++;

    if (peso > maiorPeso)
    {
        maiorPeso = peso;
        sexoMaiorPeso = sexo;
    }
}

if (qtd == 0) return;

qtdML = qtdMachosML + qtdFemeasML;
qtdL = qtdMachosL + qtdFemeasL;
qtdM = qtdMachosM + qtdFemeasM;
qtdP = qtdMachosP + qtdFemeasP;
qtdMP = qtdMachosMP + qtdFemeasMP;

percentualML = (double)qtdML / qtd * 100;
percentualL = (double)qtdL / qtd * 100;
percentualM = (double)qtdM / qtd * 100;
percentualP = (double)qtdP / qtd * 100;
percentualMP = (double)qtdMP / qtd * 100;

percentualMachos = (double)qtdMachos / qtd * 100;
percentualFemeas = (double)qtdFemeas / qtd * 100;

somaPesos = somaPesosMachos + somaPesosFemeas;

mediaPeso = somaPesos / qtd;

if (qtdMachos > 0)
{
    percentualMachosML = (double)qtdMachosML / qtdMachos * 100;
    percentualMachosL = (double)qtdMachosL / qtdMachos * 100;
    percentualMachosM = (double)qtdMachosM / qtdMachos * 100;
    percentualMachosP = (double)qtdMachosP / qtdMachos * 100;
    percentualMachosMP = (double)qtdMachosMP / qtdMachos * 100;

    mediaPesoMachos = somaPesosMachos / qtdMachos;
}

if (qtdFemeas > 0)
{
    percentualFemeasML = (double)qtdFemeasML / qtdFemeas * 100;
    percentualFemeasL = (double)qtdFemeasL / qtdFemeas * 100;
    percentualFemeasM = (double)qtdFemeasM / qtdFemeas * 100;
    percentualFemeasP = (double)qtdFemeasP / qtdFemeas * 100;
    percentualFemeasMP = (double)qtdFemeasMP / qtdFemeas * 100;

    mediaPesoFemeas = somaPesosFemeas / qtdFemeas;
}

Console.WriteLine($"\nUrso mais pesado: {maiorPeso} ({sexoMaiorPeso})");
Console.WriteLine($"Pesos médios: \n\tMachos = {mediaPesoMachos:N1}\n\tFêmeas = {mediaPesoFemeas:N1}\n\tGeral  = {mediaPeso:N1}\n");

Console.WriteLine("Categoria       Ursos    Ursos (%)    Machos   Machos (%)    Fêmeas  Fêmeas (%)");
Console.WriteLine("".PadLeft(79, '-'));
Console.WriteLine($"{"ML",-10} {qtdML,10} {percentualML,10:N1}% {qtdMachosML,10} {percentualMachosML,10:N1}% {qtdFemeasML,10} {percentualFemeasML,10:N1}%");
Console.WriteLine($"{"L",-10} {qtdL,10} {percentualL,10:N1}% {qtdMachosL,10} {percentualMachosL,10:N1}% {qtdFemeasL,10} {percentualFemeasL,10:N1}%");
Console.WriteLine($"{"M",-10} {qtdM,10} {percentualM,10:N1}% {qtdMachosM,10} {percentualMachosM,10:N1}% {qtdFemeasM,10} {percentualFemeasM,10:N1}%");
Console.WriteLine($"{"P",-10} {qtdP,10} {percentualP,10:N1}% {qtdMachosP,10} {percentualMachosP,10:N1}% {qtdFemeasP,10} {percentualFemeasP,10:N1}%");
Console.WriteLine($"{"MP",-10} {qtdMP,10} {percentualMP,10:N1}% {qtdMachosMP,10} {percentualMachosMP,10:N1}% {qtdFemeasMP,10} {percentualFemeasMP,10:N1}%");
Console.WriteLine("".PadLeft(79, '-'));
Console.WriteLine($"{"Total",-10} {qtd,10} {100,10}% {qtdMachos,10} {percentualMachos,10:N1}% {qtdFemeas,10} {percentualFemeas,10:N1}%");

Console.WriteLine("\n----- Ursos Machos -----");
Console.WriteLine("   +...10...20...30...40...50...60...70...80...90..100");
Console.WriteLine($"ML |{"".PadRight((int)percentualMachosML / 2, '*')}");
Console.WriteLine($"L  |{"".PadRight((int)percentualMachosL / 2, '*')}");
Console.WriteLine($"M  |{"".PadRight((int)percentualMachosM / 2, '*')}");
Console.WriteLine($"P  |{"".PadRight((int)percentualMachosP / 2, '*')}");
Console.WriteLine($"MP |{"".PadRight((int)percentualMachosMP / 2, '*')}");

Console.WriteLine("\n----- Ursos Femeas -----");
Console.WriteLine("   +...10...20...30...40...50...60...70...80...90..100");
Console.WriteLine($"ML |{"".PadRight((int)percentualFemeasML / 2, '*')}");
Console.WriteLine($"L  |{"".PadRight((int)percentualFemeasL / 2, '*')}");
Console.WriteLine($"M  |{"".PadRight((int)percentualFemeasM / 2, '*')}");
Console.WriteLine($"P  |{"".PadRight((int)percentualFemeasP / 2, '*')}");
Console.WriteLine($"MP |{"".PadRight((int)percentualFemeasMP / 2, '*')}");

Console.WriteLine("\n----- Ursos (todos) -----");
Console.WriteLine("   +...10...20...30...40...50...60...70...80...90..100");
Console.WriteLine($"ML |{"".PadRight((int)percentualML / 2, '*')}");
Console.WriteLine($"L  |{"".PadRight((int)percentualL / 2, '*')}");
Console.WriteLine($"M  |{"".PadRight((int)percentualM / 2, '*')}");
Console.WriteLine($"P  |{"".PadRight((int)percentualP / 2, '*')}");
Console.WriteLine($"MP |{"".PadRight((int)percentualMP / 2, '*')}");
