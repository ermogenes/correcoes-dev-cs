Console.WriteLine("--- Distância Percorrida ---\n");

int[,] distancias =
{
    { 0, 434, 586, 524 },
    { 434, 0, 429, 521 },
    { 586, 429, 0, 882 },
    { 524, 521, 882, 0 },
};

string[] cidades =
{
    "Belo Horizonte",
    "Rio de Janeiro",
    "São Paulo",
    "Vitória",
};

for (int i = 0; i < 4; i++)
{
    Console.WriteLine($"{i} = {cidades[i]}");
}

Console.Write("\nDigite o percurso (ex.: 1,2,0,1): ");
string[] cidadesIndicadas = Console.ReadLine()!.Split(",");

int tamanhoPercurso = cidadesIndicadas.Length;

int[] percurso = new int[tamanhoPercurso];

for (int i = 0; i < tamanhoPercurso; i++)
{
    percurso[i] = Convert.ToInt32(cidadesIndicadas[i]);
    if (percurso[i] < 0 || percurso[i] > 3)
    {
        Console.WriteLine($"Entrada inválida: {percurso[i]}");
        return;
    }
}

Console.WriteLine();

int distanciaPercorrida = 0;
for (int i = 1; i < tamanhoPercurso; i++)
{
    int origem = percurso[i - 1];
    int destino = percurso[i];
    int distanciaTrecho = distancias[origem, destino];
    distanciaPercorrida += distanciaTrecho;

    Console.WriteLine($"{distanciaTrecho,3}km de {cidades[origem]} a {cidades[destino]}");
}

Console.WriteLine($"\n{distanciaPercorrida}km percorridos.");
