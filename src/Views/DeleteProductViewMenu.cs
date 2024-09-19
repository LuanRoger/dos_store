using DosStore.Models;
using DosStore.Repository;
using DosStore.Views.Messages;

namespace DosStore.Views;

public class DeleteProductViewMenu : ICommandMenuView
{
    private readonly ProdutoRepository _produtoRepository = new();
    private readonly PickProductMenuView _pickProductMenuView = new();
    private readonly DeleteProductMessages _messages = new();
    
    public async Task StartFlow()
    {
        int productId = await _pickProductMenuView.StartFlow();
        if(productId < 0)
            return;
        
        ProdutoModel? produtoModel = await _produtoRepository.GetProdutoById(productId);
        if(produtoModel is null)
            return;

        await _produtoRepository.DeleteProduct(produtoModel);
        
        _messages.ProductDeleted();
    }
}