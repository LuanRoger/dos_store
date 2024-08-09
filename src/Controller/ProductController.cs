using DosStore.Models;
using DosStore.Models.Read;
using DosStore.Repository;

namespace DosStore.Controller;

public class ProductController
{
    private readonly ProdutoRepository _produtoRepository = new();

    public async Task<IReadOnlyList<MinimalReadProductModel>> GetAllProducts()
    {
        var products = await _produtoRepository.GetAllProducts();
        var minimalProducts = products.Select(p => new MinimalReadProductModel
        {
            id = p.id,
            nome = p.nome,
            quantidade = p.quantidade,
            valor = p.valor
        }).ToList();

        return minimalProducts;
    }

    public async Task<ProdutoModel?> GetProdutoById(int id) => 
        await _produtoRepository.GetProdutoById(id);
    
    public async Task RegisterProduct(ProdutoModel newProduct) => 
        await _produtoRepository.RegisterProduct(newProduct);
    
    public async Task DeleteProduct(ProdutoModel product) =>
        await _produtoRepository.DeleteProduct(product);

    public async Task<int?> UpdateProductAmount(int id, int amount) => 
        await _produtoRepository.UpdateProductAmount(id, amount);

    public bool ValidateAmount(int amount) => amount > 0;

    public bool ValidateValue(double value) => value > 0;

}