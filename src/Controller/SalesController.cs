using System.Collections.ObjectModel;
using DosStore.Models;
using DosStore.Models.Read;
using DosStore.Repository;

namespace DosStore.Controller;

public class SalesController
{
    private readonly SalesRepository _salesRepository = new();

    public async Task<IReadOnlyList<MinimalReadSalesModel>> GetAllSales()
    {
        var sales = await _salesRepository.GetAllSales();
        
        List<MinimalReadSalesModel> minimalSales = new();
        foreach (VendaModel sale in sales)
        {
            var products = sale.produtosComprados.Select(f => new MinimalReadProductModel
            {
                id = f.id,
                nome = f.nome,
                valor = f.valor,
                quantidade = f.quantidade
            });

            MinimalReadClientModel client = new()
            {
                id = sale.cliente.id,
                nome = sale.cliente.nome,
                email = sale.cliente.email
            };
            
            minimalSales.Add(new()
            {
                id = sale.id,
                produtosComprados = products.ToList(),
                cliente = client,
                total = sale.total
            });
        }

        return minimalSales;
    }

    public async Task AddSale(int clientId, IEnumerable<int> purchasedProductsIds, double total) =>
        await _salesRepository.AddSale(clientId, purchasedProductsIds, total);
}