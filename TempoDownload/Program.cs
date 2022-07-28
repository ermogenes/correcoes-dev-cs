double tamanhoBytes, velocidadeMbps, tempoMin;

Console.WriteLine("--- Tempo de Download ---\n");

Console.Write("Tamanho do arquivo em MB........: ");
tamanhoBytes = Convert.ToDouble(Console.ReadLine());

Console.Write("Velocidade da conexão em Mbps...: ");
velocidadeMbps = Convert.ToDouble(Console.ReadLine());

tempoMin = tamanhoBytes * 8 / velocidadeMbps / 60;

Console.WriteLine($"\nTempo estimado de download: {tempoMin:N1} minutos");
