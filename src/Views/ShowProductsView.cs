using System.Globalization;
using DosStore.Models;
using DosStore.Repository;
using Spectre.Console;

namespace DosStore.Views;

public class ShowProductsView : IFlowMenuView
{
    private readonly ProdutoRepository _produtoRepository = new();
    
    public async Task StartFlow()
    {
        var products = await _produtoRepository.GetAllProducts();
        
        Table table = new();
        table.AddColumn("ID");
        table.AddColumn("Nome");
        table.AddColumn("Preço (R$)");
        table.AddColumn("Quantidade");
        
        foreach (ProdutoModel product in products)
        {
            table.AddRow(
                product.id.ToString(), 
                product.nome, 
                product.valor.ToString(CultureInfo.CurrentCulture), 
                product.quantidade.ToString());
        }
        
        AnsiConsole.Write(table);
    }
}