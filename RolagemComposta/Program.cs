string rolagem, dados, faces, bonus;

Console.WriteLine("--- Rolagem de Dados ---\n");

Console.Write("Digite a rolagem desejada...: ");
rolagem = Console.ReadLine()!.Trim();

// Começando do início, até a posição de "d"
dados = rolagem.Substring(0, rolagem.IndexOf("d"));

// Da primeira posição após "d", quantos caracteres houverem entre as posições "d" e "+"
faces = rolagem.Substring(rolagem.IndexOf("d") + 1, rolagem.IndexOf("+") - rolagem.IndexOf("d") - 1);

// Da posição após "+" até o final
bonus = rolagem.Substring(rolagem.IndexOf("+") + 1);

Console.WriteLine($"\n{dados} dado(s) de {faces} face(s) mais {bonus}");
