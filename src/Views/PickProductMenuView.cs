using DosStore.Controller;
using DosStore.Models.Read;
using DosStore.Utils;
using Spectre.Console;

namespace DosStore.Views;

public class PickProductMenuView : IResultedMenu<int>
{
    private readonly ProductController _productController = new();
    
    public async Task<int> StartFlow()
    {
        var products = await _productController.GetAllProducts();
        bool areProduct = products.Any();
        if(!areProduct)
            return -1;
        
        MinimalReadProductModel selectedProduct = AnsiConsole.Prompt(
            new SelectionPrompt<MinimalReadProductModel>()
                .Title("Qual produto você deseja escolher?")
                .PageSize(10)
                .MoreChoicesText("[grey](Mova para cima e para baixo para ver mais opções)[/]")
                .AddChoices(products)
                .UseConverter(MinimalReadProductModelFormater.FormatProduct)
        );

        return selectedProduct.id;
    }
}