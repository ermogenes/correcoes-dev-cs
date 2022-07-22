Console.WriteLine("--- Horas Decimais ---\n");

Console.Write("Quantidade de horas...: ");
double horas = Convert.ToDouble(Console.ReadLine());

double horasInteiras = (int)horas;
double horasParteDecimal = horas % 1;

double minutosRestantes = horasParteDecimal * 60;

double minutosInteiros = (int)minutosRestantes;
double minutosParteDecimal = minutosRestantes % 1;

double segundosRestantes = minutosParteDecimal * 60;

Console.WriteLine($"\n{horasInteiras}h {minutosInteiros}min {segundosRestantes:N2}s");
