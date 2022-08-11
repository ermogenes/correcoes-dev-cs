Console.WriteLine("--- E-mail Corporativo / Projeto XYZ ---\n");

Console.Write("Digite o nome completo: ");
string nomeCompleto = Console.ReadLine()!;

string emailCorporativo = "";
int contador = 1;

var nomes = nomeCompleto.ToLower().Split();
foreach (var nome in nomes)
{
    if (contador == nomes.Length)
        emailCorporativo = String.Concat(emailCorporativo, nome);
    else if (nome.Length > 3)
        emailCorporativo = String.Concat(emailCorporativo, nome.Substring(0, 1));
    contador++;
}

emailCorporativo = String.Concat(emailCorporativo, "@projeto.xyz");

Console.WriteLine($"\nSugestão de e-mail corporativo: {emailCorporativo}");
