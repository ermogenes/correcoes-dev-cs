string[] tipos =
{
    "O Zumbi",
    "O Assassino",
    "O Psicopata",
    "O Alienígena",
    "O Carniceiro",
    "O Matador",
    "O Vampiro",
    "O Maluco",
    "O Vingador",
    "O Monstro",
    "O Bruxo",
    "O Demônio",
};

string[] variedades = {
    "Endiabrado",
    "Radioativo",
    "Endemoniado",
    "Vermelho",
    "Possuído",
    "Macabro",
    "Sombrio",
    "Sem Cabeça",
    "Desconhecido",
    "Inconsciente",
    "Oculto",
    "Esquecido",
    "Lúgubre",
    "Invocado",
    "Caído",
    "Costurado",
    "Amaldiçoado",
    "Anormal",
    "Perturbado",
    "Sanguinário",
    "Tenebroso",
    "Imortal",
    "Ressuscitado",
    "do Pântano",
    "da Encruzilhada",
    "do Porão",
    "do Velho Poço",
    "sem Perdão",
    "do Cemitério",
    "da Meia-Noite",
    "da Lua Cheia",
};

string tipo, variedade, monstro;
int mes, dia;

Console.WriteLine("--- Noite de Terror ---\n");

Console.Write("Qual o dia de nascimento da vítima (1 a 31): ");
dia = Convert.ToInt32(Console.ReadLine());

if (dia < 1 || dia > 31) return;

Console.Write("Qual o mês de nascimento da vítima (1 a 12): ");
mes = Convert.ToInt32(Console.ReadLine());

if (mes < 1 || mes > 12) return;

tipo = tipos[mes - 1];
variedade = variedades[dia - 1];
monstro = $"{tipo} {variedade}";

Console.WriteLine($"\nFuja! Lá vem {monstro}!");
