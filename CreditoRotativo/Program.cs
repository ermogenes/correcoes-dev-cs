const double TaxaIOFMes = 0.0038;
const double TaxaIOFDia = 0.000082;

decimal totalFatura, valorPagamentoMinimo, valorNaoPago;
decimal valorJuros, valorIOFMes, valorIOFDia, valorProximaFatura, custoRotativo;
double pagamentoMinimo, taxaJuros;

Console.WriteLine("--- Crédito Rotativo de Cartão de Crédito ---\n");

Console.Write("Valor total da fatura (R$)...: ");
totalFatura = Convert.ToDecimal(Console.ReadLine());

Console.Write("Pagamento mínimo (%).........: ");
pagamentoMinimo = Convert.ToDouble(Console.ReadLine()) / 100;

Console.Write("Taxa de juros mensais (%)....: ");
taxaJuros = Convert.ToDouble(Console.ReadLine()) / 100;

valorPagamentoMinimo = totalFatura * Convert.ToDecimal(pagamentoMinimo);

valorNaoPago = totalFatura - valorPagamentoMinimo;
valorJuros = valorNaoPago * Convert.ToDecimal(taxaJuros);
valorIOFMes = valorNaoPago * Convert.ToDecimal(TaxaIOFMes);
valorIOFDia = valorNaoPago * Convert.ToDecimal(TaxaIOFDia * 30);

valorProximaFatura = valorNaoPago + valorJuros + valorIOFMes + valorIOFDia;
custoRotativo = valorProximaFatura - valorNaoPago;

Console.WriteLine($"\nPagamento mínimo..................: {valorPagamentoMinimo:C}");

Console.WriteLine("\nCaso seja pago o valor mínimo:\n");

Console.WriteLine($"Valor não pago....................: {valorNaoPago:C}");
Console.WriteLine($"Juros.............................: {valorJuros:C}");
Console.WriteLine($"IOF mensal........................: {valorIOFMes:C}");
Console.WriteLine($"IOF diário........................: {valorIOFDia:C}");

Console.WriteLine($"\nValor a pagar na próxima fatura...: {valorProximaFatura:C}");
Console.WriteLine($"Custo do crédito rotativo.........: {custoRotativo:C}");
