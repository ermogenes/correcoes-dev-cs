string opcaoDesejada = "";

while (opcaoDesejada != "S")
{
    Console.Clear();

    Console.WriteLine("--- Calculadora com Quatro Operações ---\n");

    Console.WriteLine("[+] Soma");
    Console.WriteLine("[-] Subtração");
    Console.WriteLine("[*] Multiplicação");
    Console.WriteLine("[/] Divisão");
    Console.WriteLine("\n[S]air");

    Console.Write("\nSelecione a operação desejada: ");

    opcaoDesejada = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

    switch (opcaoDesejada)
    {
        case "+":
            CalcularSoma();
            break;
        case "-":
            CalcularSubtracao();
            break;
        case "*":
            CalcularMultiplicacao();
            break;
        case "/":
            CalcularDivisao();
            break;
        case "S":
            break;
        default:
            Console.WriteLine("\nOpção inválida.\nPressione uma tecla para continuar...");
            Console.ReadKey();
            break;
    }
}

Console.WriteLine("\nObrigado por utilizar nosso programa.");


void CalcularSoma()
{
    double a, b, resultado;

    Console.WriteLine("\n--- Soma A+B ---\n");
    Console.WriteLine("Digite os valores.");

    Console.Write("A = ");
    a = Convert.ToDouble(Console.ReadLine());
    Console.Write("B = ");
    b = Convert.ToDouble(Console.ReadLine());

    resultado = a + b;

    Console.WriteLine($"{a} somado com {b} é {resultado}");

    Console.Write("\nPressione uma tecla para continuar...");
    Console.ReadKey();

    return;
}

void CalcularSubtracao()
{
    double a, b, resultado;

    Console.WriteLine("\n--- Subtração A-B ---\n");
    Console.WriteLine("Digite os valores.");

    Console.Write("A = ");
    a = Convert.ToDouble(Console.ReadLine());
    Console.Write("B = ");
    b = Convert.ToDouble(Console.ReadLine());

    resultado = a - b;

    Console.WriteLine($"{a} subtraindo {b} é {resultado}");

    Console.Write("\nPressione uma tecla para continuar...");
    Console.ReadKey();

    return;
}

void CalcularMultiplicacao()
{
    double a, b, resultado;

    Console.WriteLine("\n--- Multiplicação A*B ---\n");
    Console.WriteLine("Digite os valores.");

    Console.Write("A = ");
    a = Convert.ToDouble(Console.ReadLine());
    Console.Write("B = ");
    b = Convert.ToDouble(Console.ReadLine());

    resultado = a * b;

    Console.WriteLine($"{a} multiplicado por {b} é {resultado}");

    Console.Write("\nPressione uma tecla para continuar...");
    Console.ReadKey();

    return;
}

void CalcularDivisao()
{
    double a, b, resultado;

    Console.WriteLine("\n--- Divisão A/B ---\n");
    Console.WriteLine("Digite os valores.");

    Console.Write("A = ");
    a = Convert.ToDouble(Console.ReadLine());
    Console.Write("B = ");
    b = Convert.ToDouble(Console.ReadLine());

    if (b == 0)
    {
        Console.WriteLine("\nNão é possível dividir por zero.");
    }
    else
    {
        resultado = a / b;

        Console.WriteLine($"{a} dividido por {b} é {resultado}");
    }

    Console.Write("\nPressione uma tecla para continuar...");
    Console.ReadKey();

    return;
}
