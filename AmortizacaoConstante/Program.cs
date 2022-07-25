Console.WriteLine("--- Tabela SAC ---\n");

Console.Write("Principal (em R$)..: ");
decimal principal = Convert.ToDecimal(Console.ReadLine());

Console.Write("Períodos...........: ");
int periodos = Convert.ToInt32(Console.ReadLine());

Console.Write("Taxa (em %)........: ");
double taxa = Convert.ToDouble(Console.ReadLine());

decimal amortizacao = principal / periodos;
decimal juros, prestacao, valorPago, saldoDevedor;

int periodo = 0;
saldoDevedor = principal;
valorPago = 0;

Console.WriteLine();
Console.WriteLine($"{"Período",-18} {"Amortização",-18} {"Juros",-18} {"Prestação",-18} {"Valor Pago",-18} {"Saldo Devedor",-18}");

while (periodo <= periodos)
{
    if (periodo == 0)
    {
        Console.WriteLine($"{periodo,-18:N0} {"",-18} {"",-18} {"",-18} {"",-18} {saldoDevedor,-18:C}");
    }
    else
    {
        juros = saldoDevedor * Convert.ToDecimal(taxa / 100);
        prestacao = amortizacao + juros;
        valorPago += prestacao;
        saldoDevedor -= amortizacao;
        Console.WriteLine($"{periodo,-18:N0} {amortizacao,-18:C} {juros,-18:C} {prestacao,-18:C} {valorPago,-18:C} {saldoDevedor,-18:C}");
    }
    periodo++;
}
