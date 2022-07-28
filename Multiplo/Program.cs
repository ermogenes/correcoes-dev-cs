Console.WriteLine("--- Múltiplo ---\n");

Console.Write("Digite um número...........: ");
int n1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Avaliar se é múltiplo de...: ");
int n2 = Convert.ToInt32(Console.ReadLine());

if (n1 % n2 == 0)
{
    Console.WriteLine($"\n{n1} é múltiplo de {n2}");
}
else
{
    Console.WriteLine($"\n{n1} não é múltiplo de {n2}");
}
