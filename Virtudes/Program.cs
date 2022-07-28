using System.Security.Cryptography;

string[] virtudes =
{
    "a polidez",
    "a fidelidade",
    "a prudência",
    "a temperança",
    "a coragem",
    "a justiça",
    "a generosidade",
    "a compaixão",
    "a misericórdia",
    "a gratidão",
    "a humildade",
    "a simplicidade",
    "a tolerância",
    "a pureza",
    "a doçura",
    "a boa-fé",
    "o humor",
    "o amor",
};

string virtude1 = "", virtude2 = "", virtude3 = "";

virtude1 = virtudes[RandomNumberGenerator.GetInt32(0, virtudes.Length)];

while (virtude2 == "" || virtude2 == virtude1)
    virtude2 = virtudes[RandomNumberGenerator.GetInt32(0, virtudes.Length)];

while (virtude3 == "" || virtude3 == virtude2 || virtude3 == virtude1)
    virtude3 = virtudes[RandomNumberGenerator.GetInt32(0, virtudes.Length)];

Console.WriteLine("--- Conselho do Dia ---\n");
Console.WriteLine($"Pratique {virtude1} e cultive {virtude2}, sem esperar em troca {virtude3}.");
