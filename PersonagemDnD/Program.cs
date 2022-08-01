using System.Security.Cryptography;
using System.Linq;

Console.WriteLine("--- Gerador de Personagem para D&D Quinta Edição ---");

List<int> atributos = new();

bool efetuarRolagem = true;
while (efetuarRolagem)
{
    Console.WriteLine("\nRolagens (método 4d6 drop lowest):");

    atributos.Clear();
    while (atributos.Count() < 6)
    {
        int[] rolagens = new int[4];
        for (int i = 0; i < 4; i++)
        {
            rolagens[i] = RandomNumberGenerator.GetInt32(1, 7);
            Console.Write($"{rolagens[i]}, ");
        }

        Array.Sort(rolagens);

        int somaRolagensMantidas = rolagens.Skip(1).Sum();
        Console.WriteLine($"descartado o valor {rolagens.First()}");

        atributos.Add(somaRolagensMantidas);
    }

    int somaAtributos = atributos.Sum();
    if (somaAtributos >= 75)
    {
        Console.WriteLine($"\nA soma das rolagens mantidas é {somaAtributos}, portanto não é necessário re-rolar.");
        break;
    }
    Console.WriteLine($"\nA soma das rolagens mantidas é {somaAtributos}, portanto é necessário re-rolar.");
}

var p = new Personagem(atributos);

Console.WriteLine();
Console.WriteLine($"STR: {p.Str,2} ({(p.StrMod < 0 ? p.StrMod : String.Concat("+", p.StrMod))})");
Console.WriteLine($"DEX: {p.Dex,2} ({(p.DexMod < 0 ? p.DexMod : String.Concat("+", p.DexMod))})");
Console.WriteLine($"CON: {p.Con,2} ({(p.ConMod < 0 ? p.ConMod : String.Concat("+", p.ConMod))})");
Console.WriteLine($"INT: {p.Int,2} ({(p.IntMod < 0 ? p.IntMod : String.Concat("+", p.IntMod))})");
Console.WriteLine($"WIS: {p.Wis,2} ({(p.WisMod < 0 ? p.WisMod : String.Concat("+", p.WisMod))})");
Console.WriteLine($"CHA: {p.Cha,2} ({(p.ChaMod < 0 ? p.ChaMod : String.Concat("+", p.ChaMod))})");
Console.WriteLine();

Console.WriteLine(p.DescricaoAtributosLimite);

class Personagem
{
    public int Str { get; private set; }
    public int Dex { get; private set; }
    public int Con { get; private set; }
    public int Int { get; private set; }
    public int Wis { get; private set; }
    public int Cha { get; private set; }

    public int StrMod { get; private set; }
    public int DexMod { get; private set; }
    public int ConMod { get; private set; }
    public int IntMod { get; private set; }
    public int WisMod { get; private set; }
    public int ChaMod { get; private set; }

    public string DescricaoAtributosLimite { get; private set; }

    private List<string> NomesMaioresAtributos = new();
    private List<string> NomesMenoresAtributos = new();

    public Personagem(List<int> atributosIniciais)
    {
        atribuirValoresDeAtributos(atributosIniciais);
        DescricaoAtributosLimite = obterDescricaoAtributosLimite();
    }

    private void atribuirValoresDeAtributos(List<int> valores)
    {
        if (valores.Count() != 6)
            throw new ArgumentException("Deve conter exatamente 6 atributos.");

        if (valores.Any(v => v < 3 || v > 18))
            throw new ArgumentException("Valores somente entre 3 e 18.");

        Str = valores.ElementAt(0);
        Dex = valores.ElementAt(1);
        Con = valores.ElementAt(2);
        Int = valores.ElementAt(3);
        Wis = valores.ElementAt(4);
        Cha = valores.ElementAt(5);

        StrMod = (Str - 10) / 2;
        DexMod = (Dex - 10) / 2;
        ConMod = (Con - 10) / 2;
        IntMod = (Int - 10) / 2;
        WisMod = (Wis - 10) / 2;
        ChaMod = (Cha - 10) / 2;

        int maiorValor = valores.Max();
        int menorValor = valores.Min();

        NomesMaioresAtributos.Clear();
        NomesMenoresAtributos.Clear();

        for (int i = 0; i < 6; i++)
        {
            if (valores[i] == maiorValor)
            {
                switch (i)
                {
                    case 0: NomesMaioresAtributos.Add("Força"); break;
                    case 1: NomesMaioresAtributos.Add("Destreza"); break;
                    case 2: NomesMaioresAtributos.Add("Constituição"); break;
                    case 3: NomesMaioresAtributos.Add("Inteligência"); break;
                    case 4: NomesMaioresAtributos.Add("Sabedoria"); break;
                    case 5: NomesMaioresAtributos.Add("Carisma"); break;
                }
            }

            if (valores[i] == menorValor)
            {
                switch (i)
                {
                    case 0: NomesMenoresAtributos.Add("Força"); break;
                    case 1: NomesMenoresAtributos.Add("Destreza"); break;
                    case 2: NomesMenoresAtributos.Add("Constituição"); break;
                    case 3: NomesMenoresAtributos.Add("Inteligência"); break;
                    case 4: NomesMenoresAtributos.Add("Sabedoria"); break;
                    case 5: NomesMenoresAtributos.Add("Carisma"); break;
                }
            }
        }
    }
    private string obterDescricaoAtributosLimite()
    {
        string descricao = "";

        if (NomesMaioresAtributos.Count == 1)
            descricao = $"O maior atributo é {NomesMaioresAtributos.Single()}";
        else
            descricao = $"Os maiores atributos são {String.Join(',', NomesMaioresAtributos.Take(NomesMaioresAtributos.Count() - 1)).Replace(",", ", ")} e {NomesMaioresAtributos.Last()}";

        if (NomesMenoresAtributos.Count == 1)
            descricao = $"{descricao} e o menor atributo é {NomesMenoresAtributos.Single()}.";
        else
            descricao = $"{descricao} e os menores atributos são {String.Join(',', NomesMenoresAtributos.Take(NomesMenoresAtributos.Count() - 1)).Replace(",", ", ")} e {NomesMenoresAtributos.Last()}.";

        return descricao;
    }
}