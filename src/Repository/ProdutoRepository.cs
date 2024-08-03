using DosStore.Context;
using DosStore.Models;

namespace DosStore.Repository;

public class ProdutoRepository
{
    public async Task RegisterProduct(ProdutoModel newProduct)
    {
        await using AppDbContext db = new();
        await db.produtos.AddAsync(newProduct);
    }
}