using DosStore.Context;
using DosStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DosStore.Repository;

public class ProdutoRepository
{
    public async Task<IReadOnlyList<ProdutoModel>> GetAllProducts()
    {
        await using AppDbContext db = new();
        return await db.produtos.ToListAsync();
    }
    
    public async Task<ProdutoModel?> GetProdutoById(int id)
    {
        await using AppDbContext db = new();
        return await db.produtos.FindAsync(id);
    }
    
    public async Task RegisterProduct(ProdutoModel newProduct)
    {
        await using AppDbContext db = new();
        await db.produtos.AddAsync(newProduct);
        await db.SaveChangesAsync();
    }
    
    public async Task DeleteProduct(ProdutoModel product)
    {
        await using AppDbContext db = new();
        db.produtos.Remove(product);
        await db.SaveChangesAsync();
    }
    
    public async Task<int?> UpdateProductAmount(int id, int amount)
    {
        await using AppDbContext db = new();
        ProdutoModel? product = await db.produtos.FindAsync(id);
        if(product is null)
            return null;
        
        product.quantidade = amount;
        await db.SaveChangesAsync();
        
        return product.quantidade;
    }
}