Console.WriteLine("--- Carrinho de Compras ---");

var produtosDisponiveis = new List<Produto>()
{
    new Produto() { Codigo = 1, Descricao = "Camiseta P", Preco = 40 },
    new Produto() { Codigo = 2, Descricao = "Camiseta M", Preco = 45 },
    new Produto() { Codigo = 3, Descricao = "Camiseta G", Preco = 50 },
    new Produto() { Codigo = 4, Descricao = "Camiseta GG", Preco = 55 },
};

var carrinho = new CarrinhoDeCompras();

string opcao = "";
while (opcao != "F")
{
    Console.Write("\n[P]rodutos, [A]dicionar, [V]isualizar, [L]impar, [F]inalizar: ");
    opcao = Console.ReadLine()!;
    opcao = opcao.Trim().Substring(0, 1).ToUpper();

    switch (opcao)
    {
        case "P":
            ExibirListaDeProdutos(produtosDisponiveis);
            break;

        case "A":
            Console.Write("Código.......: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Quantidade...: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            var produto = produtosDisponiveis.Find(p => p.Codigo == codigo);

            if (produto == null)
            {
                Console.WriteLine("Não encontrado.");
                break;
            }

            if (quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                break;
            }

            carrinho.AdicionarItemAoCarrinho(produto, quantidade);
            break;

        case "V":
        case "F":
            ExibirCarrinhoDeCompras(carrinho);
            break;

        case "L":
            carrinho.LimparCarrinho();
            break;
    }
}

void ExibirListaDeProdutos(List<Produto> produtos)
{
    foreach (var produto in produtos)
        Console.WriteLine($"{produto.Codigo}: {produto.Descricao}, por {produto.Preco:C2}");
}

void ExibirCarrinhoDeCompras(CarrinhoDeCompras carrinho)
{
    foreach (var item in carrinho.Itens)
        Console.WriteLine($"{item.Quantidade} x {item.Produto.Descricao} = {(item.Produto.Preco * item.Quantidade):C2}");
    Console.WriteLine($"\nTotal = {carrinho.Total():C2}");
}

class Produto
{
    public int Codigo { get; set; } = default!;
    public string Descricao { get; set; } = default!;
    public decimal Preco { get; set; } = default!;
}

class ItemDoCarrinho
{
    public Produto Produto { get; set; } = default!;
    public int Quantidade { get; set; }
}

class CarrinhoDeCompras
{
    public List<ItemDoCarrinho> Itens = new();
    public void LimparCarrinho()
    {
        Itens.Clear();
    }
    public void AdicionarItemAoCarrinho(Produto produto, int quantidade)
    {
        var noCarrinho = Itens.Find(i => i.Produto == produto);
        if (noCarrinho != null)
        {
            noCarrinho.Quantidade += quantidade;
        }
        else
        {
            Itens.Add(new ItemDoCarrinho() { Produto = produto, Quantidade = quantidade });
        }
    }
    public decimal Total()
    {
        return Itens.Sum(item => item.Produto.Preco * item.Quantidade);
    }
}
