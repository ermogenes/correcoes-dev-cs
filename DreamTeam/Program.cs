Console.WriteLine("--- Time dos Sonhos da NBA ---\n");

string[] top = {
    "Michael Jordan (Armador)",
    "LeBron James (Ala)",
    "Kareem Abdul Jabbar (Pivô)",
    "Magic Johnson (Armador)",
    "Wilt Chamberlain (Pivô)",
    "Bill Russell (Pivô)",
    "Larry Bird (Ala)",
    "Tim Duncan (Ala-pivô)",
    "Oscar Robertson (Armador)",
    "Kobe Bryant (Armador)",
    "Shaquille O\'Neal (Pivô)",
    "Kevin Durant (Ala)",
    "Hakeem Olajuwon (Pivô)",
    "Julius Erving (Ala)",
    "Moses Malone (Pivô)",
    "Stephen Curry (Armador)",
    "Dirk Nowitzki (Ala-pivô)",
    "Giannis Antetokounmpo (Ala-pivô)",
    "Jerry West (Armador)",
    "Elgin Baylor (Ala)",
};

int[] time = new int[5];

Console.WriteLine("Top 20 jogadores:\n");
for (int i = 0; i < 20; i++)
{
    Console.WriteLine($"\t{i + 1,2} - {top[i]}");
}

Console.WriteLine();

for (int i = 0; i < 5; i++)
{
    while (true)
    {
        Console.Write($"{i} jogador(es) selecionados. Adicionar o Top # ");
        int selecionado = Convert.ToInt32(Console.ReadLine());

        selecionado--;

        if (selecionado < 0 || selecionado >= 20)
        {
            Console.WriteLine("Entrada inválida.");
            continue;
        }

        bool jaSelecionado = false;
        for (int anterior = 0; anterior < i; anterior++)
        {
            jaSelecionado = time[anterior] == selecionado;
            if (jaSelecionado) break;
        }

        if (jaSelecionado)
        {
            Console.WriteLine("Atleta já incluído no seu time.");
            continue;
        }

        time[i] = selecionado;
        break;
    }
}

Array.Sort(time);

Console.WriteLine("\nSeu time dos sonhos é:\n");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"\t{time[i] + 1,2} - {top[time[i]]}");
}
