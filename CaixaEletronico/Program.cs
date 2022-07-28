decimal valorSaque, valorRestante;
int notas200, notas100, notas50, notas20, notas10, notas5, notas2, notas1;

Console.WriteLine("--- Caixa Eletrônico ---\n");

Console.Write("Digite o valor a ser sacado...: ");
valorSaque = Convert.ToDecimal(Console.ReadLine());

if (valorSaque <= 0)
{
    Console.WriteLine("\nNão é possível realizar o saque.");
    return;
}

if (valorSaque % 1 > 0)
{
    Console.WriteLine("\nEste caixa não trabalha com moedas.");
    return;
}

valorRestante = valorSaque;

notas200 = (int)(valorRestante / 200);
valorRestante = valorRestante % 200;

notas100 = (int)(valorRestante / 100);
valorRestante = valorRestante % 100;

notas50 = (int)(valorRestante / 50);
valorRestante = valorRestante % 50;

notas20 = (int)(valorRestante / 20);
valorRestante = valorRestante % 20;

notas10 = (int)(valorRestante / 10);
valorRestante = valorRestante % 10;

notas5 = (int)(valorRestante / 5);
valorRestante = valorRestante % 5;

notas2 = (int)(valorRestante / 2);
valorRestante = valorRestante % 2;

notas1 = (int)(valorRestante / 1);
valorRestante = valorRestante % 1;

Console.WriteLine("\nO caixa deve entregar:");

if (notas200 > 0) Console.WriteLine($"{notas200} nota(s) de R$200,00");
if (notas100 > 0) Console.WriteLine($"{notas100} nota(s) de R$100,00");
if (notas50 > 0) Console.WriteLine($"{notas50} nota(s) de R$50,00");
if (notas20 > 0) Console.WriteLine($"{notas20} nota(s) de R$20,00");
if (notas10 > 0) Console.WriteLine($"{notas10} nota(s) de R$10,00");
if (notas5 > 0) Console.WriteLine($"{notas5} nota(s) de R$5,00");
if (notas2 > 0) Console.WriteLine($"{notas2} nota(s) de R$2,00");
if (notas1 > 0) Console.WriteLine($"{notas1} nota(s) de R$1,00");
