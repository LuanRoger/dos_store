using System.Globalization;
using DosStore.Models;
using DosStore.Repository;
using DosStore.Utils;
using Spectre.Console;

namespace DosStore.Views;

public class ShowSalesMenuView : IFlowMenuView
{
    private readonly SalesRepository _salesRepository = new();
    
    public async Task StartFlow()
    {
        var sales = await _salesRepository.GetAllSales();

        Table table = new Table()
            .AddColumns("ID", "Produtos comprados", "Cliente", "Total R$");

        foreach (VendaModel sale in sales)
        {
            Table boughtProductsTable = ProductTableGenerator
                .GenerateMinimalProductTable(sale.produtosComprados);
            
            table.AddRow(
                new Markup(sale.id.ToString()), boughtProductsTable,
                new Markup(sale.cliente.nome),
                new Markup(sale.total.ToString(CultureInfo.CurrentCulture)));
        }
        
        AnsiConsole.Write(table);
    }
}