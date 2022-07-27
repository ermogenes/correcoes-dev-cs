using System.Security.Cryptography;

string[] nomes =
{
    "Maria",
    "Ana",
    "Vitória",
    "Julia",
    "Letícia",
    "Amanda",
    "Beatriz",
    "Larissa",
    "Gabriela",
    "Mariana",
    "João",
    "Gabriel",
    "Lucas",
    "Pedro",
    "Mateus",
    "José",
    "Gustavo",
    "Guilherme",
    "Carlos",
    "Vitor",
};

string[] sobrenomes = {
    "Almeida",
    "Alves",
    "Andrade",
    "Barbosa",
    "Barros",
    "Batista",
    "Borges",
    "Campos",
    "Cardoso",
    "Carvalho",
    "Castro",
    "Costa",
    "Dias",
    "Duarte",
    "Freitas",
    "Fernandes",
    "Ferreira",
    "Garcia",
    "Gomes",
    "Gonçalves",
    "Lima",
    "Lopes",
    "Machado",
    "Marques",
    "Martins",
    "Medeiros",
    "Melo",
    "Mendes",
    "Miranda",
    "Monteiro",
    "Moraes",
    "Moreira",
    "Moura",
    "Nascimento",
    "Nunes",
    "Oliveira",
    "Pereira",
    "Ramos",
    "Reis",
    "Ribeiro",
    "Rocha",
    "Santana",
    "Santos",
    "Silva",
    "Soares",
    "Souza",
    "Teixeira",
    "Vieira",
};

string[] nomesCompletos = new string[5];

for (int i = 0; i < nomesCompletos.Length; i++)
{
    string nome = nomes[RandomNumberGenerator.GetInt32(0, nomes.Length)];
    string sobrenome = sobrenomes[RandomNumberGenerator.GetInt32(0, sobrenomes.Length)];
    nomesCompletos[i] = $"{nome} {sobrenome}";
}

Console.WriteLine("--- Gerador de Nomes ---\n");

foreach (var nome in nomesCompletos)
{
    Console.WriteLine(nome);
}
