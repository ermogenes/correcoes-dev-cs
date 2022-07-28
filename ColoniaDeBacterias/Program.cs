const double PopulacaoInicial = 2000;

Console.WriteLine("--- Colônia de Bactérias ---\n");

Console.Write("Qual o número de indivíduos? ");
double numeroIndividuos = Convert.ToInt32(Console.ReadLine());

double tempo = 2 * Math.Log2(numeroIndividuos / PopulacaoInicial);

Console.WriteLine($"\nA colônia atingirá {numeroIndividuos:N0} indivíduos em {tempo:N1} horas.");
