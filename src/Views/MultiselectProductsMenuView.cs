using DosStore.Controller;
using DosStore.Models.Read;
using DosStore.Utils;
using Spectre.Console;

namespace DosStore.Views;

public class MultiselectProductsMenuView : IResultedMenu<IReadOnlyList<MinimalReadProductModel>>
{
    private readonly ProductController _productController = new();
    
    public async Task<IReadOnlyList<MinimalReadProductModel>> StartFlow()
    {
        var products = await _productController.GetAllProducts();

        var selected = AnsiConsole.Prompt(
            new MultiSelectionPrompt<MinimalReadProductModel>()
                .Title("O que o cliente vai comprar?")
                .UseConverter(MinimalReadProductModelFormater.FormatProduct)
                .AddChoices(products));

        return selected;
    }
}