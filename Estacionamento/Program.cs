const decimal PrecoPrimeiraHora = 20;
const decimal PrecoHoraPequeno = 10;
const decimal PrecoHoraGrande = 20;
const decimal PrecoDiariaPequeno = 50;
const decimal PrecoDiariaGrande = 80;
const double AdicionalValet = 0.2;
const decimal PrecoLavagemPequeno = 50;
const decimal PrecoLavagemGrande = 100;

const int TempoDiaria = 5 * 60;
const int TempoTolerancia = 5;
const int MaxTempoPermanencia = 12 * 60;

int tempoPermanencia;
string tamanho;
bool valet, lavagem;

decimal parcialEstacionamento = 0;
decimal parcialValet = 0;
decimal parcialLavagem = 0;
decimal total = 0;

Console.WriteLine("--- Estacionamento ---\n");

Console.Write("Tamanho do veículo (P/G).....: ");
tamanho = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if (tamanho != "P" && tamanho != "G")
{
    Console.WriteLine("Tamanho inválido.");
    return;
}

Console.Write("Tempo de permanência (min)...: ");
tempoPermanencia = Convert.ToInt32(Console.ReadLine());

if (tempoPermanencia <= 0 || tempoPermanencia > MaxTempoPermanencia)
{
    Console.WriteLine("Tempo de permanência inválido.");
    return;
}

Console.Write("Serviço de valet (S/N).......: ");
valet = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

Console.Write("Serviço de lavagem (S/N).....: ");
lavagem = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

if (tempoPermanencia >= TempoDiaria)
{
    if (tamanho == "P")
    {
        parcialEstacionamento = PrecoDiariaPequeno;
    }
    else
    {
        parcialEstacionamento = PrecoDiariaGrande;
    }
}
else
{
    int horasPermanencia = (int)(tempoPermanencia / 60);
    int minutosRestantes = tempoPermanencia % 60;

    if (minutosRestantes > TempoTolerancia)
    {
        horasPermanencia++;
    }

    parcialEstacionamento = PrecoPrimeiraHora;
    int horasAdicionais = horasPermanencia - 1;

    if (horasAdicionais > 0)
    {
        if (tamanho == "P")
        {
            parcialEstacionamento += horasAdicionais * PrecoHoraPequeno;
        }
        else
        {
            parcialEstacionamento += horasAdicionais * PrecoHoraGrande;
        }
    }
}

if (valet)
{
    parcialValet = parcialEstacionamento * Convert.ToDecimal(AdicionalValet);
}

if (lavagem)
{
    if (tamanho == "P")
    {
        parcialLavagem += PrecoLavagemPequeno;
    }
    else
    {
        parcialLavagem += PrecoLavagemGrande;
    }
}

total = parcialEstacionamento + parcialValet + parcialLavagem;

Console.WriteLine($"\nEstacionamento..: {parcialEstacionamento,14:C}");
Console.WriteLine($"Valet...........: {parcialValet,14:C}");
Console.WriteLine($"Lavagem.........: {parcialLavagem,14:C}");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Total...........: {total,14:C}");
