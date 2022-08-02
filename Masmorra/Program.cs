using System.Security.Cryptography;

Console.WriteLine("--- Masmorra ---");

var jogo = new Jogo();
var heroi = jogo.Heroi;

Console.WriteLine($"Heroi: Habilidade = {heroi.Habilidade}, Energia = {heroi.Energia}, Sorte = {heroi.Sorte}");

while (jogo.AlgumaCriaturaViva() && !heroi.EstaMorto())
{
    var criatura = jogo.CriaturaAtual();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"\nEnfrentando {criatura.Nome}: ");
    Console.ResetColor();
    Console.WriteLine($"Energia: Heroi = {heroi.Energia}, {criatura.Nome} = {criatura.Energia}");

    int ataque = heroi.ForcaDeAtaque();
    int defesa = criatura.ForcaDeAtaque();

    bool empate = ataque == defesa;
    if (empate)
    {
        Console.WriteLine("Ambos erraram.");
        continue;
    }

    bool venceu = ataque > defesa;
    if (venceu)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Acertou! ");
        Console.ResetColor();

        int dano = 2;
        bool testarASorte = false;

        while (heroi.PodeTestarSorte())
        {
            try
            {
                Console.Write($"Quer testar a sorte para aumentar o dano (Sorte = {heroi.Sorte}) [s/n]? ");
                string opcao = Console.ReadLine()!;
                testarASorte = opcao.Trim().Substring(0, 1).ToUpper() == "S";
                break;
            }
            catch (System.Exception) { }
        }

        if (testarASorte)
        {
            if (heroi.EstaComSorte())
            {
                dano = 4;
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("Sortudo! ");
                Console.ResetColor();

            }
            else
            {
                dano = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Azarado... ");
                Console.ResetColor();

            }
        }

        criatura.SofrerDano(dano);
        Console.WriteLine($"{criatura.Nome} sofre {dano} ponto(s) de dano{(!criatura.EstaMorto() ? ", mas ainda não" : " e")} está morto.");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Foi acertado! ");
        Console.ResetColor();


        int dano = 2;
        bool testarASorte = false;

        while (heroi.PodeTestarSorte())
        {
            try
            {
                Console.Write($"Quer testar a sorte para reduzir o dano (Sorte = {heroi.Sorte}) [s/n]? ");
                string opcao = Console.ReadLine()!;
                testarASorte = opcao.Trim().Substring(0, 1).ToUpper() == "S";
                break;
            }
            catch (System.Exception) { }
        }

        if (testarASorte)
        {
            if (heroi.EstaComSorte())
            {
                dano = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Sortudo! ");
                Console.ResetColor();
            }
            else
            {
                dano = 3;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Azarado... ");
                Console.ResetColor();

            }
        }

        heroi.SofrerDano(dano);
        Console.WriteLine($"{criatura.Nome} causa {dano} ponto(s) de dano{(!heroi.EstaMorto() ? ", mas você ainda não" : " e você")} está morto.");
    }
}

if (heroi.EstaMorto())
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n--- Game over ---");
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n--- Você venceu, parabéns! ---");
}
Console.ResetColor();

class Jogo
{
    public Heroi Heroi;
    private List<Criatura> Criaturas;

    public Jogo()
    {
        Heroi = new Heroi();
        Criaturas = new List<Criatura>
        {
            new Criatura( nome: "Lobo Cinzento", habilidade: 3, energia: 3),
            new Criatura( nome: "Lobo Branco", habilidade: 3, energia: 3),
            new Criatura( nome: "Goblin", habilidade: 5, energia: 4),
            new Criatura( nome: "Orc Vesgo", habilidade: 5, energia: 5),
            new Criatura( nome: "Orc Barbudo", habilidade: 5, energia: 5),
            new Criatura( nome: "Zumbi Manco", habilidade: 6, energia: 7),
            new Criatura( nome: "Zumbi Balofo", habilidade: 6, energia: 7),
            new Criatura( nome: "Troll", habilidade: 8, energia: 7),
            new Criatura( nome: "Ogro", habilidade: 8, energia: 9),
            new Criatura( nome: "Ogro Furioso", habilidade: 10, energia: 9),
            new Criatura( nome: "Necromante Maligno", habilidade: 12, energia: 12),
        };
    }

    public bool AlgumaCriaturaViva() => Criaturas.Any(m => !m.EstaMorto());
    public Criatura CriaturaAtual() => Criaturas.First(m => !m.EstaMorto());
}

abstract class Personagem
{
    public int Habilidade { get; protected set; }
    public int Energia { get; protected set; }

    protected int d6() => RandomNumberGenerator.GetInt32(1, 7);
    public int ForcaDeAtaque() => Habilidade + d6() + d6();
    public void SofrerDano(int pontosDeDano)
    {
        Energia -= pontosDeDano;
    }
    public bool EstaMorto() => Energia <= 0;
}

class Heroi : Personagem
{
    public int Sorte { get; protected set; }

    public Heroi()
    {
        Habilidade = d6() + 6;
        Energia = d6() + d6() + 12;
        Sorte = d6() + 6;
    }

    public bool PodeTestarSorte() => Sorte > 0;
    public bool EstaComSorte()
    {
        if (Sorte <= 0) throw new ArgumentException("Não possui pontos de sorte suficientes.");

        bool resultado = d6() + d6() <= Sorte;
        Sorte--;

        return resultado;
    }
}

class Criatura : Personagem
{
    public string Nome { get; protected set; }

    public Criatura(string nome, int habilidade, int energia)
    {
        Nome = nome;
        Habilidade = habilidade;
        Energia = energia;
    }
}
