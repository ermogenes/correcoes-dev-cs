string ginasta;
double notaPartida, notaExecucao, notaFinal;

Console.WriteLine("--- Ginástica Artística ---\n");

Console.Write("Ginasta............: ");
ginasta = Console.ReadLine()!;

Console.Write("Nota de Partida....: ");
notaPartida = Convert.ToDouble(Console.ReadLine());

Console.Write("Nota de Execução...: ");
notaExecucao = Convert.ToDouble(Console.ReadLine());

notaFinal = notaPartida + notaExecucao;

Console.WriteLine($"\nA nota de {ginasta} foi {notaFinal:N3}.");
