Console.WriteLine("--- Fintech ---\n");

var joao = new Conta("João", 0);
var maria = new Conta("Maria", 1000);

Console.WriteLine($"Saldo (João): {joao.Saldo:C2}\t\t (Maria): {maria.Saldo:C2}");
Console.WriteLine("\nUsuário atual: João");
Console.WriteLine("[E]xtrato | [D]epósito] | [P]agamento via Pix | [S]air");

string opcao = "";
while (opcao != "S")
{
    try
    {
        Console.Write("\nOpção desejada: ");
        opcao = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

        switch (opcao)
        {
            case "D":
                Console.Write("Valor a depositar em sua conta: ");
                joao.Depositar(Convert.ToDecimal(Console.ReadLine()));
                Console.WriteLine($"Saldo (João): {joao.Saldo:C2}\t\t (Maria): {maria.Saldo:C2}");
                break;

            case "P":
                Console.Write("Valor a pagar via Pix para Maria: ");
                joao.PagarViaPix(Convert.ToDecimal(Console.ReadLine()), maria);
                Console.WriteLine($"Saldo (João): {joao.Saldo:C2}\t\t (Maria): {maria.Saldo:C2}");
                break;

            case "E":
                ExibirExtrato(joao);
                break;
        }
    }
    catch (System.Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void ExibirExtrato(Conta conta)
{
    Console.WriteLine($"--- Extrato de {conta.Titular} ---");
    foreach (var entrada in conta.Extrato)
        Console.WriteLine(entrada);
    Console.WriteLine($"Saldo atual: {conta.Saldo:C2}");
}

class Conta
{
    public string Titular { get; private set; }
    public decimal Saldo { get; private set; }
    public List<string> Extrato { get; private set; }

    public Conta(string titular, decimal saldoInicial)
    {
        if (string.IsNullOrEmpty(titular))
            throw new ArgumentException("Titular inválido.");

        if (saldoInicial < 0)
            throw new ArgumentException("Saldo inicial inválido.");

        Titular = titular;
        Saldo = saldoInicial;
        Extrato = new();

        RegistrarOperacao("Abertura", saldoInicial, DateTime.Now);
    }

    private void RegistrarOperacao(string operacao, decimal valor, DateTime dataHora)
    {
        Extrato.Add($"{dataHora,20} {valor,20:C2} {operacao}");
    }
    public void Depositar(decimal valorADepositar)
    {
        if (valorADepositar <= 0)
            throw new ArgumentException("Valor inválido.");

        Saldo += valorADepositar;
        RegistrarOperacao("Depósito", valorADepositar, DateTime.Now);
    }
    protected void ReceberViaPix(decimal valorAReceber, Conta remetente)
    {
        if (valorAReceber <= 0)
            throw new ArgumentException("Valor inválido.");

        Saldo += valorAReceber;
        RegistrarOperacao($"Recebimento via Pix de {remetente.Titular}", valorAReceber, DateTime.Now);
    }
    public void PagarViaPix(decimal valorAPagar, Conta favorecido)
    {
        if (valorAPagar <= 0)
            throw new ArgumentException("Valor inválido.");

        if (valorAPagar > Saldo)
            throw new ArgumentException("Saldo insuficiente.");

        Saldo -= valorAPagar;
        RegistrarOperacao($"Pagamento via Pix para {favorecido.Titular}", -valorAPagar, DateTime.Now);

        favorecido.ReceberViaPix(valorAPagar, this);
    }
}
