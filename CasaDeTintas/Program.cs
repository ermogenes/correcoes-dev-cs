const double CapacidadeLata = 18;
const double CapacidadeGalao = 3.6;

const double MargemErro = 0.1;
const double Rendimento = 3;

double area, tinta, tintaEmLatas, tintaEmGaloes;
int latas, galoes;

Console.WriteLine("--- Casa de Tintas ---\n");

Console.Write("Área a ser pintada (m²)...: ");
area = Convert.ToDouble(Console.ReadLine());

tinta = area / Rendimento;
tinta += tinta * MargemErro;

Console.WriteLine($"\nTotal de {tinta:N1} litro(s) de tinta.\n");

latas = (int)(tinta / CapacidadeLata);
tintaEmLatas = latas * CapacidadeLata;

galoes = (int)((tinta - tintaEmLatas) / CapacidadeGalao);
tintaEmGaloes = galoes * CapacidadeGalao;

if (tinta - tintaEmLatas - tintaEmGaloes > 0)
{
    galoes++;
}

Console.WriteLine("Distribuição:");
Console.WriteLine($"Latas...: {latas:N0} unidade(s)");
Console.WriteLine($"Galões..: {galoes:N0} unidade(s)");
