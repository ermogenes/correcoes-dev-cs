Console.WriteLine("--- Ano Bissexto ---\n");

Console.Write("Digite um ano...: ");
int ano = Convert.ToInt32(Console.ReadLine());

bool divisivelPor400 = ano % 400 == 0;
bool divisivelPor100 = ano % 100 == 0;
bool divisivelPor4 = ano % 4 == 0;

if (divisivelPor400 || (divisivelPor4 && !divisivelPor100))
{
    Console.WriteLine($"\n{ano} é bissexto.");
}
else
{
    Console.WriteLine($"\n{ano} não é bissexto.");
}
