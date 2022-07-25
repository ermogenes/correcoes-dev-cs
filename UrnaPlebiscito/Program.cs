const string SegredoParaFechamentoDaUrna = "s234f$WR";
int votosSim = 0, votosNao = 0, abstencoes = 0, totalVotos = 0;

string comandoMesario = "";
while (comandoMesario != SegredoParaFechamentoDaUrna)
{
    // Menu do mesário
    Console.Clear();
    Console.WriteLine("--- Urna Eletrônica ---\n");

    Console.Write("Aguarde a intervenção do mesário... ");
    comandoMesario = Console.ReadLine()!;

    if (comandoMesario.ToUpper() == "P")
    {
        // Voto liberado
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Urna Eletrônica ---\n");

            Console.WriteLine("Plebiscito: Você é a favor da proibição do uso de boné em sala de aula?\n");

            Console.WriteLine("    S - Sim, sou a favor");
            Console.WriteLine("    N - Não, sou contra");
            Console.WriteLine("    A - Me abstenho de responder");

            Console.Write("\nDigite a opção desejada e pressione [ENTER]: ");
            string voto = Console.ReadLine()!.Trim().PadLeft(1, ' ').Substring(0, 1).ToUpper();

            string textoVoto = "";
            // Validação e Contagem
            switch (voto)
            {
                case "S":
                    votosSim++;
                    textoVoto = "Sim, sou a favor";
                    break;
                case "N":
                    votosNao++;
                    textoVoto = "Não, sou contra";
                    break;
                case "A":
                    abstencoes++;
                    textoVoto = "Me abstenho de responder";
                    break;
                default:
                    // Opção inválida, refaz votação do mesmo eleitor
                    continue;
            }

            // Votação válida, segue para o próximo eleitor 
            totalVotos++;
            Console.WriteLine($"\nVocê votou \"{textoVoto}\"");
            Console.Write("\nPressione uma tecla para finalizar sua votação...");
            Console.ReadKey();
            break;
        }
    }
}

// Se ninguém votou, finaliza o programa
if (totalVotos == 0) return;

// Calcula resultado
double percentualGeralSim = (double)votosSim / totalVotos * 100;
double percentualGeralNao = (double)votosNao / totalVotos * 100;
double percentualGeralAbstencoes = (double)abstencoes / totalVotos * 100;
double votosValidos = votosSim + votosNao;
double percentualVotosValidos = votosValidos / totalVotos * 100;

string resultado;
ConsoleColor corExibicao;
if (votosValidos <= (totalVotos / 2)) // Válidos devem ser maioria simples
{
    resultado = "INDETERMINADO";
    corExibicao = ConsoleColor.Yellow;
}
else if (votosSim > votosNao) // Empate é "REPROVADO"
{
    resultado = "APROVADO";
    corExibicao = ConsoleColor.Green;
}
else
{
    resultado = "REPROVADO";
    corExibicao = ConsoleColor.Red;
}

// Exibe resultado
Console.Clear();
Console.WriteLine("--- Urna Eletrônica ---\n");
Console.WriteLine("Plebiscito: Você é a favor da proibição do uso de boné em sala de aula?\n");
Console.WriteLine($"Finalizado com o total de {totalVotos} voto(s).\n");

Console.WriteLine("Contagem de votos:");
Console.WriteLine($"S - Sim, sou a favor         - {votosSim} ({percentualGeralSim:N1}%)");
Console.WriteLine($"N - Não, sou contra          - {votosNao} ({percentualGeralNao:N1}%)");
Console.WriteLine($"A - Me abstenho de responder - {abstencoes} ({percentualGeralAbstencoes:N1}%)");

Console.WriteLine($"\nVotos válidos: {votosValidos} ({percentualVotosValidos:N1}%)");

Console.Write("\nResultado do plebiscito: ");
Console.ForegroundColor = corExibicao;
Console.WriteLine(resultado);
Console.ResetColor();
