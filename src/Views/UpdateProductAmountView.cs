using DosStore.Controller;
using DosStore.Views.Messages;
using Spectre.Console;

namespace DosStore.Views;

public class UpdateProductAmountView : IFlowMenuView
{
    private readonly ProductController _productController = new();
    private readonly PickProductMenuView _pickProductMenuView = new();
    private readonly UpdateProductMessages _updateProductMessages = new();
    
    public async Task StartFlow()
    {
        int selectedProductId = await _pickProductMenuView.StartFlow();
        
        if(selectedProductId < 0)
            return;
        
        int newAmount = AnsiConsole.Prompt(
            new TextPrompt<int>("Digite a nova quantidade: ")
                .ValidationErrorMessage("Digite um número válido")
                .Validate(_productController.ValidateAmount));

        int? registeredAmount = await _productController
            .UpdateProductAmount(selectedProductId, newAmount);

        if (!registeredAmount.HasValue)
        {
            _updateProductMessages.ProductAmountNotUpdated();
            return;
        }
        
        _updateProductMessages.ProductAmountUpdated();
    }
}