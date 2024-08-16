using DosStore.Models;
using Spectre.Console;

namespace DosStore.Utils;

public static class ProductTableGenerator
{
    public static Table GenerateMinimalProductTable(IEnumerable<ProdutoModel> products)
    {
        Table table = new Table()
            .AddColumns("Nome", "Quantidade");

        foreach (ProdutoModel product in products)
        {
            table.AddRow(product.nome)
                .AddRow(product.quantidade.ToString());
        }

        return table;
    }
}