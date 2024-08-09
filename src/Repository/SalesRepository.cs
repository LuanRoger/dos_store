using DosStore.Context;
using DosStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DosStore.Repository;

public class SalesRepository
{
    private readonly ProdutoRepository _productRepository = new();
    
    public async Task<IReadOnlyList<VendaModel>> GetAllSales()
    {
        await using AppDbContext db = new();
        return await db.vendas
            .Include(f => f.cliente)
            .Include(f => f.produtosComprados)
            .OrderByDescending(f => f.id)
            .Take(10)
            .ToListAsync();
    }
    
    public async Task AddSale(int clientId, IEnumerable<int> purchasedProductsIds, double total)
    {
        await using AppDbContext db = new();
        List<ProdutoModel> purchasedProducts = new();
        foreach (int productsId in purchasedProductsIds)
        {
            ProdutoModel? toAdd = await db.produtos.FindAsync(productsId);
            if(toAdd is null)
                continue;
            
            purchasedProducts.Add(toAdd);
        }

        VendaModel sale = new()
        {
            produtosComprados = purchasedProducts,
            clienteId = clientId,
            total = total
        };
        
        await db.vendas.AddAsync(sale);
        await db.SaveChangesAsync();
    }
}