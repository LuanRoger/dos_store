using DosStore.Controller;
using DosStore.Models.Read;
using DosStore.Views.Messages;
using Spectre.Console;

namespace DosStore.Views;

public class CreateSaleMenuView : IFlowMenuView
{
    private readonly MultiselectProductsMenuView _multiselectProductsMenuView = new();
    private readonly PickClientMenuView _pickClientMenuView = new();
    private readonly ProductController _productController = new();
    private readonly SalesController _salesController = new();
    private readonly CreateSaleMenuMessages _createSaleMenuMessages = new();
    
    public async Task StartFlow()
    {
        var selectedProducts = await _multiselectProductsMenuView.StartFlow();
        int clientId = await _pickClientMenuView.StartFlow();
        
        double total = selectedProducts.Sum(p => p.valor);
        string totalMessage = $"O total será: R$ {total:F2}. Deseja continuar?";
        bool confirm = AnsiConsole.Confirm(totalMessage);
        if(!confirm)
            return;
        
        foreach (MinimalReadProductModel selectedProduct in selectedProducts)
        {
            int newAmount = selectedProduct.quantidade - 1;
            await _productController.UpdateProductAmount(selectedProduct.id, newAmount);
        }
        
        var productsIds = selectedProducts.Select(p => p.id);
        await _salesController.AddSale(clientId, productsIds, total);
        _createSaleMenuMessages.ShowCreatedSale();
    }
}