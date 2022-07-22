Console.WriteLine("--- Maior De Três ---\n");

Console.Write("Digite o primeiro número...: ");
int n1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Digite o segundo número....: ");
int n2 = Convert.ToInt32(Console.ReadLine());

Console.Write("Digite o terceiro número...: ");
int n3 = Convert.ToInt32(Console.ReadLine());

int maiorNumero;

if (n1 > n2)
{
    if (n1 > n3)
    {
        maiorNumero = n1;
    }
    else
    {
        maiorNumero = n3;
    }
}
else
{
    if (n2 > n3)
    {
        maiorNumero = n2;
    }
    else
    {
        maiorNumero = n3;
    }
}

Console.WriteLine($"\nMaior número: {maiorNumero}");
